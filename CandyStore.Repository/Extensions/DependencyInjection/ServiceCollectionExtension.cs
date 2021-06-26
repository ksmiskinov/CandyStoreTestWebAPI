using CandyStore.Domain.Interfaces;
using CandyStore.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CandyStore.Services.Extensions.DependencyInjection
{
  public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddCandyStoreRepositories(this IServiceCollection services)
       => services
         .AddTransient<IStoreRepository, StoreRepository>()
         .AddTransient<ISellerStoreRepository, SellerStoreRepository>();
  }
}