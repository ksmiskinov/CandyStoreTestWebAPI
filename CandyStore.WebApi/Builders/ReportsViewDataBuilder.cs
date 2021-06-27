using CandyStore.Domain;
using CandyStore.Services.Abstractions;
using CandyStore.Web.Interfaces;
using CandyStore.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Web.Builders
{
  public class ReportsViewDataBuilder : IReportsViewDataBuilder
  {

    private readonly IStoreServices _storeServices;

    public ReportsViewDataBuilder(IStoreServices storeServices)
      => _storeServices = storeServices ?? throw new ArgumentNullException(nameof(IStoreServices));

    async Task<ReportSalesViewModel> IReportsViewDataBuilder.ReportSales(DateTime startDate, DateTime endDate)
    {
      var stores = await _storeServices.GetStoresAsync();

      var reportSalesItems = new List<ReportSalesItemViewModel>();
      foreach (var st in stores)
      {
        foreach (var ord in st.Orders)
        {
          foreach (var po in ord.PositionOrders)
          {
            //TODO: Необходимо создать отдельный ReportRepositories  и отдельный метод с датами в запросе к БД.
            if (ord.DateOrder >= startDate && ord.DateOrder <= endDate)
              reportSalesItems.Add(ReportSalesItemViewModel.New(st.Name,
                                                                ord.DateOrder,
                                                                po.Product.Name,
                                                                (int)po.Product.Unit,
                                                                po.Count,
                                                                po.Product.Price,
                                                                po.Count * po.Product.Price));
          }
        }
      }

      return ReportSalesViewModel.New(reportSalesItems.Sum(x => x.TotalPrice),
                                      reportSalesItems.OrderBy(x => x.DateOrder).ToList());
    }
  }
}
