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
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

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
