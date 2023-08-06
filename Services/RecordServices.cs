namespace Shop_Manager.Services;
using System.Text.Json;
using System.Text.RegularExpressions;

public class RecordServices
{
    private readonly IShopDbContext _DbContext;

    public RecordServices(IShopDbContext recordsDbContext)
    {
        _DbContext = recordsDbContext;
    }

    public Models.Records add(Models.Records record)
    {
        _DbContext.Records.Add(record);
        _DbContext.SaveChanges();
        return record;
    }

    public string find()
    {                
        return JsonSerializer.Serialize(_DbContext.Records.ToList());
    }

    public string find(int id)
    {
        return JsonSerializer.Serialize(_DbContext.Records.Find(id));
    }

    public string find(string date)
    {
        if (Regex.IsMatch(date, (@"^(0?[1-9]|[1-2][0-9]|3[0-1])/(0?[1-9]|1[0-2])/\d{4}$")))
        {
            var matches = _DbContext.Records.Where(record => record.date == date).ToList();
            return JsonSerializer.Serialize(matches);
        }
        return "The date does not match the format dd/mm/yyyy\nYou have entered: " + date;
    }

    public string findByName(string name)
    {
        var matches = _DbContext.Records.Where(record => record.name == name).ToList();
        return JsonSerializer.Serialize(matches);
    }

    public string find(string date, string name)
    {
        if (Regex.IsMatch(date, (@"^(0?[1-9]|[1-2][0-9]|3[0-1])/(0?[1-9]|1[0-2])/\d{4}$")))
        {
            var matches = _DbContext.Records.Where(record => record.date == date && record.name == name).ToList();
            return JsonSerializer.Serialize(matches);
        }
        return "The date does not match the format dd/mm/yyyy\nYou have entered: " + date;
    }


}
