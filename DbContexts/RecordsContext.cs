namespace Shop_Sales.DbContext;
using Microsoft.EntityFrameworkCore;

public class RecordsDbContext : DbContext
{
    long id {get; set;}
    DateTime date {get; set;}
    DbSet<Shop_Sales.Models.Records> records {get; set;}
}