using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.DataContext
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string dbProvider = configuration["Data:Provider"].Trim();
            string connectionString = configuration[$"Data:{dbProvider}:ConnectionString"].Trim();


            switch (dbProvider)
            {
                case "SQLite":
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
                    break;
                case "SqlServer":
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
                    break;
                default:
                    services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(connectionString));
                    break;
            }

            return services;
        }

    }
}