namespace Shop_Sales.Database;
using System;
public interface ISalesRepository : IDisposable
{
    IEnumerable<Shop_Sales.Models.Sales> GetSales();
    Shop_Sales.Models.Sales GetSalesByID(long id);
    
}