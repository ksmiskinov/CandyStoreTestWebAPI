using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
      //TODO: Вынести в builder отдельный Controller
      var store = await _storeServices.GetStoreAsync(storeId);
      if (store == null)
        return new BadRequestResult();

      var product = store.PositionProducts.FirstOrDefault(x => x.ProductId == productId);
      if (product != null)
        product.StockBalance = balance;
      else
        store.PositionProducts.Add(PositionProduct.New(storeId, productId, balance));
      await _storeServices.UpdateStoreAsync(store);

      return new OkResult();
    }

  }
}
