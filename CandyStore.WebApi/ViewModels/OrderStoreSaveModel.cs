using System;
using System.Collections.Generic;

namespace CandyStore.Web.ViewModel
{
  public class OrderStoreSaveModel
  {
    private OrderStoreSaveModel()
    {
    }

    /// <summary>
    /// ���������� �������������
    /// </summary>
    public Guid StoreId { get; set; }

    /// <summary>
    /// ������������ ������
    /// </summary>
    public IList<PostionOrderSaveModel> PostionOrders{ get; set; }
  }
}
