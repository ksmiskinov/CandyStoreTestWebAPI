using System;
using System.Collections.Generic;

namespace CandyStore.Web.ViewModel
{
  public class ReportSalesViewModel
  {
    private ReportSalesViewModel()
    {
    }

    /// <summary>
    /// ����� �� ������.
    /// </summary>
    public Decimal Total { get; set; }

    /// <summary>
    /// ������� �������
    /// </summary>
    public IList<ReportSalesItemViewModel> Items{ get; set; }

    public static ReportSalesViewModel New(decimal total, IList<ReportSalesItemViewModel> items)
     => new ReportSalesViewModel
     {
       Items=items,
       Total = total
     };
  }
}
