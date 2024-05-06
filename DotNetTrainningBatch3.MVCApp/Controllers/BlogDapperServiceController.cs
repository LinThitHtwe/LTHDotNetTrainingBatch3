using DotNetTrainningBatch3.MVCApp.Models;
using DotNetTrainningBatch3.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainningBatch3.MVCApp.Controllers
{
    public class BlogDapperServiceController : Controller
    {
        private readonly DapperService _dapperService;
        private readonly CommonService _commonService;

        public BlogDapperServiceController(DapperService dapperService, CommonService commonService)
        {
            _dapperService = dapperService;
            _commonService = commonService;
        }

        public IActionResult Index()
        {
            var result = _commonService.Sum(1, 2);
            var blogs = _dapperService.Query<BlogModel>("select * from Blog2");
            return View(blogs);
        }
    }
}
