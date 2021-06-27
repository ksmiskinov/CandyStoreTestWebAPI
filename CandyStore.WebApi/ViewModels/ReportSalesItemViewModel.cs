using System;

namespace CandyStore.Web.ViewModel
{
  public class ReportSalesItemViewModel
  {
    private ReportSalesItemViewModel()
    {
    }

    /// <summary>
    /// Наименование магазина
    /// </summary>
    public string StoreName { get; set; }

    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime DateOrder { get; set; }

    /// <summary>
    /// Нименование продукта
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Ед. измерения
    /// </summary>
    public int Unit { get; set; }

    /// <summary>
    /// Колличество
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Цена за штуку
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Всего 
    /// </summary>
    public decimal TotalPrice { get; set; }

    public static ReportSalesItemViewModel New(string storeName,
                                               DateTime dateOrder,
                                               string productName,
                                               int unit,
                                               int count,
                                               decimal unitPrice,
                                               decimal totalPrice)
      => new ReportSalesItemViewModel
      {
        StoreName = storeName,
        DateOrder = dateOrder,
        ProductName = productName,
        Unit = unit,
        Count = count,
        UnitPrice = unitPrice,
        TotalPrice = totalPrice
      };
  }
}
