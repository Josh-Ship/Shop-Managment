namespace Shop_Manager.Services;
using System.Text.Json;
using System.Text.RegularExpressions;
public class EmployeeShiftServices
{
    private readonly IShopDbContext _DbContext;

    public EmployeeShiftServices(IShopDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public string add(Models.EmployeeShift employeeShift)
    {
        var matches = _DbContext.Employee.Where(employee => employee.name == employeeShift.employee.name).ToList();
        if (matches.Count == 0)
            return "No such Employee: " + employeeShift.employee.name;

        _DbContext.Employee_Shift.Add(employeeShift);
        _DbContext.SaveChanges();
        return JsonSerializer.Serialize(employeeShift);
    }

    public string find()
    {                
        return JsonSerializer.Serialize(_DbContext.Employee_Shift.ToList());
    }

    public string find(int id)
    {
        return JsonSerializer.Serialize(_DbContext.Employee_Shift.Find(id));
    }

    public string findByName(string name)
    {
        var result = _DbContext.Employee_Shift.Where(shift => shift.employee.name == name).ToList();
        return JsonSerializer.Serialize(result);
    }

    public string findByDateAndName(string date, string name)
    {
        var result = _DbContext.Employee_Shift.Where(shift => shift.employee.name == name && shift.date == date).ToList();
        return JsonSerializer.Serialize(result);
    }

    public string find(string date)
    {
        var result = _DbContext.Employee_Shift.Where(shift => shift.date == date).ToList();
        return JsonSerializer.Serialize(result);
    }
}

