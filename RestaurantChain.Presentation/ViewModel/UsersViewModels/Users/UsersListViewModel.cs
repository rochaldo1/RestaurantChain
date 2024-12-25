using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Windows;
using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.View.Users;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.Users;

internal class UsersListViewModel : ListViewModelBase<Domain.Models.Users>
{
    private readonly IUsersService _usersService;

    public UsersListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _usersService = serviceProvider.GetRequiredService<IUsersService>();
        DataBind();
    }

    /// <summary>
    /// Обновить таблицу
    /// </summary>
    protected override void DataBind()
    {
        IReadOnlyCollection<Domain.Models.Users> entities = _usersService.List();
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
        var view = new UserWindow(ServiceProvider, userId: null);
        WindowHelper.ShowDialog(view, "Создание записи", 400, 400);
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

        var view = new UserWindow(ServiceProvider, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи", 400, 400);
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

        if (SelectedItem.Id == CurrentState.CurrentUser.Id)
        {
            MessageBox.Show("Нельзя себя удалить", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        Domain.Models.Users user = _usersService.Get(SelectedItem.Id);

        if (MessageBox.Show($"Удалить пользователя '{user.Login}'?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            _usersService.Delete(SelectedItem.Id);
        }
        else
        {
            return;
        }

        DataBind();
    }
}