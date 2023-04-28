using EmpDeptCrudSearch.Models;

namespace EmpDeptCrudSearch.DTO {
    public class EmployeeDTO {
        public int? idEMployee { get; set; }
        public string? FullName { get; set; }
        public int? idDepartment { get; set; }
        public string? DepartmentName { get; set; }
        public string? Salary { get; set; }
        public string? HireDate { get; set; }
        public virtual Department? Dept { get; set; }
    }
}
