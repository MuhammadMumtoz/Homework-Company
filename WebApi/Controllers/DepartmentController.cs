using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class DepartmentController{
    private DepartmentService _departmentService;

    public DepartmentController(){
        _departmentService = new DepartmentService();
    }

    [HttpGet("GetDepartments")]
    public List<DepartmentDto> GetDepartments(){
        return _departmentService.GetDepartments();
    }
    [HttpGet("GetDepartmentById")]
    public DepartmentDto GetDepartmentsById(int id){
        return _departmentService.GetDepartmentsById(id);
    }
    [HttpPost("InsertDepartment")]
    public int InsertDepartment(DepartmentDto department){
        return _departmentService.InsertDepartment(department);
    }
    [HttpPut("UpdateDepartment")]
    public int UpdateDepartment(DepartmentDto department){
        return _departmentService.UpdateDepartment(department);
    }
}