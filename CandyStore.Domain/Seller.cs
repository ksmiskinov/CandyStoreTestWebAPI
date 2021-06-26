using Microsoft.EntityFrameworkCore;
using System;

namespace CandyStore.Domain
{
  /// <summary>
  /// �������� �������� TODO: ��� ��� ��������� ��� ���� ��� ����������. ����� ������ ��������. 
  /// </summary>
  public class Seller
  {
    private Seller() { }

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
    /// ������� ��������� � ������������ ��������
    /// </summary>
    public Guid StoreId { get; set; }


    /// <summary>
    /// ���������� � ��������� ������� 
    /// </summary>
    public Store Store { get; set; }

    /// <summary>
    /// �������� ������ ���������� (��������). 
    /// </summary>
    /// <returns></returns>
    public static Seller New(string name,
                             string familyName,
                             string middleName,
                             Guid storeId)
      => new Seller()
      {
        Name = name,
        FamilyName = familyName,
        MiddleName = middleName,
        StoreId = storeId,
      };
  }
}
