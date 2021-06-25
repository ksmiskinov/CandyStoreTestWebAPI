using CandyStore.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Services.Abstractions
{
  public interface IStoreServices
  {
    Task<Store> GetStoreAsync(Guid storeId);

    Task<IList<Store>> GetStoresAsync();

    Task AddStoreAsync(Store store);

    Task RemoveStoreAsync(Guid storeId);

    Task UpdateStoreAsync(Store store);
  }
}
