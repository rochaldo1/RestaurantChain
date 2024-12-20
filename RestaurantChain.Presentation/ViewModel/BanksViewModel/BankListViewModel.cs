﻿using System;
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

        public BankListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
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
        }

        private void CreateEntity(object sender)
        {
            var view = new BankWindow(ServiceProvider, bankId: null);
            ShowDialog(view, "Создание записи");
            RefreshData(sender);
        }

        private void EditEntity(object sender)
        {
            if (!HasSelectedItem())
            {
                return;
            }
            
            var view = new BankWindow(ServiceProvider, SelectedItem.Id);
            ShowDialog(view, "Редактирование записи");
            RefreshData(sender);
        }

        private void DeleteEntity(object sender)
        {
            if (!HasSelectedItem())
            {
                return;
            }
            
            Banks bank = _banksService.Get(SelectedItem.Id);

            if (MessageBox.Show($"Удалить банк '{bank.BankName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _banksService.Delete(SelectedItem.Id);
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
