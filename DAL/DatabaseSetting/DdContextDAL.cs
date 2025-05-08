using Microsoft.EntityFrameworkCore;
using DAL.ModelsDAL;

namespace DAL.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DBContext() { }

        public DbSet<CityDAL> Citys { get; set; }

        public DbSet<LogsDAL> Logs { get; set; }
        public DbSet<Country> Countries { get; set; }




    }
}
