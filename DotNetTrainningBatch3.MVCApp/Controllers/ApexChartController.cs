using DotNetTrainningBatch3.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainningBatch3.MVCApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartResponseModel apexChartResponseModel = new()
            {
                Series = new List<int> { 10, 2, 5 },
                Labels = new List<string> { "KFC", "LOL", "HELP" }
            };

            return View(apexChartResponseModel);
        }

        public IActionResult DashedLineChart()
        {
            AppDbContext appDbContext = new();
            var dataList = appDbContext.PageStatistics.ToList();
            DashedLineChartResponseModel dashedLineChartResponse = new();

            var sectionDurationsList = dataList.Select(x => x.SessionDuration).ToList();
            var pageViewsList = dataList.Select(x => x.PageViews).ToList();
            var TotalViewsList = dataList.Select(x => x.TotalViews).ToList();
            var DateList = dataList.Select(x=>x.CreatedDate).ToList();

            List<DashedLineChartModel> series = new()
            {
                new DashedLineChartModel { name = "Section Duration", data =sectionDurationsList },
                new DashedLineChartModel { name = "Page Views", data =pageViewsList },
                new DashedLineChartModel { name = "Total Views", data =TotalViewsList },

            };

            dashedLineChartResponse.Series = series;
            dashedLineChartResponse.Labels = DateList;

            return View(dashedLineChartResponse);
        }

        public IActionResult RadarChart()
        {
            AppDbContext context = new();
            var radarDataList = context.Radars.ToList();
            ApexChartResponseModel responseModel = new()
            {
                Series = radarDataList.Select(x => x.Series).ToList(),
                Labels = radarDataList.Select(x => x.Month).ToList()
            };
            return View(responseModel);
        }
    }
}
