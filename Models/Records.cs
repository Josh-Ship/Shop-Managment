namespace Shop_Manager.Models;
using System.ComponentModel.DataAnnotations;
public class Records
{
    [Key][Required]
    public int record_id {get; set;}

    [Required]
    [RegularExpression(@"^(0?[1-9]|[1-2][0-9]|3[0-1])/(0?[1-9]|1[0-2])/\d{4}$")]
    public string? date {get; set;}

    [Required]
    public string? name {get; set;}

    [Required]
    [Range(0, int.MaxValue)]
    public int amount_in_cents {get; set;}

    public override string ToString()
    {
        string s = "Id: " + record_id + "\n" +
                          "Date: " + date + "\n" +
                          "Name: " + name + "\n" + 
                          "Dollars: " + amount_in_cents/100 + "\n" +
                          "Cents: " + amount_in_cents%100 + "\n";
        return s;
    }
}