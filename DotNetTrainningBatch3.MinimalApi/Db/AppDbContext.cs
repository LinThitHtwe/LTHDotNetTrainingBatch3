using DotNetTrainningBatch3.MinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetTrainningBatch3.MinimalApi.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
