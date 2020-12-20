using Easy.Demo.ProcModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Demo.Data.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public static void Build(ModelBuilder builder)
        {
            builder.Entity<Employee>(b =>
            {
                b.Property(p => p.Id)
                    .IsRequired();

                b.Property(p => p.FirstName)
                    .IsRequired();

                b.Property(p => p.LastName)
                    .IsRequired();

                b.Property(p => p.Email)
                    .IsRequired();

                b.Property(p => p.Phone)
                    .IsRequired();

                b.Property(p => p.CreatedAtUtc)
                    .IsRequired().HasDefaultValue(DateTime.UtcNow);

                b.Property(p => p.LastModifiedAtUtc)
                    .IsRequired().HasDefaultValue(DateTime.UtcNow);

                b.HasKey(k => k.Id);
            });
        }
    }
}
