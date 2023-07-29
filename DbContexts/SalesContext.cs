namespace Shop_Manager.DbContext;
using Microsoft.EntityFrameworkCore;

public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
    {}

    int id {get; set;}
    DbSet<Shop_Manager.Models.Sales> Sales {get; set;}
}