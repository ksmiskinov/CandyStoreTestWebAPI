using CandyStore.Data.cs;
using CandyStore.Domain;
using CandyStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Repository
{
  public class SellerStoreRepository : ISellerStoreRepository
  {
    private readonly CandyStoreData _context;

    public SellerStoreRepository(CandyStoreData context)
    {
      _context = context;
    }

    async Task<Seller> ISellerStoreRepository.FetchSellersAsync(Guid sellerId)
    {
      return await _context.Sellers
                         .FirstOrDefaultAsync(x => x.Id == sellerId);
    }

    async Task<IList<Seller>> ISellerStoreRepository.FetchSellerAsync()
    {
      return await _context.Sellers
                         .ToListAsync();
    }
    async Task ISellerStoreRepository.AddStoreAsync(Seller seller)
    {
        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync();
    }

    async Task ISellerStoreRepository.RemoveSellerAsync(Guid sellerId)
    {
      var seller = await _context.Sellers.FirstOrDefaultAsync(x => x.Id == sellerId);
      _context.Sellers.Remove(seller);

      await _context.SaveChangesAsync();
    }

    async Task ISellerStoreRepository.UpdateSellerAsync(Seller seller)
    {
      var sellerOld = await _context.Sellers.FirstOrDefaultAsync(x => x.Id == seller.Id);
      sellerOld.Name = seller.Name;
      sellerOld.MiddleName = seller.MiddleName;
      sellerOld.FamilyName = seller.FamilyName;

      await _context.SaveChangesAsync();
    }
  }
}
