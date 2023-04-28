using EmpDeptCrudSearch.Models;
using EmpDeptCrudSearch.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace EmpDeptCrudSearch.Services.Implementation {
    public class EmployeeService : IEmployeeService {

        private readonly EmployeeDBContext _dbContext;
        public EmployeeService(EmployeeDBContext dBContext) {
            _dbContext = dBContext;
        }

        public async Task<Employee> Add(Employee model) {
            try {
                _dbContext.Employees.Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }catch(Exception ex) {
                throw ex;
            }
        }

        public async Task<bool> Delete(Employee model) {
            try {
                _dbContext.Employees.Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception ex) {
                throw ex;
            }
        }

        public async Task<Employee> GetById(int idEmployee) {
            try {
                Employee? employeeFound = new Employee();
                employeeFound = await _dbContext.Employees.Include(dpt => dpt.DeptId).Where(e => e.DeptId == idEmployee).FirstOrDefaultAsync();
                return employeeFound;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<List<Employee>> GetList() {
            try {

                List<Employee> employeeList = new List<Employee>();
                employeeList = await _dbContext.Employees.Include(dpt => dpt.DeptId).ToListAsync();
                return employeeList;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<Employee> Update(Employee model) {
            try {
                _dbContext.Employees.Update(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }catch(Exception ex) {
                throw ex;
            }
        }
    }
}
