using CandyStore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CandyStore.Domain
{
  public class Product
  {
    private Product() { }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Наименование товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }


    /// <summary>
    /// Ед. измерения
    /// </summary>
    public UnitKind Unit { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }


    /// <summary>
    /// Множество позиций в разных магазинах
    /// </summary>
    public IList<PositionProduct> PositionProducts { get; set; }


    /// <summary>
    /// Создать продукт
    /// </summary>
    /// <returns></returns>
    public static Product New(string name,
                              string description,
                              UnitKind unit,
                              decimal price)
      => new Product()
      {
        Name = name,
        Description = description,
        Unit = unit,
        Price = price
      };

  }
}
