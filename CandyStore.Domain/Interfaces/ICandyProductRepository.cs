using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Domain.Interfaces
{
  public interface ICandyProductRepository
  {
    /// <summary>
    /// Получить список сущностей продукт
    /// </summary>
    /// <returns></returns>
    Task<IList<Product>> FetchProductsAsync();

    /// <summary>
    /// Получить сущность продукт
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task<Product> FetchProductAsync(Guid productId);

    /// <summary>
    /// Добавить сущность продукт
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task AddProductAsync(Product product);

    /// <summary>
    /// Удалить сущность продукт
    /// </summary>
    /// <param name="storeId"></param>
    /// <returns></returns>
    Task RemoveProductAsync(Guid productId);


    /// <summary>
    /// Обновить сущность продукт
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    Task UpdateProductAsync(Product product);
  }
}
