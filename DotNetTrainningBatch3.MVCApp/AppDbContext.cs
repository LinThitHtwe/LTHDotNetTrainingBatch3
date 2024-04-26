using DotNetTrainningBatch3.MVCApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.MVCApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-IF45PH3\\SQLEXPRESS",
                InitialCatalog = "dotNetTrainningBatch3",
                UserID = "sa",
                Password = "root",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<PageStatistic> PageStatistics { get; set; }
        public DbSet<RadarModel> Radars { get; set; }
    }
}
