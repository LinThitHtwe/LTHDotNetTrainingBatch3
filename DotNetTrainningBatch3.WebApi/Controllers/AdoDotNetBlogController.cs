using DotNetTrainningBatch3.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace DotNetTrainningBatch3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetBlogController : ControllerBase
    {
      

        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS",
            InitialCatalog = "dotNetTrainningBatch3",
            UserID = "sa",
            Password = "root"
        };


        [HttpGet]
        [ProducesResponseType(200,Type = typeof(List<Blog>))]
        public IActionResult GetAllBlogs()
        {

            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"SELECT *
                           FROM Blog2";
            SqlCommand sqlCommand = new(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new(sqlCommand);

            DataTable dataTable = new();
            sqlDataAdapter.Fill(dataTable);

            List<Blog> blogList = new();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                Blog blog = new()
                { 
                    Id = (string)dataRow["id"],
                    Author = (string)dataRow["author"],
                    Title = (string)dataRow["title"],
                };
                blogList.Add(blog);

            }
            sqlConnection.Close();
            return Ok(blogList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Blog))]
        [ProducesResponseType(404)]
        public IActionResult GetById(string id)
        {

            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = "Select * from Blog2 where id = @id";
            SqlCommand sqlCommand = new(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id",id);
            SqlDataAdapter sqlDataAdapter = new(sqlCommand);
            DataTable dataTable = new();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            if(dataTable.Rows.Count < 1)
            {
                return NotFound();
            }
            DataRow dataRow = dataTable.Rows[0];
            Blog blog = new()
            { 
                Id =((string)dataRow["id"]),
                Author = ((string)dataRow["author"]),
                Title = ((string)dataRow["title"]),
            };

            return Ok(blog);
        }

        [HttpPost]
        [ProducesResponseType(200,Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(424)]
        [ProducesResponseType(500)]
        public IActionResult CreateBlog(Blog blog)
        {
            if(blog is null)
            {
                return BadRequest();
            }

            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"INSERT INTO Blog2]
                            ([id],[title],[author])
                            VALUES 
                            (@id,@title,@author)";

            SqlCommand sqlCommand = new(query,sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id",blog.Id);
            sqlCommand.Parameters.AddWithValue("@title", blog.Title);
            sqlCommand.Parameters.AddWithValue("@author", blog.Author);

            int result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            if(result < 1) 
            {
                return StatusCode(424,"Create Fail");
            }
           
            return Ok("Successfully Created !!");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(424)]
        public IActionResult Update(string id,Blog blog)
        {

            if(blog is null)
            {
                return BadRequest();
            }

            var isBlogExist = GetById(id);
            if (isBlogExist.GetType() == typeof(NotFoundResult))
            {
                return NotFound();
            }

            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"UPDATE Blog2
                           SET [title] = @title
                           ,[author] = @author
                           WHERE id = @id";

            SqlCommand sqlCommand = new(query,sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@title", blog.Title);
            sqlCommand.Parameters.AddWithValue("@author", blog.Author);

            int result = sqlCommand.ExecuteNonQuery();
            
            sqlConnection.Close();

            if(result <1)
            {
                return StatusCode(424,"Update Fail");
            }

            return Ok("Successfully Updated");
        }
        

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        [ProducesResponseType(424)]
        public IActionResult Delete(string id)
        {

            var isBlogExist = GetById(id);
            if (isBlogExist.GetType() == typeof(NotFoundResult))
            {
                return NotFound();
            }

            SqlConnection sqlConnection = new(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"DELETE FROM Blog2
                           WHERE id = @id";
            SqlCommand sqlCommand = new(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);

            int result = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if(result < 1)
            {
                return StatusCode(424, "Delete Fail");
            }

            return Ok("Successfully Deleted");
        }
    }
}
