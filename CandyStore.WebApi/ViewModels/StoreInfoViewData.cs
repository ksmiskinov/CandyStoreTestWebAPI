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
    /// Адрес магазина
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Список позиций продукта
    /// </summary>
    public IList<ProductStoreViewData> Products { get; set; }

    public static StoreInfoViewData New(string name, string address, IList<ProductStoreViewData> products)
      => new StoreInfoViewData
      {
        Name = name,
        Address = address,
        Products = products
      };
  }
}
