namespace Shop_Manager.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

public class RegionServices
{
    private readonly IShopDbContext _DbContext;

    public RegionServices(IShopDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public Models.Region add(Models.Region region)
    {
        _DbContext.Region.Add(region);
        _DbContext.SaveChanges();
        return region;
    }

    public string find()
    {                
        return JsonSerializer.Serialize(_DbContext.Region.ToList());
    }

    public string find(int id)
    {
        return JsonSerializer.Serialize(_DbContext.Region.Find(id));
    }

    public string findByFee(int fee)
    {
        var matches = _DbContext.Region.Where(region => region.fee_in_cents == fee).ToList();
        return JsonSerializer.Serialize(matches);
    }

    public string find(string name)
    {
        var matches = _DbContext.Region.Where(region => region.name == name).ToList();
        return JsonSerializer.Serialize(matches);
    }


}
