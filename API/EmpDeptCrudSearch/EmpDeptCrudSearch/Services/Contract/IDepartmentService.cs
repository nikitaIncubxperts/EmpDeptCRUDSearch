


using EmpDeptCrudSearch.Models;

namespace EmpDeptCrudSearch.Services.Contract {
    public interface IDepartmentService {
        Task<List<Department>> GetList();
    }
}
