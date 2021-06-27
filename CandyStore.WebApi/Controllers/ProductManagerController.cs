using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using CandyStore.Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    [ProducesResponseType(typeof(IList<ProductViewData>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(typeof(ProductViewData), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    async public Task<IActionResult> GetProduct(Guid productId)
    {
      var productInfoViewData = await _productManagerViewDataBuilder.ProductViewDataBuild(productId);
      return new ObjectResult(productInfoViewData);
    }

    /// <summary>
    /// Добавить продукт
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("Product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    async public Task<IActionResult> DeleteProduct(Guid productId)
    {
      await _candyProductServices.RemoveProductAsync(productId);
      return new OkResult();
    }
  }
}
