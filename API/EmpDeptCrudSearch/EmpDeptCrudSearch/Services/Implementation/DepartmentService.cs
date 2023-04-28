using EmpDeptCrudSearch.Models;
using EmpDeptCrudSearch.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace EmpDeptCrudSearch.Services.Implementation {
    public class DepartmentService : IDepartmentService {
        private readonly EmployeeDBContext _dbContext;

        public DepartmentService(EmployeeDBContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<List<Department>> GetList() {
            try {
                List<Department> departmentList = new List<Department>();
                departmentList = await _dbContext.Departments.ToListAsync();
                return departmentList;
            }catch(Exception ex) {
                throw ex;
            }
        }
    }
}
