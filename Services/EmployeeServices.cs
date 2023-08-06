namespace Shop_Manager.Services;
using System.Text.Json;
public class EmployeeServices
{
    private readonly IShopDbContext _DbContext;

    public EmployeeServices(IShopDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public Models.Employee add(Models.Employee employee)
    {
        _DbContext.Employee.Add(employee);
        _DbContext.SaveChanges();
        return employee;
    }

    public string find()
    {                
        return JsonSerializer.Serialize(_DbContext.Employee.ToList());
    }

    public string find(int id)
    {
        return JsonSerializer.Serialize(_DbContext.Employee.Find(id));
    }

    public string find(string name)
    {
        var result = _DbContext.Employee.Where(employee => employee.name == name).ToList();
        return JsonSerializer.Serialize(result);
    }
}

