using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Web.Builders
{
  public class StoreManagerSaveDataBuilder : IStoreManagerSaveDataBuilder
  {

    private readonly IStoreServices _storeServices;
    private readonly ILogger<StoreManagerSaveDataBuilder> _logger;

    public StoreManagerSaveDataBuilder(ILogger<StoreManagerSaveDataBuilder> logger, IStoreServices storeServices)
    {
      _logger = logger;
      _storeServices = storeServices ?? throw new ArgumentNullException(nameof(IStoreServices));
    }

    async Task<Store> IStoreManagerSaveDataBuilder.NewStoreSaveBuild(string name, string address)
    {
      var stores = await _storeServices.GetStoresAsync();
      if (!stores.Any(x => x.Address.ToLower() == address.ToLower()))
      {
        return Store.New(name, address);
      }
      _logger.LogInformation("NewStoreSaveBuild: Магазин по такому адресу уже существует.");
      return default;
    }
  }
}
