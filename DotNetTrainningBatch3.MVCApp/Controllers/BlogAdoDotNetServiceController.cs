using DotNetTrainningBatch3.MVCApp.Models;
using DotNetTrainningBatch3.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainningBatch3.MVCApp.Controllers
{
    public class BlogAdoDotNetServiceController : Controller
    {
        private readonly AdoDotNetService _adoDotNetService;

        public BlogAdoDotNetServiceController(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }
        public IActionResult Index()
        {
            var blogLists = _adoDotNetService.Query<BlogModel>("select * from Blog2");
            return View(blogLists);
        }

    }
}
