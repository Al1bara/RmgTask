using Microsoft.EntityFrameworkCore;
using RmgTask.Context;
using RmgTask.Models;

namespace RmgTask.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext=employeeDbContext;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _employeeDbContext.AddAsync(employee);
            await _employeeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Employee employer = await _employeeDbContext.Employees.FindAsync(id);
            if (employer != null)
            {
                _employeeDbContext.Remove(employer);
                await _employeeDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = await _employeeDbContext.Employees.ToListAsync();
            return employees;
        }

        public async Task UpdateAsync(Employee employee)
        {
            Employee employer = _employeeDbContext.Employees.Find(employee.Id);
            if (employer != null)
            {
                _employeeDbContext.Update(employer);
                await _employeeDbContext.SaveChangesAsync();
            }
        }
    }
}
