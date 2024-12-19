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
using RestaurantChain.Presentation.View.UnitsViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UnitsViewModel
{
    internal class UnitListViewModel : ListViewModelBase<Units>
    {
        private readonly IUnitsService _unitsService;

        public UnitListViewModel(IServiceProvider serviceProvider, DataGrid _dataGrid) : base(serviceProvider, _dataGrid)
        {
            _unitsService = serviceProvider.GetRequiredService<IUnitsService>();
            DataBind();
        }

        protected override void DataBind()
        {
            IReadOnlyCollection<Units> entities = _unitsService.List();
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
            var view = new UnitWindow(ServiceProvider, unitId: null);
            var window = new Window
            {
                Content = view,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
                Height = 200,
                Width = 300,
                Title = "Создание записи"
                // TODO: Найти какую-нибудь иконку и добавить её тут
            };
            window.ShowDialog();
            RefreshData(sender);
        }

        private void EditEntity(object sender)
        {
            if (DataGrid.SelectedItem == null)
            {
                return;
            }
            int unitId = ((Units)DataGrid.SelectedItem).Id;
            var view = new UnitWindow(ServiceProvider, unitId);
            var window = new Window
            {
                Content = view,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
                Height = 200,
                Width = 300,
                Title = "Редактирование записи"
                // TODO: Найти какую-нибудь иконку и добавить её тут
            };
            window.ShowDialog();
            RefreshData(sender);
        }

        private void DeleteEntity(object sender)
        {
            if (DataGrid.SelectedItem == null)
            {
                return;
            }
            int unitId = ((Units)DataGrid.SelectedItem).Id;
            Units unit = _unitsService.Get(unitId);

            if (MessageBox.Show($"Удалить единицу измерения '{unit.UnitName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _unitsService.Delete(unitId);
            }
            else
            {
                return ;
            }

            RefreshData(sender);
        }

        private void RefreshData(object sender)
        {
            DataBind();
        }
    }
}
