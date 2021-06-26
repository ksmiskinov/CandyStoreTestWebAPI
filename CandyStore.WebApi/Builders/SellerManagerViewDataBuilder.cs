using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using CandyStore.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Web.Builders
{
  public class SellerManagerViewDataBuilder : ISellerManagerViewDataBuilder
  {

    private readonly ISellerStoreServices _sellerStoreServices;

    public SellerManagerViewDataBuilder(ISellerStoreServices sellerStoreServices) 
      => _sellerStoreServices = sellerStoreServices ?? throw new ArgumentNullException(nameof(ISellerStoreServices));
 
    async Task<IList<SellerViewData>> ISellerManagerViewDataBuilder.SellersViewDataBuild()
    {
      var sellers = await _sellerStoreServices.GetSellersAsync();
      return sellers.Select(x => SellerViewData.New(x.Id,
                                                    x.Name,
                                                    x.FamilyName,
                                                    x.MiddleName,
                                                    x.Store.Name)).ToList();
    }

    async Task<SellerViewData> ISellerManagerViewDataBuilder.SellerViewDataBuild(Guid sellerId)
    {
      var seller = await _sellerStoreServices.GetSellerAsync(sellerId);
      if (seller == null)
        return null;

      return SellerViewData.New(seller.Id,
                                seller.Name,
                                seller.FamilyName,
                                seller.MiddleName,
                                seller.Store.Name);
    }
  }
}
