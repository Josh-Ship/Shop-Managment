namespace Shop_Sales.Services;


public class SalesServices
{
    private readonly Shop_Sales.DbContext.SalesDbContext _salesDbContext;

    public SalesServices(Shop_Sales.DbContext.SalesDbContext salesDbContext)
    {
        _salesDbContext = salesDbContext;
    }

}