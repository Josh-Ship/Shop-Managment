namespace Shop_Sales.DbContext;
using Microsoft.EntityFrameworkCore;

public class SalesDbContext : DbContext
{
    long id {get; set;}
    DbSet<Shop_Sales.Models.RevenueType> revenueTypes {get; set;}
}