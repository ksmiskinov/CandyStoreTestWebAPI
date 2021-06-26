using System;
using System.Collections.Generic;

namespace CandyStore.Domain
{
  /// <summary>
  /// �������� �������
  /// </summary>
  public class Store
  {
    private Store() { }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ����� ��������
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// ������������ ��������
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ��������� ������� ������ ��������� 
    /// </summary>
    public IList<PositionProduct> PositionProducts { get; set; }

    /// <summary>
    /// �������� ������ ��������
    /// </summary>
    /// <returns></returns>
    public static Store New(string name, string address)
      => new Store()
      {
        Address = address,
        Name = name,
      };
  }
}
