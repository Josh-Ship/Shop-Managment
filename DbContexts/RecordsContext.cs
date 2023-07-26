namespace Shop_Sales.DbContext;
using Microsoft.EntityFrameworkCore;

public class RecordsDbContext : DbContext
{
    public RecordsDbContext(DbContextOptions<RecordsDbContext> options) : base(options)
    {}

    int id {get; set;}
    DateTime date {get; set;}
    DbSet<Shop_Sales.Models.Records> Records {get; set;}
}