using System;

namespace CandyStore.Web.ViewModel
{
  /// <summary>
  /// ������ ������������� �������� 
  /// </summary>
  public class SellerViewData
  {
    private SellerViewData()
    {
    }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ���
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// �������
    /// </summary>
    public string FamilyName { get; set; }

    /// <summary>
    /// ��������
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// ������������ ������� 
    /// </summary>
    public string StoreName { get; set; }

    public static SellerViewData New(Guid id, string name, string familyName, string middleName, string storeName)
      => new SellerViewData
      {
        Id = id,
        Name = name,
        FamilyName = familyName,
        MiddleName = middleName,
        StoreName = storeName,
      };
  }
}
