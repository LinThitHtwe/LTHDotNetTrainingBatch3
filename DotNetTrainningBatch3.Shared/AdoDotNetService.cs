using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace DotNetTrainningBatch3.Shared
{
    public class AdoDotNetService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public AdoDotNetService(string connectionString)
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
        }
        public List<T> Query<T>(string query, List<SqlParameter>? parameters = null)
        {
            SqlConnection sqlConnection = new(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);
            if (parameters is not null)
            {
                sqlCommand.Parameters.AddRange(parameters.ToArray());
            }
            SqlDataAdapter sqlDataAdapter = new(sqlCommand);
            DataTable dataTable = new();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            string jsonString = JsonConvert.SerializeObject(dataTable);
            var list = JsonConvert.DeserializeObject<List<T>>(jsonString);
            return list;
        }

        public T? QueryFirstOrDefault<T>(string query, List<SqlParameter>? parameters = null)
        {
            SqlConnection sqlConnection = new(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);
            if (parameters is not null)
            {
                sqlCommand.Parameters.AddRange(parameters.ToArray());
            }
            SqlDataAdapter sqlDataAdapter = new(sqlCommand);
            DataTable dataTable = new();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            string jsonString = JsonConvert.SerializeObject(dataTable);
            var list = JsonConvert.DeserializeObject<List<T>>(jsonString);
            return list[0];
        }

        public int Execute(string query, List<SqlParameter>? parameters = null)
        {
            SqlConnection sqlConnection = new(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new(query, sqlConnection);
            if (parameters is not null)
            {
                sqlCommand.Parameters.AddRange(parameters.ToArray());
            }
            var result =sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return result;
        }
    }
}
