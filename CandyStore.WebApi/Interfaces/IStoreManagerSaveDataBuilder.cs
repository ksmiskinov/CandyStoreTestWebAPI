using CandyStore.Domain;
using System.Threading.Tasks;

namespace CandyStore.Web.Interfaces
{
  /// <summary>
  /// Подготовка данных для обновления сущности
  /// </summary>
  public interface IStoreManagerSaveDataBuilder
  {
    /// <summary>
    /// Добавить новую сущность магазин
    /// </summary>
    /// <param name="name">Наименование магазина</param>
    /// <param name="adress">Адрес магазина</param>
    /// <returns></returns>
    Task<Store> NewStoreSaveBuild(string name, string address);
  }
}
