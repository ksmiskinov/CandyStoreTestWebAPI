using CandyStore.Domain;
using CandyStore.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandyStore.Web.Interfaces
{
  /// <summary>
  /// Подготовка данных для отчетности
  /// </summary>
  public interface IReportsViewDataBuilder
  {
    /// <summary>
    /// Отчет по продажам
    /// </summary>
    /// <param name="startDate">Дата начала отчетного периода</param>
    /// <param name="endDate">Дата окончания отчетного периода </param>
    /// <returns></returns>
    Task<ReportSalesViewModel> ReportSales(DateTime startDate, DateTime endDate);
  }
}
