using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LotteryApi.Factories
{
    public class LotteryDbContextFactory: IDesignTimeDbContextFactory<LotteryDbContext>
    {
        public LotteryDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", false)
                               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<LotteryDbContext>();
            var connectionString = config.GetConnectionString(nameof(LotteryDbContext));
            optionsBuilder.UseSqlServer(connectionString, options =>
                options.MigrationsAssembly($"{nameof(Infrastructure)}"));

            return new LotteryDbContext(optionsBuilder.Options);
        }
    }
}