using System.Collections.Generic;

namespace CandyStore.Web.ViewModel
{
  public class StoreInfoViewData
  {
    private StoreInfoViewData()
    {
    }

    /// <summary>
    /// Ќаименование магазина
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Ќаименование колоды карт
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// —писок позиций продукта
    /// </summary>


    //TODO добавить вывод товаров в конкртном магазине
    public static StoreInfoViewData New(string name, string address)
      => new StoreInfoViewData
      {
        Name = name,
        Address = address
      };
  }
}
