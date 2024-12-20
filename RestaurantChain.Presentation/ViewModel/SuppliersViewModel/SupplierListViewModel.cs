using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.SuppliersViews;
using RestaurantChain.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.SuppliersViewModel
{
    public class SupplierListViewModel : ListViewModelBase<Suppliers>
    {
        private readonly ISuppliersService _suppliersService;

        public SupplierListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _suppliersService = serviceProvider.GetRequiredService<ISuppliersService>();
            DataBind();
        }

        protected override void DataBind()
        {
            IReadOnlyCollection<Suppliers> entities = _suppliersService.List();
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
            var view = new SupplierWindow(ServiceProvider, supplierId: null);
            ShowDialog(view, "Создание записи", 500, 500);
            RefreshData(sender);
        }

        private void EditEntity(object sender)
        {
            if (!HasSelectedItem())
            {
                return;
            }

            var view = new SupplierWindow(ServiceProvider, SelectedItem.Id);
            ShowDialog(view, "Редактирование записи", 500, 500);
            RefreshData(sender);
        }

        private void DeleteEntity(object sender)
        {
            if (!HasSelectedItem())
            {
                return;
            }

            Suppliers supplier = _suppliersService.Get(SelectedItem.Id);
            if (MessageBox.Show($"Удалить поставщика '{supplier.SupplierName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _suppliersService.Delete(SelectedItem.Id);
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
