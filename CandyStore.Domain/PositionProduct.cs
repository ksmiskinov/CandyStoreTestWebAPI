using System;

namespace CandyStore.Domain
{
  /// <summary>
  /// Описывает позицию карты в колоде.
  /// </summary>

  public class PositionProduct
  {
    private PositionProduct() { }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }


    /// <summary>
    /// Уникальный идентификатор магазина
    /// </summary>
    public Guid StoreId { get; set; }

    /// <summary>
    /// Ассоциация на сущность магазин 
    /// </summary>
    public Store Store { get; set; }

    /// <summary>
    /// Уникальный идентификатор продукта
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Ассоциация на сущность продукт 
    /// </summary>
    public Product Product { get; set; }


    /// <summary>
    /// Остаток на складке
    /// </summary>
    public int StockBalance { get; set; }

    /// <summary>
    /// Создание позиции на складе
    /// </summary>
    /// <returns></returns>
    public static PositionProduct New(Guid storeId, Guid productId, int stockBalance)
      => new PositionProduct()
      {
        StoreId = storeId,
        ProductId = productId,
        StockBalance = stockBalance
      };
  }
}
