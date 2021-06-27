using System;

namespace CandyStore.Web.ViewModel
{
  public class PostionOrderSaveModel
  {
    private PostionOrderSaveModel()
    {
    }
    
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Количество продуктов 
    /// </summary>
    public int Count { get; set; }
  }
}
