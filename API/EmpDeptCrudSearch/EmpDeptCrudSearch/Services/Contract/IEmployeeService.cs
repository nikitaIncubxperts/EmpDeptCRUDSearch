

using EmpDeptCrudSearch.Models;
namespace EmpDeptCrudSearch.Services.Contract {
    public interface IEmployeeService {
        Task<List<Employee>> GetList();
        Task<Employee> GetById(int idEmployee);
        Task<Employee> Add(Employee model);
        Task<Employee> Update(Employee model);
        Task<bool> Delete(Employee model);  
    }
}
