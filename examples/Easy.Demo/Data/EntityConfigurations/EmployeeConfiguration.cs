using Easy.Demo.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Easy.Demo.Data.EntityConfigurations
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
                b.Property(p => p.Id).HasDefaultValueSql("newid()")
                    .IsRequired();

                b.Property(p => p.FirstName)
                    .IsRequired();

                b.Property(p => p.LastName)
                    .IsRequired();

                b.Property(p => p.Email)
                    .IsRequired();

                b.Property(p => p.Phone)
                    .IsRequired();

                b.Property(p => p.CreatedAtUtc).HasDefaultValueSql("getutcdate()");
                b.Property(p => p.CreatedAtUtc).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Throw);
                b.Property(p => p.CreatedAtUtc).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
                b.Property(p => p.LastModifiedAtUtc).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Throw);

                b.HasKey(k => k.Id);
            });

        }
    }
}
