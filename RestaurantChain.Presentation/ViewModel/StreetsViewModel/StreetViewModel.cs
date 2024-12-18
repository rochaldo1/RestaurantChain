using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.StreetsViews;

namespace RestaurantChain.Presentation.ViewModel.StreetsViewModel
{
    internal class StreetViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _streetName;
        private readonly IStreetsService _streetsService;
        private readonly int? _currentStreetId;

        public Action OnSaveSuccess;
        public Action OnCancel;
        
        public ICommand EnterCommand { get; set; }

        public string StreetName
        {
            get => _streetName;
            set
            {
                _streetName = value;
                OnPropertyChanged("StreetName");
            }
        }

        private bool ValidateStreet()
        {
            if (_currentStreetId.HasValue)
            {
                var street = _streetsService.Get(_currentStreetId.Value);
                if (street == null)
                {
                    MessageBox.Show("Такой улицы не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                StreetName = street.StreetName;
                return true;
            }
            return true;
        }

        public StreetViewModel(IStreetsService streetsService, int? currentStreetId)
        {
            _currentStreetId = currentStreetId;
            _streetsService = streetsService;
            if (!ValidateStreet())
                OnCancel?.Invoke();
            EnterCommand = new RelayCommand(Enter);
        }

        private void Enter(object sender)
        {
            if (string.IsNullOrWhiteSpace(_streetName))
            {
                MessageBox.Show("Введите название улицы!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Сохранить или обновить.
            var result = _currentStreetId.HasValue ? Update() : Create();
            if (result) // Если успех - закрыть окно.
                OnSaveSuccess?.Invoke();
        }

        /// <summary>
        /// Действие обновить.
        /// </summary>
        /// <returns>Успех операции.</returns>
        private bool Update()
        {
            var street = new Streets
            {
                Id = _currentStreetId.Value,
                StreetName = _streetName,
            };
            try
            {
                _streetsService.Update(street);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Действие создать.
        /// </summary>
        /// <returns>Успех операции.</returns>
        private bool Create()
        {
            var street = new Streets
            {
                StreetName = _streetName,
            };
            
            var id = _streetsService.Create(street);
            if (id == 0)
            {
                MessageBox.Show("Такая улица уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
