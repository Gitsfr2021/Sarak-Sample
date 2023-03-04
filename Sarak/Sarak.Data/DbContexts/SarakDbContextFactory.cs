using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Sarak.Data.DbContexts
{
    public class SarakDbContextFactory : IDesignTimeDbContextFactory<SarakDbContext>
    {
        public SarakDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SarakDbContext>();
            var basePath = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(basePath)
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .Build();

            var defaultConnection = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(defaultConnection);

            return new SarakDbContext(optionsBuilder.Options);
        }
    }
}
