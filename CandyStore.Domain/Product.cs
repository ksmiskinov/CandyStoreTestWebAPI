using CandyStore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CandyStore.Domain
{
  public class Product
  {
    private Product() { }

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
    /// ��������� ������� � ������ ���������
    /// </summary>
    public IList<PositionProduct> PositionProducts { get; set; }


    /// <summary>
    /// ������� �������
    /// </summary>
    /// <returns></returns>
    public static Product New(string name,
                              string description,
                              UnitKind unit,
                              decimal price)
      => new Product()
      {
        Name = name,
        Description = description,
        Unit = unit,
        Price = price
      };

  }
}
