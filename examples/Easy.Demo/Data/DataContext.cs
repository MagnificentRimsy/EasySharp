using Easy.Demo.Data.Entity;
using Easy.Demo.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Easy.Demo.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (!Database.CanConnect())
            {
                Database.EnsureCreated();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Employee> Employees { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            EmployeeConfiguration.Build(builder);
            EmployeeOrgInfoConfiguration.Build(builder);
            EmployeeBankInfoConfiguration.Build(builder);
            EmployeeSalaryGradeInfoConfiguration.Build(builder);

        }
    }
}
