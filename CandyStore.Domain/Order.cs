using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CandyStore.Domain
{
  /// <summary>
  /// Зазказ
  /// </summary>
  public class Order
  {
    private Order() { }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime DateOrder { get; set; }

    ///// <summary>
    ///// Уникальный идентификатор объекта
    ///// </summary>
    //public Guid SellerId { get; set; }

    ///// <summary>
    ///// Прадавец
    ///// </summary>
    //public Seller Seller { get; set; }

    /// <summary>
    /// Позиции заказа
    /// </summary>
    public IList<PositionOrder> PositionOrders { get; set; }
 
    /// <summary>
    /// Создание нового заказа
    /// </summary>
    /// <returns></returns>
    public static Order New(IList<PositionOrder> positionOrders)
      => new Order()
      {
        DateOrder = DateTime.Now,
        PositionOrders = positionOrders
      };
  }
}
