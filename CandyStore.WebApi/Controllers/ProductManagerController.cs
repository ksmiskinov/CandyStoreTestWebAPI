using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CandyStore.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProductManagerController : ControllerBase
  {
    private readonly ICandyProductServices _candyProductServices;

    private readonly IProductManagerViewDataBuilder _productManagerViewDataBuilder;
    private readonly IProductManagerSaveDataBuilder _productManagerSaveDataBuilder;

    public ProductManagerController(ICandyProductServices candyProductServices,
                                  IProductManagerViewDataBuilder productManagerViewDataBuilder,
                                  IProductManagerSaveDataBuilder productManagerSaveDataBuilder)
    {
      _candyProductServices = candyProductServices ?? throw new ArgumentNullException(nameof(IStoreServices));

      _productManagerViewDataBuilder = productManagerViewDataBuilder ?? throw new ArgumentNullException(nameof(IProductManagerViewDataBuilder));
      _productManagerSaveDataBuilder = productManagerSaveDataBuilder ?? throw new ArgumentNullException(nameof(IProductManagerViewDataBuilder));
    }

    /// <summary>
    /// Получить список всех продуктов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Products")]
    async public Task<IActionResult> GetProducts()
    {
      var productViewDataList = await _productManagerViewDataBuilder.ProductsViewDataBuild();
      return new ObjectResult(productViewDataList);
    }

    /// <summary>
    /// Получить продукт.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Product")]
    async public Task<IActionResult> GetProduct(Guid storeId)
    {
      var productInfoViewData = await _productManagerViewDataBuilder.ProductViewDataBuild(storeId);
      return new ObjectResult(productInfoViewData);
    }

    /// <summary>
    /// Добавить продукт
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("Product")]
    async public Task<IActionResult> CreateStore(string name,
                                                 string description,
                                                 UnitKind unit,
                                                 decimal price)
    {
      var product = await _productManagerSaveDataBuilder.NewProductSaveBuild(name,
                                                                             description,
                                                                             unit,
                                                                             price);
      if (product == null)
        return new BadRequestResult();

      await _candyProductServices.AddProductAsync(product);

      return new OkResult();
    }

    /// <summary>
    /// Удалить продукт 
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    [Route("Product")]
    async public Task<IActionResult> DeleteProduct(Guid productId)
    {
      await _candyProductServices.RemoveProductAsync(productId);
      return new OkResult();
    }
  }
}
