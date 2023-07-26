namespace Shop_Sales.Models;
using System.ComponentModel.DataAnnotations;

public class Sales
{
    [Key]
    public int id {get; set;}
    public ICollection<RevenueType> revenueTypes {get; set;}

    public override string ToString()
    {
        string revenues = "";

        foreach(RevenueType rev in revenueTypes)
        {
            revenues += rev.ToString();
            revenues += "\n"; 
        }

        string s = "Id: " + id + "\n" +
                   revenues;
        return s;
    }

}