using DotNetTrainningBatch3.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {

        public void Read()
        {
            AppDbContext appDbContext = new AppDbContext();
            List<Blog> blogs = appDbContext.Blogs.ToList();

            foreach (Blog blog in blogs)
            {
                Console.WriteLine("Id---" + blog.Id);
                Console.WriteLine("Title---" + blog.Title);
                Console.WriteLine("Author---" + blog.Author);
            }
        }

        public void Edit(string id)
        {
            AppDbContext appDbContext = new AppDbContext();
            Blog blog = appDbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if (blog is null)
            {
                Console.WriteLine("No Dat Found");
                return;
            }
            Console.WriteLine("Id---" + blog.Id);
            Console.WriteLine("Title---" + blog.Title);
            Console.WriteLine("Author---" + blog.Author);

        }

        public void Create(string id, string title, string author)
        {
            Blog blog = new Blog()
            {
                Id = id,
                Title = title,
                Author = author
            };

            AppDbContext appDbContext = new AppDbContext();
            appDbContext.Blogs.Add(blog);
            int result = appDbContext.SaveChanges();
            string message = result > 0 ? "Successfully Created" : "Create Fail";

            Console.WriteLine(message);

        }

        public void Update(string id, string title, string author)
        {
            AppDbContext appDbContext = new AppDbContext();
            Blog blog = appDbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if(blog is null)
            {
                Console.WriteLine("No Data Found");
                return ;
            }

            blog.Title = title;
            blog.Author = author;

            int result = appDbContext.SaveChanges();
            string message = result > 0 ? "Successfully Updated" : "Update Fail";

            Console.WriteLine(message);

        }

        public void Delete(string id)
        {
            AppDbContext appDbContext = new AppDbContext();
            Blog blog = appDbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if( blog is null)
            {
                Console.WriteLine("No Data Found");
                return ;
            }

            appDbContext.Blogs.Remove(blog);
            int result = appDbContext.SaveChanges();
            string message = result > 0 ? "Successfully Deleted" : "Delete Fail";

            Console.WriteLine(message);

        }

        public void Generate(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int rowNo = (i + 1);
                Create("Title" + rowNo, "Author" + rowNo, "Content" + rowNo);
            }
        }

    }
}
