using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseSetting
{
    internal class DBContextFactory: IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            var mainProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "../Trianing_App");
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(mainProjectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("DbCon");

            // Configure the DbContext
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DBContext(optionsBuilder.Options);
        }
    }
}
