using DotNetTrainningBatch3.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainningBatch3.MVCApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogAjaxController()
        {
            _appDbContext = new AppDbContext();
        }


        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> blogs = _appDbContext.Blogs.ToList();
            return View("BlogIndex", blogs);
        }

        [ActionName("Create")]
        public IActionResult BlogCreateView()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult BlogSave(BlogModel blogModel)
        {
            _appDbContext.Blogs.Add(blogModel);
            int result = _appDbContext.SaveChanges();
            BlogResponseModel blogResponseModel = new()
            {
                IsSuccess = result > 0,
                Message = result >0 ? "Successfully Created" : "Create Fail"
            };
            return Json(blogResponseModel);
        }

        [ActionName("Edit")]
        public IActionResult BlogEditPage(string id)
        {
            var blog = _appDbContext.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog is null)
            {
                return Redirect("/blog");
            }
            return View("BlogEdit", blog);
        }

        [HttpPut]
        [ActionName("Update")]
        public IActionResult BlogUpdate(string id, BlogModel requestBlog)
        {
            BlogResponseModel model = new();
            var blog = _appDbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if (blog is null)
            {
                model = new BlogResponseModel()
                {
                    IsSuccess = false,
                    Message = "No Blog found."
                };
                return Json(model);
            }

            blog.Title = requestBlog.Title;
            blog.Author = requestBlog.Author;

            int result = _appDbContext.SaveChanges();
            model = new()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Successfully Updated" : "Update Fail."
            };
            return Json(model);
        }

        [HttpDelete]
        [ActionName("Delete")]
        public IActionResult BlogDelete(string id)
        {
            BlogResponseModel model = new();
            var blog = _appDbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if (blog is null)
            {
                model = new()
                {
                    IsSuccess = false,
                    Message = "No data found."
                };
                return Json(model);
            }

            _appDbContext.Blogs.Remove(blog);
            int result = _appDbContext.SaveChanges();
            model = new()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Successfully Deleted" : "Delete Fail."
            };
            return Json(model);
        }

    }
}
