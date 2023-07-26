namespace Shop_Sales.Models;
using System.ComponentModel.DataAnnotations;

public class Records
{
    [Key]
    public int revenue_type_id {get; set;}
    public DateTime date {get; set;}
    public Sales sales {get; set;}

    public override string ToString()
    {
        string s = "Id: " + revenue_type_id + "\n" +
                          "Date: " + date + "\n" +
                          "Sales: " + sales.ToString();
        return s;
    }
}