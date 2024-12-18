using Npgsql.Replication.PgOutput.Messages;
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

namespace RestaurantChain.Presentation.ViewModel.UnitsViewModel
{
    internal class UnitViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _unitName;
        private readonly IUnitsService _unitsService;
        private readonly int? _currentUnitId;

        public Action OnSaveSuccess;

        public ICommand EnterCommand { get; set; }

        public string UnitName
        {
            get => _unitName;
            set
            {
                _unitName = value;
                OnPropertyChanged("UnitName");
            }
        }

        public UnitViewModel(IUnitsService unitsService, int? currentUnitId)
        {
            _unitsService = unitsService;
            _currentUnitId = currentUnitId;
            EnterCommand = new RelayCommand(Enter);
        }

        private void Enter(object sender)
        {
            if (string.IsNullOrWhiteSpace(_unitName))
            {
                MessageBox.Show("Введите название единицы измерения!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = _currentUnitId.HasValue ? Update() : Create();
            if (result)
                OnSaveSuccess?.Invoke();
        }

        private bool Update()
        {
            var unit = new Units
            {
                Id = _currentUnitId.Value,
                UnitName = _unitName
            };
            try
            {
                _unitsService.Update(unit);
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
            var unit = new Units
            {
                UnitName = _unitName
            };

            var id = _unitsService.Create(unit);
            if (id == 0)
            {
                MessageBox.Show("Такая единица измерения уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
