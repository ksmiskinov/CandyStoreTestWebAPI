using Microsoft.Extensions.DependencyInjection;
using CandyStore.Web.Builders;
using CandyStore.Web.Interfaces;

namespace CandyStore.Web.ServiceCollectionExtensions
{
  public static class ServiceCollectionExtension
  {
    /// <summary>
    /// Добавить DataBuilders
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDataBuilders(this IServiceCollection services)
      => services.AddTransient<IStoreManagerViewDataBuilder, StoreManagerViewDataBuilder>()
                 .AddTransient<IStoreManagerSaveDataBuilder, StoreManagerSaveDataBuilder>()
                 
                 .AddTransient<ISellerManagerViewDataBuilder, SellerManagerViewDataBuilder>()
                 .AddTransient<ISellerManagerSaveDataBuilder, SellerManagerSaveDataBuilder>()

                 .AddTransient<IProductManagerViewDataBuilder, ProductManagerViewDataBuilder>()
                 .AddTransient<IProductManagerSaveDataBuilder, ProductManagerSaveDataBuilder>();
  }
}
