using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using CandyStore.Web.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Web.Builders
{
  public class StoreManagerSaveDataBuilder : IStoreManagerSaveDataBuilder
  {

    private readonly IStoreServices _storeServices;
    private readonly ILogger<StoreManagerSaveDataBuilder> _logger;

    public StoreManagerSaveDataBuilder(ILogger<StoreManagerSaveDataBuilder> logger, IStoreServices storeServices)
    {
      _logger = logger;
      _storeServices = storeServices ?? throw new ArgumentNullException(nameof(IStoreServices));
    }

    async Task<Store> IStoreManagerSaveDataBuilder.NewStoreSaveBuild(string name, string address)
    {
      var stores = await _storeServices.GetStoresAsync();
      if (!stores.Any(x => x.Address.ToLower() == address.ToLower()))
      {
        return Store.New(name, address);
      }
      _logger.LogInformation("NewStoreSaveBuild: Магазин по такому адресу уже существует.");
      return default;
    }

    async Task<Store> IStoreManagerSaveDataBuilder.AddProductPositionSaveBuild(Guid storeId, Guid productId, int balance)
    {
      var store = await _storeServices.GetStoreAsync(storeId);
      if (store == null)
        return default;

    var product = store.PositionProducts.FirstOrDefault(x => x.ProductId == productId);
      if (product != null)
        product.StockBalance = balance;
      else
        store.PositionProducts.Add(PositionProduct.New(storeId, productId, balance));
      return store;
    }


    async Task<Store> IStoreManagerSaveDataBuilder.AddOrderSaveBuild(OrderStoreSaveModel postionOrder)
    {
      var store = await _storeServices.GetStoreAsync(postionOrder.StoreId);
      if (store == null)
        return default;

      foreach (var positionOrder in postionOrder.PostionOrders)
      {
        var positionProduct = store.PositionProducts.FirstOrDefault(x => x.ProductId == positionOrder.ProductId);
        if (positionProduct == null)
          return default;

        if (positionProduct.StockBalance < positionOrder.Count)
          return default;
        positionProduct.StockBalance -= positionOrder.Count;
      }

      var postionOrders = postionOrder.PostionOrders
                                       .Select(x => PositionOrder.New(x.ProductId, x.Count))
                                       .ToList();
      var ordertest = Order.New(postionOrders);
      if (store.Orders == null)
        store.Orders = new List<Order>();
      store.Orders.Add(ordertest);
      return store;
    }
  }
}
