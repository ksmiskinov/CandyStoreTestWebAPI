using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Web.Builders
{
  public class ProductManagerSaveDataBuilder : IProductManagerSaveDataBuilder
  {

    private readonly ICandyProductServices _candyProductServices;
    private readonly ILogger<StoreManagerSaveDataBuilder> _logger;

    public ProductManagerSaveDataBuilder(ILogger<StoreManagerSaveDataBuilder> logger, ICandyProductServices candyProductServices)
    {
      _logger = logger;
      _candyProductServices = candyProductServices ?? throw new ArgumentNullException(nameof(ICandyProductServices));
    }

    async Task<Product> IProductManagerSaveDataBuilder.NewProductSaveBuild(string name, string description, UnitKind unit, decimal price)
    {
      var stores = await _candyProductServices.GetProductsAsync();
      if (!stores.Any(x => x.Name.ToLower() == name.ToLower()))
      {
        return Product.New(name, description, unit, price);
      }
      _logger.LogInformation("NewProductSaveBuild: Продукт с таким наименованием уже существует.");
      return default;
    }
  }
}
