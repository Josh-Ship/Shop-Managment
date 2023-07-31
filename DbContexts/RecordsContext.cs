namespace Shop_Manager.DbContext;
using Microsoft.EntityFrameworkCore;

public class RecordsDbContext : DbContext
{
    public RecordsDbContext(DbContextOptions<RecordsDbContext> options) : base(options)
    {}

    public DbSet<Shop_Manager.Models.Records> Records {get; set;}
}