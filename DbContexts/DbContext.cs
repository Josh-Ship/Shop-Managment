namespace Shop_Manager.DbContext;
using Microsoft.EntityFrameworkCore;

public class ShopDbContext : DbContext, IShopDbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {}
    public DbSet<Shop_Manager.Models.Records> Records {get; set;}
    public DbSet<Shop_Manager.Models.DriverTrip> Driver_Trip {get; set;}
    public DbSet<Shop_Manager.Models.EmployeeShift> Employee_Shift {get; set;}
    public DbSet<Shop_Manager.Models.Employee> Employee {get; set;}
    public DbSet<Shop_Manager.Models.Region> Region {get; set;}
}

