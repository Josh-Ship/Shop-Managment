namespace Shop_Sales.Services;


public class RevenueTypeServices
{
    private readonly Shop_Sales.DbContext.RevenueTypeDbContext _revenueTypeDbContext;

    public RevenueTypeServices(Shop_Sales.DbContext.RevenueTypeDbContext revenueTypeDbContext)
    {
        _revenueTypeDbContext = revenueTypeDbContext;
    }

    public void addRevenue(string name, double amount)
    {
        using (_revenueTypeDbContext)
        {
            _revenueTypeDbContext.Add(new Shop_Sales.Models.RevenueType{name=name, amount=amount});
            _revenueTypeDbContext.SaveChanges();
        }
    }

    public void addRevenue(Shop_Sales.Models.RevenueType revenueType)
    {
        using (_revenueTypeDbContext)
        {
            _revenueTypeDbContext.Add(revenueType);
            _revenueTypeDbContext.SaveChanges();
        }
    }
}