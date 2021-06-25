using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CandyStore.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class StoreManagerController : ControllerBase
  {
    private readonly IStoreServices _storeServices;

    private readonly IStoreManagerViewDataBuilder _storeManagerViewDataBuilder;
    private readonly IStoreManagerSaveDataBuilder _storeManagerSaveDataBuilder;

    public StoreManagerController(IStoreServices storeServices,
                                  IStoreManagerViewDataBuilder storeManagerViewDataBuilder,
                                  IStoreManagerSaveDataBuilder storeManagerSaveDataBuilder)
    {
      _storeServices = storeServices ?? throw new ArgumentNullException(nameof(IStoreServices));

      _storeManagerViewDataBuilder = storeManagerViewDataBuilder ?? throw new ArgumentNullException(nameof(IStoreManagerViewDataBuilder));
      _storeManagerSaveDataBuilder = storeManagerSaveDataBuilder ?? throw new ArgumentNullException(nameof(IStoreManagerSaveDataBuilder));
    }

    /// <summary>
    /// Получить список всех магазинов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Stores")]
    async public Task<IActionResult> GetStores()
    {
      var storeViewDataList = await _storeManagerViewDataBuilder.StoresViewDataBuild();
      return new ObjectResult(storeViewDataList);
    }

    /// <summary>
    /// Получить состояние конкретного магазина.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Store")]
    async public Task<IActionResult> GetStore(Guid storeId)
    {
      var storeInfoViewData = await _storeManagerViewDataBuilder.StoreViewDataBuild(storeId);
      return new ObjectResult(storeInfoViewData);
    }

    /// <summary>
    /// Добавить магазин
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("Store")]
    async public Task<IActionResult> CreateStore(string name, string adress)
    {
      var store = await _storeManagerSaveDataBuilder.NewStoreSaveBuild(name, adress);
      if (store == null)
        return new BadRequestResult();

      await _storeServices.AddStoreAsync(store);

      return new OkResult();
    }
 
    /// <summary>
    /// Удалить магазин (метод спорный, но удалить то можно)
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    [Route("Store")]
    async public Task<IActionResult> DeleteStore(Guid storeId)
    {
      await _storeServices.RemoveStoreAsync(storeId);
      return new OkResult();
    }
  }
}
