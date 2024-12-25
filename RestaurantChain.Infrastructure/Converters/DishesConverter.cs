using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для блюд
/// </summary>
internal static class DishesConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static Dishes ToDomain(this DishesDb dish)
    {
        return new Dishes
        {
            Id = dish.Id,
            GroupId = dish.GroupId,
            DishName = dish.DishName,
            Price = dish.Price
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static DishesDb ToStorage(this Dishes dish)
    {
        return new DishesDb
        {
            Id = dish.Id,
            GroupId = dish.GroupId,
            DishName = dish.DishName,
            Price = dish.Price
        };
    }
    
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static DishesView ToDomain(this DishesDbView dish)
    {
        return new DishesView
        {
            Id = dish.Id,
            GroupId = dish.GroupId,
            DishName = dish.DishName,
            Price = dish.Price,
            GroupName = dish.GroupName
        };
    }
}