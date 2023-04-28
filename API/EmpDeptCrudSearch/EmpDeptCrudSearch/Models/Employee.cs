using System;
using System.Collections.Generic;

namespace EmpDeptCrudSearch.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? FullName { get; set; }
        public int? DeptId { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual Department? Dept { get; set; }
    }
}
