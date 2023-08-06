namespace Shop_Manager.Models;
using System.ComponentModel.DataAnnotations;
public class EmployeeShift
{
    [Key][Required]
    public int shift_id {get; set;}

    [Required]
    public Employee employee {get; set;}

    [Required]
    [RegularExpression(@"^(0?[1-9]|[1-2][0-9]|3[0-1])/(0?[1-9]|1[0-2])/\d{4}$")]
    public string? date{get; set;}

    [Required]
    [RegularExpression(@"^(0?[1-9]|1[0-2]):[0-5]\d [APap][mM]$")]
    public string? start_time {get; set;}

    [Required]
    [RegularExpression(@"^(0?[1-9]|1[0-2]):[0-5]\d [APap][mM]$")]
    public string? end_time {get; set;}

    public override string ToString()
    {
        string s = "Id: " + shift_id + "\n" +
                    "Employee: " + employee.ToString() + "\n" +
                    "Date: " + date + "\n" + 
                    "Start time: " + start_time + "\n" +
                    "End time: " + end_time + "\n";
        return s;
    }
}