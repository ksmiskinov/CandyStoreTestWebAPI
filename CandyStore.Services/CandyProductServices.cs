using CandyStore.Domain;
using CandyStore.Domain.Interfaces;
using CandyStore.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Services
{
  public class CandyProductServices : ICandyProductServices
  {

    private readonly ICandyProductRepository _candyProductRepository;

    public CandyProductServices(ICandyProductRepository candyProductRepository)
      => _candyProductRepository = candyProductRepository ?? throw new ArgumentNullException(nameof(ICandyProductServices));

    async Task<IList<Product>> ICandyProductServices.GetProductsAsync()
      => await _candyProductRepository.FetchProductsAsync();
    
    async Task<Product> ICandyProductServices.GetProductAsync(Guid productId)
      => await _candyProductRepository.FetchProductAsync(productId);

    async Task ICandyProductServices.AddProductAsync(Product product)
      => await _candyProductRepository.AddProductAsync(product);

    async Task ICandyProductServices.RemoveProductAsync(Guid productId)
      => await _candyProductRepository.RemoveProductAsync(productId);

    async Task ICandyProductServices.UpdateProductAsync(Product product)
       => await _candyProductRepository.UpdateProductAsync(product);
  }
}
