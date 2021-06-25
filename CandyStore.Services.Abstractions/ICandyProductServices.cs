using CandyStore.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Services.Abstractions
{

  public interface ICandyProductServices
  {
    Task<Product> GetProductAsync(Guid productId);

    Task<IList<Product>> GetProductsAsync();

    Task AddProductAsync(Product product);

    Task RemoveProductAsync(Guid productId);

    Task UpdateProductAsync(Product product);
  }
}
