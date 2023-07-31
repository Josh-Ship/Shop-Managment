namespace Shop_Manager.Services;
using System.Text.Json;
using System.Text.RegularExpressions;

public class RecordsServices
{
    private readonly Shop_Manager.DbContext.RecordsDbContext _recordsDbContext;

    public RecordsServices(Shop_Manager.DbContext.RecordsDbContext recordsDbContext)
    {
        _recordsDbContext = recordsDbContext;
    }


    public Shop_Manager.Models.Records add(Shop_Manager.Models.Records record)
    {
        _recordsDbContext.Add(record);
        _recordsDbContext.SaveChanges();
        return record;
    }

    public string? find()
    {
        List<Shop_Manager.Models.Records> records = new List<Models.Records>();
        foreach(var record in _recordsDbContext.Records)
            records.Add(record);        
        return JsonSerializer.Serialize(records);
    }

    public string? find(int id)
    {
        return JsonSerializer.Serialize(_recordsDbContext.Find<Shop_Manager.Models.Records>(id));
    }

    public string? find(string date)
    {
        if (Regex.IsMatch(date, (@"^(0?[1-9]|[1-2][0-9]|3[0-1])/(0?[1-9]|1[0-2])/\d{4}$")))
        {
            var matches = new List<Shop_Manager.Models.Records>();
            using (_recordsDbContext)
                foreach(var record in _recordsDbContext.Records)
                    if (record.date == date)
                        matches.Add(record);
            return JsonSerializer.Serialize(matches);
        }
        return "The date does not match the format dd/mm/yyyy\nYou have entered: " + date;
    }

    
}