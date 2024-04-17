using DotNetTrainningBatch3.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DotNetTrainningBatch3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperBlogController : ControllerBase
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new()
        {
            DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS",
            InitialCatalog = "dotNetTrainningBatch3",
            UserID = "sa",
            Password = "root"
        };

        [HttpGet]
        [ProducesResponseType(200,Type =typeof(List<Blog>))]
        public IActionResult GetAllBlogs()
        {

            string query = @"SELECT *
                           FROM Blog2";
            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString); 
            List<Blog> blogs = dbConnection.Query<Blog>(query).ToList();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200,Type =typeof(Blog))]
        [ProducesResponseType(404)]
        public IActionResult GetBlogById(string id)
        {
            string query = @"SELECT *
                           FROM Blog2
                           Where id = @id";
            Blog blogRequest = new() { Id = id};
            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var blogResponse = dbConnection.Query<Blog>(query, blogRequest).FirstOrDefault();
            if(blogResponse is null)
            {
                return NotFound();
            }
            return Ok(blogResponse);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(424)]
        public IActionResult CreateBlog(Blog requestBlog)
        {
            if(requestBlog is null)
            {
                return BadRequest();
            }

            string query = @"INSERT INTO Blog2
                            ([id],[title],[author])
                            VALUES
                            (@id,@title,@author)";

            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = dbConnection.Execute(query, requestBlog);
            if(result < 1) {
                return StatusCode(424, "Create Fail");
            }


            return Ok("Successfully Created");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(424)]
        public IActionResult UpdateBlog(string id, Blog requestBlog)
        {
            var isBlogExist = GetBlogById(id);
            if (isBlogExist.GetType() == typeof(NotFoundResult))
            {
                return NotFound();
            }
            if(requestBlog is null)
            {
                return BadRequest();
            }
            if(id != requestBlog.Id)
            {
                return BadRequest();
            }

            string query = @"UPDATE Blog2
                           SET [title] = @title
                           ,[author] = @author
                           WHERE id = @id";
            Blog blog = new()
            {
                Id = id,
                Title = requestBlog.Title,
                Author = requestBlog.Author,
            };

            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = dbConnection.Execute(query, blog);
            if (result < 1)
            {
                return StatusCode(424, "Update Fail");
            }
            return Ok("Successfully Updated");
        
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(424)]
        public IActionResult DeleteBlog(string id)
        {
            var isBlogExist = GetBlogById(id);
            if (isBlogExist.GetType() == typeof(NotFoundResult))
            {
                return NotFound();
            }

            string query = @"DELETE FROM [dbo].[Blog2]
                           WHERE id = @id";
            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = dbConnection.Execute(query, new { id });
            if(result <1)
            {
                return StatusCode(424, "Delete Fail");
            }


            return Ok("Successfully Deleted");
        }


    }
}
