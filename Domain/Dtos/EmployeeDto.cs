public enum Gender{
    male,
    female
}
public class EmployeeDto {
    public int Id{get; set;}
    public int DepartmentId {get; set;}
    public DateTime EmployeeBirthdate {get; set;}
    public string EmployeeName {get; set;}
    public string EmployeeLastname {get; set;}
    public Gender EmployeeGender {get; set;} 
    public string Fullname {get; set;}
}
