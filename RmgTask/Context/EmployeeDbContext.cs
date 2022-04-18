using Microsoft.EntityFrameworkCore;
using RmgTask.Const;
using RmgTask.Models;

namespace RmgTask.Context
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(EmployeeModelConst.NameMaxLength);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(EmployeeModelConst.AddressMaxLength);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(EmployeeModelConst.PhoneMaxLength);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .IsRequired()
                .HasMaxLength(EmployeeModelConst.SalaryMaxLength);
        }
    }
}
