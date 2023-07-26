using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shop_Sales.Startup;

public class SetUp
{
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = "Data Source=data.sqlite";
        var database = new Shop_Sales.Database.Database();
        database.createTables();

        services.AddDbContext<Shop_Sales.DbContext.RevenueTypeDbContext>(
            options => options.UseSqlite(connectionString)
        );

        services.AddDbContext<Shop_Sales.DbContext.SalesDbContext>(
            options => options.UseSqlite(connectionString)
        );
        services.AddDbContext<Shop_Sales.DbContext.RecordsDbContext>(
            options => options.UseSqlite(connectionString)
        );

        services.AddScoped<Shop_Sales.Services.RevenueTypeServices>();

    }
}