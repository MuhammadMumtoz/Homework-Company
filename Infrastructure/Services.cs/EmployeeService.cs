using Dapper;
using Npgsql;

public class EmployeeService{
    private string _connectionSting = "Server=127.0.0.1;Port=5432;Database=Company;User Id=postgres;Password=Muhammad.23;";

    public List<EmployeeDepartmentDto> GetEmployees(){
        using (var connection = new NpgsqlConnection(_connectionSting))
        {
            var sql = "Select e.id as id, CONCAT(e.employee_name, ' ' ,e.employee_lastname) as Fullname, e.department_id as departmentid, d.department_name as departmentname from employees as e join departments as d on e.department_id = d.id";
            var result = connection.Query<EmployeeDepartmentDto>(sql).ToList();
            return result;
        }
    }
    public EmployeeDepartmentDto GetEmployeesById(int id){
        using (var connection = new NpgsqlConnection(_connectionSting))
        {
            var sql = $"Select e.id as id, CONCAT(e.employee_name,' ',e.employee_lastname) as Fullname, e.department_id as departmentid, d.department_name as departmentname from employees as e join departments as d on e.department_id = d.id where e.id = {id}";
            var result = connection.QueryFirstOrDefault<EmployeeDepartmentDto>(sql);
            return result;
        }
    }
    public int InsertEmployee(EmployeeDto employee){
        using (var connection = new NpgsqlConnection(_connectionSting))
        {
            var sql = $"Insert into employees(department_id,employee_birthdate,employee_name,employee_lastname,employee_gender) values({employee.DepartmentId},'{employee.EmployeeBirthdate}','{employee.EmployeeName}','{employee.EmployeeLastname}',{(int)employee.EmployeeGender})";
            var result = connection.Execute(sql);
            return result;
        }
    }
    public int UpdateEmployee(EmployeeDto employee){
        using (var connection = new NpgsqlConnection(_connectionSting))
        {
            var sql = $"Update employees set employee_birthdate = '{employee.EmployeeBirthdate}', employee_name = '{employee.EmployeeName}', employee_lastname = '{employee.EmployeeLastname}', employee_gender = {(int)employee.EmployeeGender}) where id = {employee.Id}";
            var result = connection.Execute(sql);
            return result;
        }
    }
}
