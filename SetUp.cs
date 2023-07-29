using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shop_Manager.Startup;

public class SetUp
{
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = "Data Source=data.sqlite";
        var database = new Shop_Manager.Database.Database();
        database.createTables();

        services.AddDbContext<Shop_Manager.DbContext.RevenueTypeDbContext>(
            options => options.UseSqlite(connectionString)
        );

        services.AddDbContext<Shop_Manager.DbContext.SalesDbContext>(
            options => options.UseSqlite(connectionString)
        );
        services.AddDbContext<Shop_Manager.DbContext.RecordsDbContext>(
            options => options.UseSqlite(connectionString)
        );

        services.AddScoped<Shop_Manager.Services.RevenueTypeServices>();

    }
}