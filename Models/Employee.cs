namespace Shop_Manager.Models;
using System.ComponentModel.DataAnnotations;
public class Employee
{
    [Key][Required]
    public int employee_id {get; set;}

    [Required]
    public string? name {get; set;}

    [Required]
    public int? hourlyPay_in_cents {get; set;}

    [Required]
    public int? shiftPay_in_cents {get; set;}

    public override string ToString()
    {
        string s = "Id: " + employee_id + "\n" +
                          "Name: " + name + "\n" + 
                          "Hourly: " + hourlyPay_in_cents/100 + "\n" +
                          "Shift:: " + shiftPay_in_cents/100 + "\n";
        return s;
    }
}