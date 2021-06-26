using CandyStore.Data.cs;
using CandyStore.Domain;
using CandyStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Repository
{
  public class StoreRepository : IStoreRepository
  {
    private readonly CandyStoreData _context;

    public StoreRepository(CandyStoreData context)
    {
      _context = context;
    }

    async Task<Store> IStoreRepository.FetchStoreAsync(Guid storeId)
    {
      return await _context.Stores
                           .Include(x=>x.PositionProducts)
                           .ThenInclude(x=>x.Product)
                           .FirstOrDefaultAsync(x => x.Id == storeId);
    }

    async Task<IList<Store>> IStoreRepository.FetchStoresAsync()
    {
      return await _context.Stores
                           .Include(x => x.PositionProducts)
                           .ThenInclude(x => x.Product)
                           .ToListAsync();
    }
    async Task IStoreRepository.AddStoreAsync(Store store)
    {
        _context.Stores.Add(store);
        await _context.SaveChangesAsync();
    }

    async Task IStoreRepository.RemoveStoreAsync(Guid storeId)
    {
      var store = await _context.Stores
                                .FirstOrDefaultAsync(x => x.Id == storeId);
      _context.Stores.Remove(store);

      await _context.SaveChangesAsync();
    }

    async Task IStoreRepository.UpdateStoreAsync(Store store)
    {
      var storeOld = await _context.Stores
                                   .FirstOrDefaultAsync(x => x.Id == store.Id);
      storeOld.Name = store.Name;
      storeOld.Address = store.Address;

      await _context.SaveChangesAsync();
    }
  }
}
