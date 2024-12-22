﻿using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models;

/// <summary>
/// Класс продаж в ресторане (чеки).
/// </summary>
public class Sales : IdentityBase
{
    /// <summary>
    /// Идентификатор ресторана.
    /// </summary>
    public int RestaurantId { get; set; }

    /// <summary>
    /// Идентификатор блюда.
    /// </summary>
    public int DishId { get; set; }

    /// <summary>
    /// Стоимость проданных блюд.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Количество проданных блюд.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Дата продажи в формате DD.MM.YYYY.
    /// </summary>
    public DateTime SaleDate { get; set; }
}