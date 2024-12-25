using System.Windows;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.SuppliersViewModel;

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

    /// <summary>
    /// Модель данных. Имя
    /// </summary>
    public string SupplierName
    {
        get => _supplierName;
        set
        {
            _supplierName = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Список улиц
    /// </summary>
    public IReadOnlyCollection<Streets> StreetsList
    {
        get => _streetsList;
        set
        {
            _streetsList = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Выбранная улица
    /// </summary>
    public int SelectedStreetId
    {
        get => _selectedStreetId;
        set
        {
            _selectedStreetId = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Имя поставщика
    /// </summary>
    public string SupervisorName
    {
        get => _supervisorName;
        set
        {
            _supervisorName = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Фамилия поставщика
    /// </summary>
    public string SupervisorLastName
    {
        get => _supervisorLastName;
        set
        {
            _supervisorLastName = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Отчество поставщика
    /// </summary>
    public string SupervisorSurname
    {
        get => _supervisorSurname;
        set
        {
            _supervisorSurname = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Телефон поставщика
    /// </summary>
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Список банков
    /// </summary>
    public IReadOnlyCollection<Banks> BanksList
    {
        get => _banksList;
        set
        {
            _banksList = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Выбранный банк
    /// </summary>
    public int SelectedBankId
    {
        get => _selectedBankId;
        set
        {
            _selectedBankId = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Банковский счет
    /// </summary>
    public string CurrentAccount
    {
        get => _currentAccount;
        set
        {
            _currentAccount = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. ИНН
    /// </summary>
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

    /// <summary>
    /// Обработка команды нажатия кнопки сохранения данных
    /// </summary>
    /// <param name="sender"></param>
    public void Enter(object sender)
    {
        Suppliers supplier = ValidateAndGetModelOnSave();

        if (supplier == null)
        {
            return;
        }

        bool result = CurrentId.HasValue ? Update(supplier) : Create(supplier);

        if (result)
        {
            OnSaveSuccess?.Invoke();
        }
    }

    private bool Update(Suppliers supplier)
    {
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
    
    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <returns></returns>
    private bool Create(Suppliers supplier)
    {
        int id = _suppliersService.Create(supplier);

        if (id == 0)
        {
            MessageBox.Show("Такой поставщик уже существует!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    /// <summary>
    /// Провалидировать и получить модель для сохранения
    /// </summary>
    /// <returns></returns>
    private Suppliers ValidateAndGetModelOnSave()
    {
        var supplier = new Suppliers
        {
            Id = CurrentId ?? 0,
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

        var errors = new List<string>();

        if (string.IsNullOrEmpty(supplier.SupplierName))
        {
            errors.Add("Название поставщика");
        }

        if (string.IsNullOrEmpty(supplier.SupervisorLastName))
        {
            errors.Add("Фамилия поставщика");
        }

        if (string.IsNullOrEmpty(supplier.SupervisorSurname))
        {
            errors.Add("Отчество поставщика");
        }

        if (string.IsNullOrEmpty(supplier.SupervisorName))
        {
            errors.Add("Имя поставщика");
        }

        if (string.IsNullOrEmpty(supplier.CurrentAccount))
        {
            errors.Add("Номер счета");
        }

        if (string.IsNullOrEmpty(supplier.PhoneNumber))
        {
            errors.Add("Телефон");
        }

        if (string.IsNullOrEmpty(supplier.TIN))
        {
            errors.Add("ИНН");
        }

        if (supplier.BankId <= 0)
        {
            errors.Add("Банк");
        }

        if (supplier.StreetId <= 0)
        {
            errors.Add("Улица");
        }

        if (errors.Count > 0)
        {
            MessageBox.Show($"Поля не заполнены: {string.Join(",", errors)}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (supplier.TIN.Length < 10)
        {
            MessageBox.Show("ИНН не может быть меньше 10 цифр", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (supplier.PhoneNumber.Length < 11)
        {
            MessageBox.Show("Телефон не может быть меньше 11 цифр", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (supplier.CurrentAccount.Length < 20)
        {
            MessageBox.Show("Номер счета не может быть меньше 10 цифр", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        return supplier;
    }

    /// <summary>
    /// Валидация при загрузке и заполнение полей
    /// </summary>
    /// <returns></returns>
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