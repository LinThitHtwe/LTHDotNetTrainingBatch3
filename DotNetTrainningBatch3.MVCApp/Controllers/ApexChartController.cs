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
    }
}
