using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using CandyStore.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Web.Builders
{
  public class ProductManagerViewDataBuilder : IProductManagerViewDataBuilder
  {
    private readonly ICandyProductServices _candyProductServices;

    public ProductManagerViewDataBuilder(ICandyProductServices candyProductServices)
      => _candyProductServices = candyProductServices ?? throw new ArgumentNullException(nameof(ICandyProductServices));

    async Task<IList<ProductViewData>> IProductManagerViewDataBuilder.ProductsViewDataBuild()
    {
      var stores = await _candyProductServices.GetProductsAsync();
      return stores.Select(x => ProductViewData.New(x.Id,
                                                    x.Name,
                                                    x.Description,
                                                    x.Unit,
                                                    x.Price)).ToList();
    }

    async Task<ProductViewData> IProductManagerViewDataBuilder.ProductViewDataBuild(Guid productId)
    {
      var store = await _candyProductServices.GetProductAsync(productId);
      if (store == null)
        return null;

      return ProductViewData.New(store.Id,
                                 store.Name,
                                 store.Description,
                                 store.Unit,
                                 store.Price);
    }
  }
}
