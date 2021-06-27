using System;

namespace CandyStore.Domain
{
  /// <summary>
  /// Описывает позицию товара в заказе.
  /// </summary>

  public class PositionOrder
  {
    private PositionOrder() { }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }


    /// <summary>
    /// Уникальный идентификатор магазина
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Ассоциация на сущность заказ 
    /// </summary>
    public Order Order { get; set; }

    /// <summary>
    /// Уникальный идентификатор продукта
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Ассоциация на сущность продукт 
    /// </summary>
    public Product Product { get; set; }


    /// <summary>
    /// Колличество
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Создание позиции на складе
    /// </summary>
    /// <returns></returns>
    public static PositionOrder New(Guid orderId, Guid productId, int count)
      => new PositionOrder()
      {
        OrderId = orderId,
        ProductId = productId,
        Count = count
      };
 
    /// <summary>
    /// Создание позиции на складе
    /// </summary>
    /// <returns></returns>
    public static PositionOrder New(Guid productId, int count)
      => new PositionOrder()
      {
        ProductId = productId,
        Count = count
      };
  }
}
