namespace Shop_Manager.Models;
using System.ComponentModel.DataAnnotations;
public class Region
{
    [Key][Required]
    public int region_id {get; set;}

    [Required]
    public string? name {get; set;}

    [Required]
    public int? fee_in_cents {get; set;}


    public override string ToString()
    {
        string s = "Id: " + region_id + "\n" +
                          "Name: " + name + "\n" + 
                          "Fee: " + fee_in_cents/100 + "\n";
        return s;
    }
}