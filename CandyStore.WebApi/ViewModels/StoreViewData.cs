using System;

namespace CandyStore.Web.ViewModel
{
  public class StoreViewData
  {
    private StoreViewData()
    {
    }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ������������ ��������
    /// </summary>
    public string Name { get; set; }

    public static StoreViewData New(Guid id, string name)
      => new StoreViewData
      {
        Id = id,
        Name = name,
      };
  }
}
