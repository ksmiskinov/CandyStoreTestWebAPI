using CandyStore.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Web.Interfaces
{
  /// <summary>
  /// Подготовка данных для контроллера
  /// </summary>
  public interface ISellerManagerViewDataBuilder
  {
    /// <summary>
    /// Получить модель представления списка продовцов
    /// </summary>
    /// <returns></returns>
    Task<IList<SellerViewData>> SellersViewDataBuild();

    /// <summary>
    /// Получить модель представления продовец
    /// </summary>
    /// <param name="sellerId"></param>
    /// <returns></returns>
    Task<SellerViewData> SellerViewDataBuild(Guid sellerId);
  }
}
