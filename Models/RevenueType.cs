namespace Shop_Manager.Models;
using System.ComponentModel.DataAnnotations;
public class RevenueType
{
    [Key]
    public int revenue_type_id {get; set;}
    public string name {get; set;}
    public double amount {get; set;}

    public override string ToString()
    {
        string s = "Id: " + revenue_type_id +  "\n" +
                   "Name: " + name +  "\n" +
                   "Amount: " + amount;
        return s;
    }
}