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
    /// Уникальный идентификатор
    /// </summary>
    public Guid StoreId { get; set; }

    /// <summary>
    /// Наименование товара
    /// </summary>
    public IList<PostionOrderSaveModel> PostionOrders{ get; set; }
  }
}
