using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CandyStore.Web.ServiceCollectionExtensions;
using CandyStore.Services.Extensions.DependencyInjection;
using CandyStore.Data.cs;

namespace CandyStore.Web
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      string connection = Configuration.GetConnectionString("DefaultConnection");

      services.AddDbContext<CandyStoreData>(options =>
          options.UseSqlServer(connection));

     
      services.AddControllers();
      services.AddSwaggerGen(); 

      services.AddCandyStoreRepositories();

      services.AddCandyStoreServices();

      services.AddDataBuilders();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(sw => { sw.SwaggerEndpoint("../swagger/v1/swagger.json", "TestCandyStoreWebApi"); });
      }

      //app.UseHttpsRedirection();

      app.UseRouting();

      //app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
