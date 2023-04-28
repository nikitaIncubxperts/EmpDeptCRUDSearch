using System;
using System.Collections.Generic;

namespace EmpDeptCrudSearch.Models
{
    public partial class CountryMaster
    {
        public CountryMaster()
        {
            CityMasters = new HashSet<CityMaster>();
            EmployeeMasters = new HashSet<EmployeeMaster>();
            StateMasters = new HashSet<StateMaster>();
        }

        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public virtual ICollection<CityMaster> CityMasters { get; set; }
        public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; }
        public virtual ICollection<StateMaster> StateMasters { get; set; }
    }
}
