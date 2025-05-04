using Microsoft.EntityFrameworkCore;
using Trianing_App.Models;

namespace Training_App.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        
        public DbSet<City> Citys { get; set; }

        public DbSet<Logs> Logs { get; set; }



    }
}
