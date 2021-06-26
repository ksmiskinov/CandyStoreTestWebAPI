using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CandyStore.Web.ViewModel;

namespace CandyStore.Web.Interfaces
{
  /// <summary>
  /// Подготовка данных для контроллера
  /// </summary>
  public interface IProductManagerViewDataBuilder
  {
    /// <summary>
    /// Получить модель представления списка продуктов
    /// </summary>
    /// <returns></returns>
    Task<IList<ProductViewData>> ProductsViewDataBuild();

    /// <summary>
    /// Получить модель представления продукта
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    Task<ProductViewData> ProductViewDataBuild(Guid productId);
  }
}
