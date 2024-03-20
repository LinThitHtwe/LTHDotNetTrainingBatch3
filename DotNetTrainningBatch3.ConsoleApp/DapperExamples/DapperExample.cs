using Dapper;
using DotNetTrainningBatch3.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS",
            InitialCatalog = "dotNetTrainningBatch3",
            UserID = "sa",
            Password = "root"
        };

        public void GetAll()
        { 
            string query = @"SELECT [id],[title]
                           ,[author]
                           FROM [dotNetTrainningBatch3].[dbo].[Blog2]";
            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<Blog> blogs = dbConnection.Query<Blog>(query).ToList();
            foreach (Blog blog in blogs)
            {
                Console.WriteLine("Id---" + blog.Id);
                Console.WriteLine("Title---" + blog.Title);
                Console.WriteLine("Author---" + blog.Author);
            }

        }

        public void GetById(string id) 
        {
            string query = @"SELECT [id],[title],[author]
                           FROM [dotNetTrainningBatch3].[dbo].[Blog2]
                           Where id = @id";
            Blog blog = new Blog()
            {
                Id = id,
            };

            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var item = dbConnection.Query<Blog>(query, blog).FirstOrDefault();
            if(item is null)
            {
                Console.WriteLine("no data found");
                return;
            }
            Console.WriteLine("Id---" + blog.Id);
            Console.WriteLine("Title---" + blog.Title);
            Console.WriteLine("Author---" + blog.Author);
        }

        public void Create(string id,string title,string author)
        {
            string query = @"INSERT INTO [dbo].[Blog2]
                            ([id],[title],[author])
                            VALUES
                            (@id,@title,@author)";
            Blog blog = new Blog()
            {
                Id = id,
                Title = title,
                Author = author
            };

            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = dbConnection.Execute(query, blog);
            string message = result > 0 ? "Successfully Created" : "Create Fail";
            Console.Write(message);
        }

        public void Update(string id, string title, string author) {
            string query = @"UPDATE [dbo].[Blog2]
                           SET [title] = @title
                           ,[author] = @author
                           WHERE id = @id";
            Blog blog = new Blog()
            {
                Id = id,
                Title = title,
                Author = author
            };

            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = dbConnection.Execute(query, blog);
            string message = result > 0 ? "Successfully Updated" : "Update Fail";
            Console.Write(message);
        }

        public void Delete(int id) 
        {
            string query = @"DELETE FROM [dbo].[Blog2]
                           WHERE id = @id";
            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = dbConnection.Execute(query, new {id});
            string message = result > 0 ? "Successfully Deleted" : "Delete Fail";
            Console.Write(message);
        }
    }
}
