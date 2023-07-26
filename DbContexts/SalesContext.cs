namespace Shop_Sales.DbContext;
using Microsoft.EntityFrameworkCore;

public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
    {}

    int id {get; set;}
    DbSet<Shop_Sales.Models.Sales> Sales {get; set;}
}