using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using CandyStore.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Web.Builders
{
  public class StoreManagerViewDataBuilder : IStoreManagerViewDataBuilder
  {

    private readonly IStoreServices _storeServices;

    public StoreManagerViewDataBuilder(IStoreServices storeServices) 
      => _storeServices = storeServices ?? throw new ArgumentNullException(nameof(IStoreServices));
 
    async Task<IList<StoreViewData>> IStoreManagerViewDataBuilder.StoresViewDataBuild()
    {
      var stores = await _storeServices.GetStoresAsync();
      return stores.Select(x => StoreViewData.New(x.Id, x.Name)).ToList();
    }

    async Task<StoreInfoViewData> IStoreManagerViewDataBuilder.StoreViewDataBuild(Guid storeId)
    {
      var store = await _storeServices.GetStoreAsync(storeId);
      if (store == null)
        return null;

      return StoreInfoViewData.New(store.Name,
                                  store.Address,
                                  store.PositionProducts.Select(x=>ProductStoreViewData.New(x.Product.Name,
                                                                                            x.Product.Description,
                                                                                            x.Product.Unit,
                                                                                            x.Product.Price,
                                                                                            x.StockBalance)).ToList()
                                  );
    }
  }
}
