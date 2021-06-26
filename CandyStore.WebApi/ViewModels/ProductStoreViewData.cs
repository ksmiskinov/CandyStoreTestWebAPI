using CandyStore.Domain;
using System;

namespace CandyStore.Web.ViewModel
{
  public class ProductStoreViewData
  {
    private ProductStoreViewData()
    {
    }

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

    public static ProductStoreViewData New(
                                      string name,
                                      string description,
                                      UnitKind unit,
                                      decimal price,
                                      decimal stockBalance)
      => new ProductStoreViewData
      {
        Name = name,
        Description = description,
        Unit = unit,
        Price = price,
        StockBalance = stockBalance
      };
  }
}
