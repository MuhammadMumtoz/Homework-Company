using Dapper;
using Npgsql;

public class DepartmentService
{

    private string _connectionSting = "Server=127.0.0.1;Port=5432;Database=Company;User Id=postgres;Password=Muhammad.23;";
    public List<DepartmentDto> GetDepartments()
    {
        using (var connection = new NpgsqlConnection(_connectionSting))
        {
            var sql = "Select department_name as departmentname from departments";
            var result = connection.Query<DepartmentDto>(sql).ToList();
            return result;
        }
    }
    public DepartmentDto GetDepartmentsById(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionSting))
        {
            var sql = $"Select department_name as departmentname from departments where id = {id}";
            var result = connection.QueryFirstOrDefault<DepartmentDto>(sql);
            return result;
        }
    }

    public int InsertDepartment(DepartmentDto department){
        using (var connection = new NpgsqlConnection(_connectionSting))
        {
            var sql = $"Insert into departments(department_name) values ('{department.DepartmentName}')";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int UpdateDepartment(DepartmentDto department){
        using (var connection = new NpgsqlConnection(_connectionSting))
        {
            var sql = $"Update departments set department_name = '{department.DepartmentName}' where id = {department.Id}";
            var result = connection.Execute(sql);
            return result;
        }
    }

}