using CandyStore.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Services.Abstractions
{
  public interface ISellerStoreServices
  {
    Task<Seller> GetSellerAsync(Guid sellerId);

    Task<IList<Seller>> GetSellersAsync();

    Task AddSellerAsync(Seller seller);

    Task RemoveSellerAsync(Guid sellerId);

    Task UpdateSellerAsync(Seller seller);
  }
}
