using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CandyStore.Domain
{
  /// <summary>
  /// ������
  /// </summary>
  public class Order
  {
    private Order() { }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ���� ������
    /// </summary>
    public DateTime DateOrder { get; set; }

    ///// <summary>
    ///// ���������� ������������� �������
    ///// </summary>
    //public Guid SellerId { get; set; }

    ///// <summary>
    ///// ��������
    ///// </summary>
    //public Seller Seller { get; set; }

    /// <summary>
    /// ������� ������
    /// </summary>
    public IList<PositionOrder> PositionOrders { get; set; }
 
    /// <summary>
    /// �������� ������ ������
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
