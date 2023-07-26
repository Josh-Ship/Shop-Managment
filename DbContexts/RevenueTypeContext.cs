namespace Shop_Sales.DbContext;
using Microsoft.EntityFrameworkCore;

public class RevenueTypeDbContext : DbContext
{
    long id {get; set;}
    DbSet<Shop_Sales.Models.RevenueType> revenueTypes {get; set;}
}