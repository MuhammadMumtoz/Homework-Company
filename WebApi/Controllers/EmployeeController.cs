using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class EmployeeController{
    private EmployeeService _employeeService;

    public EmployeeController(){
        _employeeService = new EmployeeService();
    }

    [HttpGet("GetEmployees")]
    public List<EmployeeDepartmentDto> GetEmployees(){
        return _employeeService.GetEmployees();
    }
    [HttpGet("GetEmployeesById")]
    public EmployeeDepartmentDto GetEmployeesById(int id){
        return _employeeService.GetEmployeesById(id);
    }
    [HttpPost]
    public int InsertEmployee(EmployeeDto employee){
        return _employeeService.InsertEmployee(employee);
    }
    [HttpPut]
    public int UpdateEmployee(EmployeeDto employee){
        return _employeeService.UpdateEmployee(employee);
    }
}