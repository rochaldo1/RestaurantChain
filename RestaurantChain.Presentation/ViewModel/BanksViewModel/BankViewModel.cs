using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RestaurantChain.Presentation.ViewModel.BanksViewModel
{
    internal class BankViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _bankName;
        private readonly IBanksService _banksService;
        private readonly int? _currentBankId;

        public Action OnSaveSuccess;
        public Action OnCancel;

        public ICommand EnterCommand { get; set; }

        public string BankName
        {
            get => _bankName;
            set
            {
                _bankName = value;
                OnPropertyChanged("BankName");
            }
        }

        private bool ValidateBank()
        {
            if (_currentBankId.HasValue)
            {
                var bank = _banksService.Get(_currentBankId.Value);
                if (bank == null)
                {
                    MessageBox.Show("Такого банка не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                BankName = bank.BankName;
                return true;
            }
            return true;
        }

        public BankViewModel(IBanksService banksService, int? currentBankId)
        {
            _banksService = banksService;
            _currentBankId = currentBankId;
            if (!ValidateBank())
                OnCancel?.Invoke();
            EnterCommand = new RelayCommand(Enter);
        }

        private void Enter(object sender)
        {
            if (string.IsNullOrWhiteSpace(BankName))
            {
                MessageBox.Show("Введите название банка!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = _currentBankId.HasValue ? Update() : Create();
            if (result)
                OnSaveSuccess?.Invoke();
        }

        private bool Create()
        {
            var bank = new Banks
            {
                BankName = _bankName,
            };

            var id = _banksService.Create(bank);
            if(id == 0)
            {
                MessageBox.Show("Такой банк уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool Update()
        {
            var bank = new Banks
            {
                Id = _currentBankId.Value,
                BankName = _bankName,
            };
            try
            {
                _banksService.Update(bank);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
