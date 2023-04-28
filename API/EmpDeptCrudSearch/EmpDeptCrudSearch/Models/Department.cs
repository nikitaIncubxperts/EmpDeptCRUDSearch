﻿using System;
using System.Collections.Generic;

namespace EmpDeptCrudSearch.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DeptId { get; set; }
        public string? DeptName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
