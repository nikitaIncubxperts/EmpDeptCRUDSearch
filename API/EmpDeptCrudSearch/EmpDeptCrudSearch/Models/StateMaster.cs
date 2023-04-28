using System;
using System.Collections.Generic;

namespace EmpDeptCrudSearch.Models
{
    public partial class StateMaster
    {
        public StateMaster()
        {
            CityMasters = new HashSet<CityMaster>();
            EmployeeMasters = new HashSet<EmployeeMaster>();
        }

        public int StateId { get; set; }
        public string? StateName { get; set; }
        public int? CountryId { get; set; }

        public virtual CountryMaster? Country { get; set; }
        public virtual ICollection<CityMaster> CityMasters { get; set; }
        public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; }
    }
}
