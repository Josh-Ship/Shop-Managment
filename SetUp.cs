using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shop_Manager.Startup;

public class SetUp
{
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = "Data Source=data.sqlite";
        services.AddDbContext<DbContext.ShopDbContext>(
            options => options.UseSqlite(connectionString)
        );

        services.AddScoped<IShopDbContext, DbContext.ShopDbContext>();
        
        services.AddScoped<Services.RecordServices>();
        services.AddScoped<Services.DriverTripServices>();
        services.AddScoped<Services.EmployeeServices>();
        services.AddScoped<Services.EmployeeShiftServices>();
        services.AddScoped<Services.RegionServices>();
    }
}