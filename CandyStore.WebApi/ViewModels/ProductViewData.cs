using CandyStore.Domain;
using System;

namespace CandyStore.Web.ViewModel
{
  public class ProductViewData
  {
    private ProductViewData()
    {
    }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Наименование товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ед. измерения
    /// </summary>
    public UnitKind Unit { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Остаток на складке
    /// </summary>
    public decimal StockBalance { get; set; }

    public static ProductViewData New(Guid id,
                                      string name,
                                      string description,
                                      UnitKind unit,
                                      decimal price,
                                      decimal stockBalance)
      => new ProductViewData
      {
        Id = id,
        Name = name,
        Description = description,
        Unit = unit,
        Price = price,
        StockBalance = stockBalance
      };
  }
}
