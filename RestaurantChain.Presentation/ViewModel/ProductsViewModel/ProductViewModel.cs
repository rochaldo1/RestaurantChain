using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
