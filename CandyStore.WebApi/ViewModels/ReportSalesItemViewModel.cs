using System;

namespace CandyStore.Web.ViewModel
{
  public class ReportSalesItemViewModel
  {
    private ReportSalesItemViewModel()
    {
    }

    /// <summary>
    /// ������������ ��������
    /// </summary>
    public string StoreName { get; set; }

    /// <summary>
    /// ���� ������
    /// </summary>
    public DateTime DateOrder { get; set; }

    /// <summary>
    /// ����������� ��������
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// ��. ���������
    /// </summary>
    public int Unit { get; set; }

    /// <summary>
    /// �����������
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// ���� �� �����
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// ����� 
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
