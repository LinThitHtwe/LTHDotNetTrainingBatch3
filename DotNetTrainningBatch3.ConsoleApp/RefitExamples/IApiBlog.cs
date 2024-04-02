using DotNetTrainningBatch3.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.RefitExamples
{
    public interface IApiBlog
    {
        [Get("/api/Blog")]
        Task<List<Blog>> GetBlogs();

        [Get("/api/Blog/{id}")]
        Task<Blog> GetBlogById(string id);

        [Post("/api/Blog")]
        Task<string> CreateBlog(Blog blog);

        [Put("/api/Blog/{id}")]
        Task<string> UpdateBlog(string id,Blog blog);

        [Delete("/api/Blog/{id}")]
        Task<string> DeleteBlog(string id);
    }
}
