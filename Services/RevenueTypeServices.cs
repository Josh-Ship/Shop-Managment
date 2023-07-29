namespace Shop_Manager.Services;


public class RevenueTypeServices
{
    private readonly Shop_Manager.DbContext.RevenueTypeDbContext _revenueTypeDbContext;

    public RevenueTypeServices(Shop_Manager.DbContext.RevenueTypeDbContext revenueTypeDbContext)
    {
        _revenueTypeDbContext = revenueTypeDbContext;
    }

    public void addRevenue(string name, double amount)
    {
        using (_revenueTypeDbContext)
        {
            _revenueTypeDbContext.Add(new Shop_Manager.Models.RevenueType{name=name, amount=amount});
            _revenueTypeDbContext.SaveChanges();
        }
    }

    public Shop_Manager.Models.RevenueType? getRevenue(int id)
    {
        using (_revenueTypeDbContext)
        {
            return _revenueTypeDbContext.Find<Shop_Manager.Models.RevenueType>(id);
        }
    }

    public void addRevenue(Shop_Manager.Models.RevenueType revenueType)
    {
        using (_revenueTypeDbContext)
        {
            _revenueTypeDbContext.Add(revenueType);
            _revenueTypeDbContext.SaveChanges();
        }
    }
}