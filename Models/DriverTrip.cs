namespace Shop_Manager.Models;
using System.ComponentModel.DataAnnotations;
public class DriverTrip
{
    [Key][Required]
    public int trip_id {get; set;}
    
    [Required]
    public Employee employee {get; set;}

    [Required]
    [RegularExpression(@"^(0?[1-9]|[1-2][0-9]|3[0-1])/(0?[1-9]|1[0-2])/\d{4}$")]
    public string? date {get; set;}

    [Required]
    public Region region {get; set;}

    [Required]
    [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$")]
    public string? departure_time {get; set;}

    [Required]
    public int? shiftPay_in_cents {get; set;}

    public override string ToString()
    {
        string s = "Id: " + trip_id+ "\n" +
                    "Employee: " + employee.ToString() + "\n" + 
                    "Date: " + date + "\n" +
                    "Region: " + region.ToString() + "\n" +
                    "Departure time: " + departure_time + "\n";
        return s;
    }
}