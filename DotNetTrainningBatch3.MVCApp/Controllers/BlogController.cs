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

        [ActionName("Edit")]
        public IActionResult BlogEdit(string id)
        {
            var blog = _appDbContext.Blogs.FirstOrDefault(b => b.Id == id);
            if(blog is null)
            {
                return Redirect("/blog");
            }
            return View("BlogEdit",blog);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [ActionName("Save")]
        public IActionResult BlogSave(BlogModel blogModel)
        {
            _appDbContext.Blogs.Add(blogModel);
            _appDbContext.SaveChanges();
            return Redirect("/blog");
        }

        [ActionName("Update")]
        public IActionResult BlogUpdate(string id,BlogModel blogModel)
        {

            var blog = _appDbContext.Blogs.FirstOrDefault(b => b.Id == id);

            if(blog is null)
            {
                return Redirect("/Blog");
            }

            blog.Title = blogModel.Title;
            blog.Author = blogModel.Author;

            
            _appDbContext.SaveChanges();
            return Redirect("/blog");
        }

        [ActionName("Delete")]
        public IActionResult BlogDelete(string id)
        {
            var blog = _appDbContext.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog is null)
            {
                return Redirect("/blog");
            }
            _appDbContext.Remove(blog);
            _appDbContext.SaveChanges();
            return Redirect("/blog");
        }

    }
}
