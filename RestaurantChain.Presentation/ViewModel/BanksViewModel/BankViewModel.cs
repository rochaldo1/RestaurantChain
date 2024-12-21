using System.ComponentModel;
using System.Windows;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.BanksViewModel;

internal class BankViewModel : EditViewModelBase
{
    private readonly IBanksService _banksService;

    private string _bankName;

    public string BankName
    {
        get => _bankName;
        set
        {
            _bankName = value;
            OnPropertyChanged();
        }
    }

    public BankViewModel(IBanksService banksService, int? currentId) : base(currentId)
    {
        _banksService = banksService;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    public void Enter(object sender)
    {
        OnPropertyChanged();
        if (string.IsNullOrWhiteSpace(BankName))
        {
            MessageBox.Show("Введите название банка!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        bool result = CurrentId.HasValue ? Update() : Create();

        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    private bool Create()
    {
        var bank = new Banks
        {
            BankName = _bankName
        };

        int id = _banksService.Create(bank);

        if (id == 0)
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
            Id = CurrentId.Value,
            BankName = _bankName
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

    public override bool Validate()
    {
        if (CurrentId.HasValue)
        {
            Banks? bank = _banksService.Get(CurrentId.Value);

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
}