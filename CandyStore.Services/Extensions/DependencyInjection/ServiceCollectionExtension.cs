using CandyStore.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CandyStore.Services.Extensions.DependencyInjection
{
  public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddCandyStoreServices(this IServiceCollection services)
      => services.AddTransient<IStoreServices, StoreServices>()
                 .AddTransient<ISellerStoreServices, SellerStoreServices>()
                 .AddTransient<ICandyProductServices, CandyProductServices>();
  }
}