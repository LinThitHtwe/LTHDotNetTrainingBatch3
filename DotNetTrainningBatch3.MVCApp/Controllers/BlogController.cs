using DotNetTrainningBatch3.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainningBatch3.MVCApp.Controllers
{

    

    public class BlogController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public BlogController()
        {
            _appDbContext = new AppDbContext();
        }
        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> blogs = _appDbContext.Blogs.ToList();
            return View("BlogIndex",blogs);
        }
    }
}
