using System;

namespace CandyStore.Web.ViewModel
{
  /// <summary>
  /// Модель представления продавца 
  /// </summary>
  public class SellerViewData
  {
    private SellerViewData()
    {
    }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string FamilyName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// Наименование магазин 
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
