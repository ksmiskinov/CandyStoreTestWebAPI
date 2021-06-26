using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Web.Builders
{
  public class SellerManagerSaveDataBuilder : ISellerManagerSaveDataBuilder
  {

    private readonly ISellerStoreServices _sellerStoreServices;
    private readonly ILogger<SellerManagerSaveDataBuilder> _logger;

    public SellerManagerSaveDataBuilder(ILogger<SellerManagerSaveDataBuilder> logger, ISellerStoreServices sellerStoreServices)
    {
      _logger = logger;
      _sellerStoreServices = sellerStoreServices ?? throw new ArgumentNullException(nameof(IStoreServices));
    }

    async Task<Seller> ISellerManagerSaveDataBuilder.NewSellerSaveBuild(string name,
                                                                        string familyName,
                                                                        string middleName,
                                                                        Guid storeId)
    {
      var stores = await _sellerStoreServices.GetSellersAsync();
      if (!stores.Any(x => x.FamilyName.ToLower() == familyName.ToLower() &&
      x.Name.ToLower() == name.ToLower() &&
      x.MiddleName.ToLower() == middleName.ToLower()))
      {
        return Seller.New(name,
                          familyName,
                          middleName,
                          storeId);
      }
      _logger.LogInformation("NewSellerSaveBuild: Продавец по такому адресу уже существует.");
      return default;
    }
  }
}
