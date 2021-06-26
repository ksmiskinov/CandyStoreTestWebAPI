using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Domain.Interfaces
{
  public interface ISellerStoreRepository
  {
    /// <summary>
    /// Получить список сущностей Продовец
    /// </summary>
    /// <returns></returns>
    Task<IList<Seller>> FetchSellersAsync();

    /// <summary>
    /// Получить сущность Продовец
    /// </summary>
    /// <param name="sellerId"></param>
    /// <returns></returns>
    Task<Seller> FetchSellerAsync(Guid sellerId);

    /// <summary>
    /// Добавить сущность Продовец
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    Task AddStoreAsync(Seller store);

    /// <summary>
    /// Удалить сущность Продовец
    /// </summary>
    /// <param name="sellerId"></param>
    /// <returns></returns>
    Task RemoveSellerAsync(Guid sellerId);


    /// <summary>
    /// Обновить сущность Продовец
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    Task UpdateSellerAsync(Seller seller);
  }
}
