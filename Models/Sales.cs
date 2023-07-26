namespace Shop_Sales.Models;

public class Sales
{
    public long id {get; set;}
    public ICollection<RevenueType> revenueTypes {get; set;}

}