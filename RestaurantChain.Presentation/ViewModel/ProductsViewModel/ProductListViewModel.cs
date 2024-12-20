﻿using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.ProductsViews;
using RestaurantChain.Presentation.View.SuppliersViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.ProductsViewModel
{
    public class ProductListViewModel : ListViewModelBase<Products>
    {
        private readonly IProductsService _productsService;

        public ProductListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _productsService = serviceProvider.GetRequiredService<IProductsService>();
            DataBind();
        }

        protected override void DataBind()
        {
            IReadOnlyCollection<Products> entities = _productsService.List();
            SetEntities(entities);
        }

        protected override void SetCommands()
        {
            CreateCommand = new RelayCommand(CreateEntity);
            EditCommand = new RelayCommand(EditEntity);
            DeleteCommand = new RelayCommand(DeleteEntity);
        }

        private void CreateEntity(object sender)
        {
            var view = new ProductWindow(ServiceProvider, productId: null);
            ShowDialog(view, "Создание записи", 500, 500);
            RefreshData(sender);
        }

        private void EditEntity(object sender)
        {
            if (!HasSelectedItem())
            {
                return;
            }
            
            var view = new ProductWindow(ServiceProvider, SelectedItem.Id);
            ShowDialog(view, "Редактирование записи", 500, 500);
            RefreshData(sender);
        }

        private void DeleteEntity(object sender)
        {
            if (!HasSelectedItem())
            {
                return;
            }

            Products product = _productsService.Get(SelectedItem.Id);
            if (MessageBox.Show($"Удалить продукт '{product.ProductName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _productsService.Delete(SelectedItem.Id);
            }
            else
            {
                return;
            }

            RefreshData(sender);
        }

        private void RefreshData(object sender)
        {
            DataBind();
        }
    }
}
