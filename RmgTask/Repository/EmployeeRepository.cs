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
            employee.Id = Guid.NewGuid();
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

        public async Task<Employee> GetEmployeeAsync(Guid Id)
        {
            return await _employeeDbContext.Employees.FindAsync(Id);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = await _employeeDbContext.Employees.AsNoTracking().ToListAsync();
            return employees;
        }

        public async Task UpdateAsync(Employee employee)
        {
            bool isExistEmployee = await _employeeDbContext.Employees.AsNoTracking().AnyAsync(e => e.Id == employee.Id);
            if (isExistEmployee)
            {
                _employeeDbContext.Update(employee);
                await _employeeDbContext.SaveChangesAsync();
            }
        }
    }
}
