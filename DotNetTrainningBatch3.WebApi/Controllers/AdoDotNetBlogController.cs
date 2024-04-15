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
        [ProducesResponseType(200)]
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
        [ProducesResponseType(200)]
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
    }
}
