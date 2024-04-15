using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainningBatch3.MVCApp.Controllers
{
    public class BlogController : Controller
    {
        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            return View("BlogIndex");
        }
    }
}
