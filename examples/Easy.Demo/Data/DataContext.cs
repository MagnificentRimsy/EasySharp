using Easy.Demo.Data.Configurations;
using Easy.Demo.Models;
using Easy.Demo.ProcModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        { }

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
