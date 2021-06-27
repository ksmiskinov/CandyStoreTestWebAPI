using System;

namespace CandyStore.Web.ViewModel
{
  public class PostionOrderSaveModel
  {
    private PostionOrderSaveModel()
    {
    }
    
    /// <summary>
    /// ���������� �������������
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// ���������� ��������� 
    /// </summary>
    public int Count { get; set; }
  }
}
