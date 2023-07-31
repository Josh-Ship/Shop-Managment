namespace Shop_Manager.DbContext;
using Microsoft.EntityFrameworkCore;

public class RecordsDbContext : DbContext, IRecordsDbContext
{
    public RecordsDbContext(DbContextOptions<RecordsDbContext> options) : base(options)
    {}
    public DbSet<Shop_Manager.Models.Records> Records {get; set;}
}

public interface  IRecordsDbContext
{
    public DbSet<Shop_Manager.Models.Records> Records {get; set;}
    int SaveChanges();
}