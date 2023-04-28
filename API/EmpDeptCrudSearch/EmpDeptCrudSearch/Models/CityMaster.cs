using System;
using System.Collections.Generic;

namespace EmpDeptCrudSearch.Models
{
    public partial class CityMaster
    {
        public CityMaster()
        {
            EmployeeMasters = new HashSet<EmployeeMaster>();
        }

        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }

        public virtual CountryMaster? Country { get; set; }
        public virtual StateMaster? State { get; set; }
        public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; }
    }
}
