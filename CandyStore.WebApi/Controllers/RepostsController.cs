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
  public class RepostsController : ControllerBase
  {
    private readonly IReportsViewDataBuilder _reportsViewDataBuilder;

    public RepostsController(IReportsViewDataBuilder reportsViewDataBuilder)
    {
      _reportsViewDataBuilder = reportsViewDataBuilder ?? throw new ArgumentNullException(nameof(IReportsViewDataBuilder));
    }

    /// <summary>
    /// Получить данные для отчета "Отчет по продажам" 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("ReportSales")]
    [ProducesResponseType(typeof(IList<ReportSalesViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    async public Task<IActionResult> GetReportSales(DateTime startDate, DateTime endDate)
    {
      var reportResult = await _reportsViewDataBuilder.ReportSales(startDate, endDate);
      return new ObjectResult(reportResult);
    }
  }
}
