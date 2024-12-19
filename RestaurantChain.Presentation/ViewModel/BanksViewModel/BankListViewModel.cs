using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.BanksViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.BanksViewModel
{
    internal class BankListViewModel : ListViewModelBase<Banks>
    {
        private readonly IBanksService _banksService;

        public BankListViewModel(IServiceProvider serviceProvider, DataGrid _dataGrid) : base(serviceProvider, _dataGrid)
        {
            _banksService = serviceProvider.GetRequiredService<IBanksService>();
            DataBind();
        }

        protected override void DataBind()
        {
            IReadOnlyCollection<Banks> entities = _banksService.List();
            SetEntities(entities);
        }

        protected override void SetCommands()
        {
            CreateCommand = new RelayCommand(CreateEntity);
            EditCommand = new RelayCommand(EditEntity);
            DeleteCommand = new RelayCommand(DeleteEntity);
            RefreshCommand = new RelayCommand(RefreshData);
        }

        private void CreateEntity(object sender)
        {
            var view = new BankWindow(ServiceProvider, bankId: null);
            ShowDialog(view);
            RefreshData(sender);
        }

        private void EditEntity(object sender)
        {
            if (DataGrid.SelectedItem == null)
            {
                return;
            }
            int bankId = ((Banks)DataGrid.SelectedItem).Id;
            var view = new BankWindow(ServiceProvider, bankId);
            ShowDialog(view);
            RefreshData(sender);
        }

        private void DeleteEntity(object sender)
        {
            if (DataGrid.SelectedItem == null)
            {
                return;
            }
            int bankId = ((Banks)DataGrid.SelectedItem).Id;
            Banks bank = _banksService.Get(bankId);

            if (MessageBox.Show($"Удалить банк '{bank.BankName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _banksService.Delete(bankId);
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
