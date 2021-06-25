using Microsoft.EntityFrameworkCore;
using System;

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
    /// Дата покупки
    /// </summary>
    public DateTime DateOrder { get; set; }


    public Guid ProductId { get; set; }

    public Product Product { get; set; }
    
    /// <summary>
    /// Количество товара 
    /// </summary>
    public int Count { get; set; }


    
    /// <summary>
    /// Создание нового заказа
    /// </summary>
    /// <returns></returns>
    public static Order New()
      => new Order()
      {
       
      };
  }
}
