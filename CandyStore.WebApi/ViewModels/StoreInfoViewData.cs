using System.Collections.Generic;

namespace CandyStore.Web.ViewModel
{
  public class StoreInfoViewData
  {
    private StoreInfoViewData()
    {
    }

    /// <summary>
    /// ������������ ��������
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ������������ ������ ����
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// ������ ������� ��������
    /// </summary>


    //TODO �������� ����� ������� � ��������� ��������
    public static StoreInfoViewData New(string name, string address)
      => new StoreInfoViewData
      {
        Name = name,
        Address = address
      };
  }
}
