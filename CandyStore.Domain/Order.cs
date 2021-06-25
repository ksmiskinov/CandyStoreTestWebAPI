using Microsoft.EntityFrameworkCore;
using System;

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
    /// ���� �������
    /// </summary>
    public DateTime DateOrder { get; set; }


    public Guid ProductId { get; set; }

    public Product Product { get; set; }
    
    /// <summary>
    /// ���������� ������ 
    /// </summary>
    public int Count { get; set; }


    
    /// <summary>
    /// �������� ������ ������
    /// </summary>
    /// <returns></returns>
    public static Order New()
      => new Order()
      {
       
      };
  }
}
