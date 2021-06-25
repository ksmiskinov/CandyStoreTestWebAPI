using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Domain.Interfaces
{
  public interface IStoreRepository
  {
    /// <summary>
    /// Получить список сущностей Магазин
    /// </summary>
    /// <returns></returns>
    Task<IList<Store>> FetchStoresAsync();

    /// <summary>
    /// Получить сущность Магазин
    /// </summary>
    /// <param name="storeId"></param>
    /// <returns></returns>
    Task<Store> FetchStoreAsync(Guid storeId);

    /// <summary>
    /// Добавить сущность магазин
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    Task AddStoreAsync(Store store);

    /// <summary>
    /// Удалить сущность магазин
    /// </summary>
    /// <param name="storeId"></param>
    /// <returns></returns>
    Task RemoveStoreAsync(Guid storeId);


    /// <summary>
    /// Обновить сущность магазин
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    Task UpdateStoreAsync(Store store);
  }
}
