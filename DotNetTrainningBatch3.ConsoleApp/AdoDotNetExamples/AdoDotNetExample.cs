using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {

        public void GetAll()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "dotNetTrainningBatch3";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "root";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"SELECT [id],[title]
                           ,[author]
                           FROM [dotNetTrainningBatch3].[dbo].[Blog2]";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine("Id---" + dataRow["id"]);
                Console.WriteLine("Title---" + dataRow["title"]);
                Console.WriteLine("Author---" + dataRow["author"]);
            }

        }

        public void GetById(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "dotNetTrainningBatch3";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "root";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"SELECT [id],[title],[author]
                           FROM [dotNetTrainningBatch3].[dbo].[Blog2]
                           Where id = @id";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dataRow = dataTable.Rows[0];
            Console.WriteLine("Id---" + dataRow["id"]);
            Console.WriteLine("Title---" + dataRow["title"]);
            Console.WriteLine("Author---" + dataRow["author"]);

        }

        public void Create(int id, string title, string author)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "dotNetTrainningBatch3";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "root";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Blog2]
                            ([id],[title],[author])
                            VALUES
                            (@id,@title,@author)";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@title", title);
            sqlCommand.Parameters.AddWithValue("@author", author);
            int result = sqlCommand.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Successfully Created" : "Create Fail";
            Console.Write(message);

        }

        public void Update(int id, string title, string author)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "dotNetTrainningBatch3";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "root";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Blog2]
                           SET [title] = @title
                           ,[author] = @author
                           WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@title", title);
            sqlCommand.Parameters.AddWithValue("@author", author);
            int result = sqlCommand.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Successfully Updated" : "Update Fail";

            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "dotNetTrainningBatch3";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "root";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Blog2]
                           WHERE id = @id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            int result = sqlCommand.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Successfully Deleted" : "Delete Fail";

            Console.WriteLine(message);

        }
    }
}
