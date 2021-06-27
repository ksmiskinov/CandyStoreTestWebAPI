using System;

namespace CandyStore.Domain
{
  /// <summary>
  /// ��������� ������� ������ � ������.
  /// </summary>

  public class PositionOrder
  {
    private PositionOrder() { }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }


    /// <summary>
    /// ���������� ������������� ��������
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// ���������� �� �������� ����� 
    /// </summary>
    public Order Order { get; set; }

    /// <summary>
    /// ���������� ������������� ��������
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// ���������� �� �������� ������� 
    /// </summary>
    public Product Product { get; set; }


    /// <summary>
    /// �����������
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// �������� ������� �� ������
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
    /// �������� ������� �� ������
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
