using System;
using System.Collections.Generic;

namespace EmpDeptCrudSearch.Models
{
    public partial class EmployeeMaster
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? EmailId { get; set; }
        public string? Gender { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string? Address { get; set; }
        public string? Pincode { get; set; }

        public virtual CityMaster? City { get; set; }
        public virtual CountryMaster? Country { get; set; }
        public virtual StateMaster? State { get; set; }
    }
}
