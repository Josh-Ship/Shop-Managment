namespace Shop_Manager.DbContext;
using Microsoft.EntityFrameworkCore;

public class RevenueTypeDbContext : DbContext
{
    public RevenueTypeDbContext(DbContextOptions<RevenueTypeDbContext> options) : base(options)
    {
    }

    int revenue_type_id {get; set;}

    // The variable name RevenueType must match the one in the database!
    DbSet<Shop_Manager.Models.RevenueType> RevenueType {get; set;}
}