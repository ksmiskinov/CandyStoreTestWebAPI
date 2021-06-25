using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CandyStore.Web.ViewModel;

namespace CandyStore.Web.Interfaces
{
  /// <summary>
  /// Подготовка данных для контроллера
  /// </summary>
  public interface IStoreManagerViewDataBuilder
  {
    /// <summary>
    /// Получить модель представления списка магазинов
    /// </summary>
    /// <returns></returns>
    Task<IList<StoreViewData>> StoresViewDataBuild();

    /// <summary>
    /// Получить модель представления магазина
    /// </summary>
    /// <param name="storeId"></param>
    /// <returns></returns>
    Task<StoreInfoViewData> StoreViewDataBuild(Guid storeId);
  }
}
