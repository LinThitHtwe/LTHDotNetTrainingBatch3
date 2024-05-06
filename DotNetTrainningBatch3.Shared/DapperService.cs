using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.Shared
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public DapperService(string connectionString)
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
        }

        public List<T> Query<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<T> list = db.Query<T>(query, param).ToList();
            return list;
        }

        public T? QueryFirstOrDefault<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            T item = db.QueryFirstOrDefault<T>(query, param);
            return item;
        }

        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, param);
            return result;
        }
    }
}
