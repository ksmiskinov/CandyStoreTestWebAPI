using CandyStore.Domain;
using System;
using System.Threading.Tasks;

namespace CandyStore.Web.Interfaces
{
  /// <summary>
  /// Подготовка данных для обновления сущности
  /// </summary>
  public interface ISellerManagerSaveDataBuilder
  {
    /// <summary>
    /// Добавить новую сущность продовец
    /// </summary>
    /// <param name="name"> Имя </param>
    /// <param name="familyName"> Фамилия </param>
    /// <param name="middleName"> Отчество</param>
    /// <param name="storeId"> Уникальный идентификатор магазина в котором работает продавец</param>
    /// <returns></returns>
    Task<Seller> NewSellerSaveBuild(string name,
                                   string familyName,
                                   string middleName,
                                   Guid storeId);
  }
}
