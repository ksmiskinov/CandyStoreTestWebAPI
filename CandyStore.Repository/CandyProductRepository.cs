using CandyStore.Data.cs;
using CandyStore.Domain;
using CandyStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Repository
{
  public class CandyProductRepository : ICandyProductRepository
  {
    private readonly CandyStoreData _context;

    public CandyProductRepository(CandyStoreData context)
    {
      _context = context;
    }

    async Task<Product> ICandyProductRepository.FetchProductAsync(Guid productId)
    {
      return await _context.Products
                           .Include(x=>x.PositionProducts)
                           .ThenInclude(x=>x.Store)
                           .FirstOrDefaultAsync(x => x.Id == productId);
    }

    async Task<IList<Product>> ICandyProductRepository.FetchProductsAsync()
    {
      return await _context.Products
                           .Include(x => x.PositionProducts)
                           .ThenInclude(x => x.Store)
                           .ToListAsync();
    }
    async Task ICandyProductRepository.AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    async Task ICandyProductRepository.RemoveProductAsync(Guid productId)
    {
      var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
      _context.Products.Remove(product);

      await _context.SaveChangesAsync();
    }

    async Task ICandyProductRepository.UpdateProductAsync(Product product)
    {
      var productOld = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
      productOld.Name = product.Name;
      productOld.Price = product.Price;
      productOld.Unit = product.Unit;
      productOld.PositionProducts = product.PositionProducts;

      await _context.SaveChangesAsync();
    }
  }
}
