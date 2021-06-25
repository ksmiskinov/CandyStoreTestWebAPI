using System;

namespace CandyStore.Domain
{
  /// <summary>
  /// ��������� ������� ����� � ������.
  /// </summary>

  public class PositionProduct
  {
    private PositionProduct() { }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }


    /// <summary>
    /// ���������� ������������� ��������
    /// </summary>
    public Guid StoreId { get; set; }

    /// <summary>
    /// ���������� �� �������� ������� 
    /// </summary>
    public Store Store { get; set; }

    /// <summary>
    /// ���������� ������������� ��������
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// ���������� �� �������� ������� 
    /// </summary>
    public Product Product { get; set; }


    /// <summary>
    /// ������� �� �������
    /// </summary>
    public int StockBalance { get; set; }

    /// <summary>
    /// �������� ������� �� ������
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
