using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CandyStore.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SellerManagerController : ControllerBase
  {
    private readonly ISellerStoreServices _sellerServices;

    private readonly ISellerManagerViewDataBuilder _sellerManagerViewDataBuilder;
    private readonly ISellerManagerSaveDataBuilder _sellerManagerSaveDataBuilder;

    public SellerManagerController(ISellerStoreServices sellerServices,
                                  ISellerManagerViewDataBuilder sellerManagerViewDataBuilder,
                                  ISellerManagerSaveDataBuilder sellerManagerSaveDataBuilder)
    {
      _sellerServices = sellerServices ?? throw new ArgumentNullException(nameof(ISellerStoreServices));

      _sellerManagerViewDataBuilder = sellerManagerViewDataBuilder ?? throw new ArgumentNullException(nameof(ISellerManagerViewDataBuilder));
      _sellerManagerSaveDataBuilder = sellerManagerSaveDataBuilder ?? throw new ArgumentNullException(nameof(ISellerManagerSaveDataBuilder));
    }

    /// <summary>
    /// Получить список всех магазинов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Sellers")]
    async public Task<IActionResult> GetSellers()
    {
      var sellerViewDataList = await _sellerManagerViewDataBuilder.SellersViewDataBuild();
      return new ObjectResult(sellerViewDataList);
    }

    /// <summary>
    /// Получить состояние конкретного магазина.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Seller")]
    async public Task<IActionResult> GetSeller(Guid sellerId)
    {
      var sellerInfoViewData = await _sellerManagerViewDataBuilder.SellerViewDataBuild(sellerId);
      return new ObjectResult(sellerInfoViewData);
    }

    /// <summary>
    /// Добавить магазин
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("Seller")]
    async public Task<IActionResult> CreateSeller(string name,
                                                  string familyName,
                                                  string middleName,
                                                  Guid storeId)
    {
      var seller = await _sellerManagerSaveDataBuilder.NewSellerSaveBuild(name,
                                                                          familyName,
                                                                          middleName,
                                                                          storeId);
      if (seller == null)
        return new BadRequestResult();

      await _sellerServices.AddSellerAsync(seller);

      return new OkResult();
    }

    /// <summary>
    /// Удалить продовца 
    /// TODO: метод спорный, но удалить то можно, но лучше пометить. Тут речь про неудачного созданного пользователя 
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    [Route("Seller")]
    async public Task<IActionResult> DeleteSeller(Guid sellerId)
    {
      await _sellerServices.RemoveSellerAsync(sellerId);
      return new OkResult();
    }
  }
}
