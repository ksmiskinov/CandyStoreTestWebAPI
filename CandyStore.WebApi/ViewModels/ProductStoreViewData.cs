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
    /// ������������ ������
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ��������
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// ��. ���������
    /// </summary>
    public UnitKind Unit { get; set; }

    /// <summary>
    /// ����
    /// </summary>
    public decimal Price { get; set; }
 
    /// <summary>
    /// ������� �� �������
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
