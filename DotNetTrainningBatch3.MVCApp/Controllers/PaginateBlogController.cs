using DotNetTrainningBatch3.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainningBatch3.MVCApp.Controllers
{
    public class PaginateBlogController : Controller
    {
        private AppDbContext _appDbContext;

        public PaginateBlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [ActionName("Index")]
        public IActionResult Index(int pageNo = 1, int pageSize = 10)
        {
            List<BlogModel> blogs = _appDbContext.Blogs
                                .Skip((pageNo - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            int rowCount = _appDbContext.Blogs.Count();
            int pageCount = (int)Math.Ceiling((double)rowCount / pageSize);

            BlogPaginatedResponseModel responseModel = new()
            {
                Data = blogs,
                PageCount = pageCount,
                PageNo = pageNo,
                PageSize = pageSize,
            };
            return View("BlogIndex", responseModel);
        }
    }
}
