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

        services.AddDbContext<Shop_Manager.DbContext.RecordsDbContext>(
            options => options.UseSqlite(connectionString)
        );
        
        services.AddScoped<Shop_Manager.DbContext.IRecordsDbContext, Shop_Manager.DbContext.RecordsDbContext>();
        services.AddScoped<Shop_Manager.Services.RecordsServices>();
    }

    public void setUpTests(IServiceCollection services)
    {

    }
}