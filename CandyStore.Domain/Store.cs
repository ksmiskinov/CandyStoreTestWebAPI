using System;
using System.Collections.Generic;

namespace CandyStore.Domain
{
  /// <summary>
  /// Сущность магазин
  /// </summary>
  public class Store
  {
    private Store() { }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Адрес магазина
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Наименование магазина
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Множество позиций разных продуктов 
    /// </summary>
    public IList<PositionProduct> PositionProducts { get; set; }

    /// <summary>
    /// Создание нового магазина
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
