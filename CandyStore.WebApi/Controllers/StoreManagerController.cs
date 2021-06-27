using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using CandyStore.Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    [ProducesResponseType(typeof(IList<StoreViewData>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(typeof(StoreViewData), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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
    async public Task<IActionResult> CreateStore(string name, string address)
    {
      var store = await _storeManagerSaveDataBuilder.NewStoreSaveBuild(name, address);
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


    /// <summary>
    /// Добавить позицию продукта 
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("ProductPositionStore")]
    async public Task<IActionResult> AddProductPositionStore(Guid storeId, Guid productId, int balance )
    {
      //TODO: AddProductPositionStore Вынести в отдельный Controller
      var store = await _storeManagerSaveDataBuilder.AddProductPositionSaveBuild(storeId, productId, balance);
      if (store == null)
        return new BadRequestResult();
      
      await _storeServices.UpdateStoreAsync(store);

      return new OkResult();
    }

    /// <summary>
    /// Добавить/оформить заказ 
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("Order")]
    async public Task<IActionResult> AddOrderStore(OrderStoreSaveModel postionOrder)
    {
      //TODO: Вынести в отдельный Controller
      var store = await _storeManagerSaveDataBuilder.AddOrderSaveBuild(postionOrder);
      if (store == null)
        return new BadRequestResult();

      await _storeServices.UpdateStoreAsync(store);

      return new OkResult();
    }

  }
}
