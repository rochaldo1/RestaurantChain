using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.ViewModel.SuppliersViewModel
{
    internal class SupplierViewModel : EditViewModelBase
    {
        private readonly ISuppliersService _suppliersService;
        private readonly IStreetsService _streetsService;
        private readonly IBanksService _banksService;

        private string _supplierName;
        private IReadOnlyCollection<Streets> _streetsList;
        private int _selectedStreetId;
        private string _supervisorName;
        private string _supervisorLastName;
        private string _supervisorSurname;
        private string _phoneNumber;
        private IReadOnlyCollection<Banks> _banksList;
        private int _selectedBankId;
        private string _currentAccount;
        private string _tin;

        public string SupplierName
        {
            get => _supplierName;
            set
            {
                _supplierName = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<Streets> StreetsList
        {
            get => _streetsList;
            set
            {
                _streetsList = value;
                OnPropertyChanged();
            }
        }

        public int SelectedStreetId
        {
            get => _selectedStreetId;
            set
            {
                _selectedStreetId = value;
                OnPropertyChanged();
            }
        }

        public string SupervisorName
        {
            get => _supervisorName;
            set
            {
                _supervisorName = value;
                OnPropertyChanged();
            }
        }

        public string SupervisorLastName
        {
            get => _supervisorLastName;
            set
            {
                _supervisorLastName = value;
                OnPropertyChanged();
            }
        }

        public string SupervisorSurname
        {
            get => _supervisorSurname;
            set
            {
                _supervisorSurname = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<Banks> BanksList
        {
            get => _banksList;
            set
            {
                _banksList = value;
                OnPropertyChanged();
            }
        }

        public int SelectedBankId
        {
            get => _selectedBankId;
            set
            {
                _selectedBankId = value;
                OnPropertyChanged();
            }
        }

        public string CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
                OnPropertyChanged();
            }
        }

        public string TIN
        {
            get => _tin;
            set
            {
                _tin = value;
                OnPropertyChanged();
            }
        }

        public SupplierViewModel(ISuppliersService suppliersService, IStreetsService streetsService, IBanksService banksService, int? currentId) : base(currentId)
        {
            _suppliersService = suppliersService;
            _streetsService = streetsService;
            _banksService = banksService;

            if (!Validate())
            {
                OnCancel?.Invoke();
            }

            EnterCommand = new RelayCommand(Enter);
        }

        private void Enter(object sender)
        {
            // TODO: Написать проверки на все поля

            bool result = CurrentId.HasValue ? Update() : Create();

            if (result)
            {
                OnSaveSuccess?.Invoke();
            }
        }

        private bool Update()
        {
            var supplier = new Suppliers
            {
                Id = CurrentId.Value,
                SupplierName = _supplierName,
                StreetId = _selectedStreetId,
                SupervisorName = _supervisorName,
                SupervisorLastName = _supervisorLastName,
                SupervisorSurname = _supervisorSurname,
                PhoneNumber = _phoneNumber,
                BankId = _selectedBankId,
                CurrentAccount = _currentAccount,
                TIN = _tin
            };

            try
            {
                _suppliersService.Update(supplier);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            return true;
        }

        private bool Create()
        {
            var supplier = new Suppliers
            {
                SupplierName = _supplierName,
                StreetId = _selectedStreetId,
                SupervisorName = _supervisorName,
                SupervisorLastName = _supervisorLastName,
                SupervisorSurname = _supervisorSurname,
                PhoneNumber = _phoneNumber,
                BankId = _selectedBankId,
                CurrentAccount = _currentAccount,
                TIN = _tin
            };

            int id = _suppliersService.Create(supplier);

            if (id == 0)
            {
                MessageBox.Show("Такой поставщик уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            return true;
        }

        public override bool Validate()
        {
            if (CurrentId.HasValue)
            {
                Suppliers? supplier = _suppliersService.Get(CurrentId.Value);

                if (supplier == null)
                {
                    MessageBox.Show("Такого поставщика не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    return false;
                }

                SupplierName = supplier.SupplierName;
                StreetsList = _streetsService.List();
                SelectedStreetId = StreetsList.First(x => x.Id == supplier.StreetId).Id;
                SupervisorName = supplier.SupervisorName;
                SupervisorLastName = supplier.SupervisorLastName;
                SupervisorSurname = supplier.SupervisorSurname;
                PhoneNumber = supplier.PhoneNumber;
                BanksList = _banksService.List();
                SelectedBankId = BanksList.First(x => x.Id == supplier.BankId).Id;
                CurrentAccount = supplier.CurrentAccount;
                TIN = supplier.TIN;

                return true;
            }
            StreetsList = _streetsService.List();
            BanksList = _banksService.List();
            return true;
        }
    }
}
