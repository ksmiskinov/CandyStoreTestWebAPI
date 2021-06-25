using System.Collections.Generic;

namespace CandyStore.Web.ViewModel
{
  public class StoreInfoViewData
  {
    private StoreInfoViewData()
    {
    }

    /// <summary>
    /// Наименование магазина
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Наименование колоды карт
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Список позиций продукта
    /// </summary>



    public static StoreInfoViewData New(string name, string address)
      => new StoreInfoViewData
      {
        Name = name,
        Address = address
      };
  }
}
