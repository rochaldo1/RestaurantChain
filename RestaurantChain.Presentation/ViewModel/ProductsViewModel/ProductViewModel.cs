using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.ProductsViewModel
{
    internal class ProductViewModel : EditViewModelBase
    {
        private readonly IProductsService _productsService;
        private readonly IUnitsService _unitsService;

        private string _productName;
        private IReadOnlyCollection<Units> _unitsList;
        private int _selectedUnitId;
        private int _quantity;
        private decimal _price;

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<Units> UnitsList
        {
            get => _unitsList;
            set
            {
                _unitsList = value;
                OnPropertyChanged();
            }
        }

        public int SelectedUnitId
        {
            get => _selectedUnitId;
            set
            {
                _selectedUnitId = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
            }
        }

        public ProductViewModel(IProductsService productsService, IUnitsService unitsService, int? currentId) : base(currentId)
        {
            _productsService = productsService;
            _unitsService = unitsService;

            if (!Validate())
            {
                OnCancel.Invoke();
            }

            EnterCommand = new RelayCommand(Enter);
        }

        private void Enter(object sender)
        {
            Products product = ValidateAndGetModelOnSave();

            if (product == null)
            {
                return;
            }

            bool result = CurrentId.HasValue ? Update(product) : Create(product);

            if (result)
            {
                OnSaveSuccess?.Invoke();
            }
        }

        private bool Update(Products product)
        {
            try
            {
                _productsService.Update(product);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            return true;
        }

        private bool Create(Products product)
        {
            int id = _productsService.Create(product);

            if (id == 0)
            {
                MessageBox.Show("Такой продукт уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            return true;
        }

        private Products ValidateAndGetModelOnSave()
        {
            var product = new Products
            {
                Id = CurrentId ?? 0,
                ProductName = _productName,
                UnitId = _selectedUnitId,
                Quantity = _quantity,
                Price = _price,
            };

            var errors = new List<string>();

            if (string.IsNullOrEmpty(product.ProductName))
            {
                errors.Add("Название продукта");
            }
            
            if (product.UnitId <= 0)
            {
                errors.Add("Единица измерения");
            }

            if (product.Quantity < 0)
            {
                errors.Add("Количество на складе");
            }

            if (product.Price <= 0)
            {
                errors.Add("Стоимость за единицу, руб.");
            }

            if (errors.Count > 0)
            {
                MessageBox.Show($"Поля не заполнены: {string.Join(",", errors)}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return null;
            }

            return product;
        }

        public override bool Validate()
        {
            if (CurrentId.HasValue)
            {
                Products? product = _productsService.Get(CurrentId.Value);

                if (product == null)
                {
                    MessageBox.Show("Такого продукта не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    return false;
                }

                ProductName = product.ProductName;
                UnitsList = _unitsService.List();
                SelectedUnitId = UnitsList.First(x => x.Id == product.UnitId).Id;
                Quantity = product.Quantity;
                Price = product.Price;

                return true;
            }

            UnitsList = _unitsService.List();
            return true;
        }
    }
}
