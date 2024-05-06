using DotNetTrainningBatch3.MVCApp.Models;
using DotNetTrainningBatch3.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainningBatch3.MVCApp.Controllers
{
    public class BlogDapperServiceController : Controller
    {
        private readonly DapperService _dapperService;

        public BlogDapperServiceController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public IActionResult Index()
        {
            var blogs = _dapperService.Query<BlogModel>("select * from Blog2");
            return View(blogs);
        }
    }
}
