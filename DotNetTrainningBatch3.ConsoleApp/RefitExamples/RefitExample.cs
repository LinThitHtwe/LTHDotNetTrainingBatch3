using DotNetTrainningBatch3.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.RefitExamples
{
   

    public class RefitExample
    {
        private readonly IApiBlog refitApi = RestService.For<IApiBlog>("https://localhost:7028");

        public async Task Run()
        {
            //await Read();
            //await GetBlogById("5");
            //await DeleteBlog("7");
            await CreateBlog("8", "Refit", "Refit");
        }

        private async Task GetBlogs()
        {
            List<Blog> blogs = await refitApi.GetBlogs();
            foreach(Blog blog in blogs)
            {
                Console.WriteLine(blog.Id);
                Console.WriteLine(blog.Title);
                Console.WriteLine(blog.Author);
                
            }
        }

        private async Task GetBlogById(string id)
        {
            try
            {
                var blog = await refitApi.GetBlogById(id);
                Console.WriteLine(blog.Id);
                Console.WriteLine(blog.Title);
                Console.WriteLine(blog.Author);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task CreateBlog(string id, string title, string author)
        {
            try
            {
                Blog blog = new Blog()
                {
                    Id = id,
                    Title = title,
                    Author = author
                };
                string message = await refitApi.CreateBlog(blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task UpdateBlog(string id, string title, string author)
        {
            try
            {
                Blog blog = new Blog()
                {
                    Id = id,
                    Title = title,
                    Author = author
                };
                string message = await refitApi.UpdateBlog(id, blog);
                Console.Write(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task DeleteBlog(string id)
        {
            try
            {
                string message = await refitApi.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
