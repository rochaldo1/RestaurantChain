using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.BanksViews;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.BanksViewModel;

internal class BankListViewModel : ListViewModelBase<Banks>
{
    private readonly IBanksService _banksService;

    public BankListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _banksService = serviceProvider.GetRequiredService<IBanksService>();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<Banks> entities = _banksService.List();
        SetEntities(entities);
    }

    /// <summary>
    /// Установить команды CRUD кнопкам
    /// </summary>
    protected override void SetCommands()
    {
        CreateCommand = new RelayCommand(CreateEntity);
        EditCommand = new RelayCommand(EditEntity);
        DeleteCommand = new RelayCommand(DeleteEntity);
    }

    /// <summary>
    /// Вызов команды создания записи из окна таблицы
    /// </summary>
    /// <param name="sender"></param>
    private void CreateEntity(object sender)
    {
        var view = new BankWindow(ServiceProvider, bankId: null);
        WindowHelper.ShowDialog(view, "Создание записи");
        DataBind();
    }

    /// <summary>
    /// Вызов команды редактирования выбранной записи из таблицы
    /// </summary>
    /// <param name="sender"></param>
    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }
            
        var view = new BankWindow(ServiceProvider, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи");
        DataBind();
    }

    /// <summary>
    /// Удалить выбранную запись
    /// </summary>
    /// <param name="sender"></param>
    private void DeleteEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }
            
        Banks bank = _banksService.Get(SelectedItem.Id);

        if (MessageBox.Show($"Удалить банк '{bank.BankName}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            try
            {
                _banksService.Delete(SelectedItem.Id);
            }
            catch (Exception e)
            {
                IsFkError(e);
            }
        }
        else
        {
            return;
        }

        DataBind();
    }
}