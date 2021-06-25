using Microsoft.EntityFrameworkCore;
using System;

namespace CandyStore.Domain
{
  /// <summary>
  /// Сущность продавец TODO: так нет понимания для кого это приложение. Будут только продавцы. 
  /// </summary>
  public class Seller
  {
    private Seller() { }

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
    /// Создание нового сотрудника (продавец). 
    /// </summary>
    /// <returns></returns>
    public static Seller New(string name,
                             string familyName,
                             string middleName)
      => new Seller()
      {
        Name = name,
        FamilyName = familyName,
        MiddleName = middleName,
      };
  }
}
