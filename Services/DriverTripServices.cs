namespace Shop_Manager.Services;
using System.Text.Json;
using System.Text.RegularExpressions;
public class DriverTripServices
{
    private readonly IShopDbContext _DbContext;

    public DriverTripServices(IShopDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public Models.DriverTrip add(Models.DriverTrip trip)
    {
        _DbContext.Driver_Trip.Add(trip);
        _DbContext.SaveChanges();
        return trip;
    }

    public string find()
    {                
        return JsonSerializer.Serialize(_DbContext.Driver_Trip.ToList());
    }

    public string find(int id)
    {
        return JsonSerializer.Serialize(_DbContext.Driver_Trip.Find(id));
    }

    public string find(string name)
    {
        var result = _DbContext.Driver_Trip.Where(trip => trip.employee.name == name).ToList();
        return JsonSerializer.Serialize(result);
    }

    public string find(string name, string date)
    {
        if (Regex.IsMatch(date, (@"^(0?[1-9]|[1-2][0-9]|3[0-1])/(0?[1-9]|1[0-2])/\d{4}$")))
        {
            var result = _DbContext.Driver_Trip.Where(trip => trip.employee.name == name && trip.date == date).ToList();
            return JsonSerializer.Serialize(result);
        }
        return "The date does not match the format dd/mm/yyyy\nYou have entered: " + date;  
    }
}

