using DotNetTrainningBatch3.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainningBatch3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BlogController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            List<Blog> blogs = _appDbContext.Blogs.OrderByDescending(blog => blog.Id).ToList();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(string id)
        {
            Blog blog = _appDbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if (blog is null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            _appDbContext.Blogs.Add(blog);
            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Successfully Created" : "Create Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(string id,Blog blog)
        {
            Blog existingBlog = _appDbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if(existingBlog is null)
            {
                return NotFound();
            }

            existingBlog.Id = id;
            existingBlog.Title = blog.Title;
            existingBlog.Author = blog.Author;

            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Successfully Updated" : "Update Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(string id)
        {
            Blog existingBlog = _appDbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if (existingBlog is null)
            {
                return NotFound();
            }
            _appDbContext.Blogs.Remove(existingBlog);
            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Successfully Deleted" : "Delete Fail";
            return Ok(message);
        }
    }
}
