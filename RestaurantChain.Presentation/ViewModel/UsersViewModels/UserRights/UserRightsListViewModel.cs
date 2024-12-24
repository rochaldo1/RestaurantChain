﻿using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.View.Users;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.UserRights;

internal class UserRightsListViewModel : ListViewModelBase<UserRightsView>
{
    private readonly IUsersService _usersService;

    private IReadOnlyCollection<Domain.Models.Users> _usersDataSource;
    public IReadOnlyCollection<Domain.Models.Users> UsersDataSource
    {
        get => _usersDataSource;
        set
        {
            _usersDataSource = value;
            OnPropertyChanged();
            DataBind();
        }
    }

    private int _selectedUserId;
    public int SelectedUserId
    {
        get => _selectedUserId;
        set
        {
            _selectedUserId = value;
            OnPropertyChanged();
            DataBind();
        }
    }

    public UserRightsListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _usersService = serviceProvider.GetRequiredService<IUsersService>();
        DataBind();
        UsersDataSource = _usersService.List();
    }

    protected override void DataBind()
    {
        IReadOnlyCollection<UserRightsView> entities = _usersService.ListUserRights(SelectedUserId);
        SetEntities(entities);
    }

    protected override void SetCommands()
    {
        EditCommand = new RelayCommand(EditEntity);
    }

    private void EditEntity(object sender)
    {
        if (!HasSelectedItem())
        {
            return;
        }

        var view = new UserRightsWindow(ServiceProvider, SelectedItem.Id);
        WindowHelper.ShowDialog(view, "Редактирование записи", 350, 300);
        DataBind();
    }
}