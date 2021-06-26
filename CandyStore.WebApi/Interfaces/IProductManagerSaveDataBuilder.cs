using CandyStore.Domain;
using System.Threading.Tasks;

namespace CandyStore.Web.Interfaces
{
  /// <summary>
  /// Подготовка данных для обновления сущности
  /// </summary>
  public interface IProductManagerSaveDataBuilder
  {
    /// <summary>
    /// Получить новую сущность продукт
    /// </summary>
    /// <returns></returns>
    Task<Product> NewProductSaveBuild(string name,
                                      string description,
                                      UnitKind unit,
                                      decimal price);
  }
}
