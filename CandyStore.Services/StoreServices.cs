using CandyStore.Domain;
using CandyStore.Domain.Interfaces;
using CandyStore.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Services
{
  public class StoreServices : IStoreServices
  {

    private readonly IStoreRepository _storeRepository;

    public StoreServices(IStoreRepository storeRepository)
      => _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(IStoreRepository));

    async Task<IList<Store>> IStoreServices.GetStoresAsync()
      => await _storeRepository.FetchStoresAsync();
    
    async Task<Store> IStoreServices.GetStoreAsync(Guid storeId)
      => await _storeRepository.FetchStoreAsync(storeId);

    async Task IStoreServices.AddStoreAsync(Store store)
      => await _storeRepository.AddStoreAsync(store);

    async Task IStoreServices.RemoveStoreAsync(Guid storeId)
      => await _storeRepository.RemoveStoreAsync(storeId);

    async Task IStoreServices.UpdateStoreAsync(Store store)
       => await _storeRepository.UpdateStoreAsync(store);
  }
}
