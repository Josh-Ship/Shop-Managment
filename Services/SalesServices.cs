namespace Shop_Manager.Services;


public class SalesServices
{
    private readonly Shop_Manager.DbContext.SalesDbContext _salesDbContext;

    public SalesServices(Shop_Manager.DbContext.SalesDbContext salesDbContext)
    {
        _salesDbContext = salesDbContext;
    }

}