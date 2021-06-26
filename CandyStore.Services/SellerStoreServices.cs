using CandyStore.Domain;
using CandyStore.Domain.Interfaces;
using CandyStore.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Services
{
  public class SellerStoreServices : ISellerStoreServices
  {

    private readonly ISellerStoreRepository _sellerStoreRepository;

    public SellerStoreServices(ISellerStoreRepository sellerStoreRepository)
      => _sellerStoreRepository = sellerStoreRepository ?? throw new ArgumentNullException(nameof(ISellerStoreRepository));

    async Task<IList<Seller>> ISellerStoreServices.GetSellersAsync()
      => await _sellerStoreRepository.FetchSellersAsync();
    
    async Task<Seller> ISellerStoreServices.GetSellerAsync(Guid sellerId)
      => await _sellerStoreRepository.FetchSellerAsync(sellerId);

    async Task ISellerStoreServices.AddSellerAsync(Seller seller)
      => await _sellerStoreRepository.AddStoreAsync(seller);

    async Task ISellerStoreServices.RemoveSellerAsync(Guid sellerId)
      => await _sellerStoreRepository.RemoveSellerAsync(sellerId);

    async Task ISellerStoreServices.UpdateSellerAsync(Seller seller)
       => await _sellerStoreRepository.UpdateSellerAsync(seller);
  }
}
