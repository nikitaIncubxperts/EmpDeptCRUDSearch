using AutoMapper;
using EmpDeptCrudSearch.DTO;
using EmpDeptCrudSearch.Models;
using System.Globalization;

namespace EmpDeptCrudSearch.Utilities {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            //Mapping
            //Department
            CreateMap<Department, DepartmentDTO>().ReverseMap();

            //Employee
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(destiny =>
                destiny.DepartmentName, 
                opt => opt.MapFrom(origin => origin.Dept.DeptName)
                )
                .ForMember(destiny =>
                destiny.HireDate, 
                opt => opt.MapFrom(origin => origin.HireDate.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(distiny =>
                distiny.Salary, 
                opt => opt.MapFrom(origin => Convert.ToString(origin.Salary, CultureInfo.InvariantCulture))
                );

            CreateMap<EmployeeDTO, Employee>()
                .ForMember(destiny =>
                destiny.Dept,
                opt => opt.Ignore()
                )
                .ForMember(
                destiny =>
                destiny.HireDate,
                opt => opt.MapFrom(origin => DateTime.ParseExact(origin.HireDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                )
                .ForMember(distiny =>
                distiny.Salary,
                opt => opt.MapFrom(origin => Decimal.Parse(origin.Salary, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture))
                );
        }        
    }
}
