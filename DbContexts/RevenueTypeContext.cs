namespace Shop_Sales.DbContext;
using Microsoft.EntityFrameworkCore;

public class RevenueTypeDbContext : DbContext
{
    public RevenueTypeDbContext(DbContextOptions<RevenueTypeDbContext> options) : base(options)
    {
    }

    long id {get; set;}

    // The variable name RevenueType must match the one in the database!
    DbSet<Shop_Sales.Models.RevenueType> RevenueType {get; set;}
}