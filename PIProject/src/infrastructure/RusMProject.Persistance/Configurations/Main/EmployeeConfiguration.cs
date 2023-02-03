using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RusMProject.Domain.Entities;
using RusMProject.Persistance.Configurations.Common;
using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Configurations.Main
{
    public class EmployeeConfiguration:BaseEntityConfiguration<Employee>,IEntityConfigurationAble
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.ToTable("Employees");

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(100)");
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate");
            builder.Property(x => x.DepartmentId).HasColumnName("DepartmentId");
            builder.Property(x=>x.Surname).HasColumnName("Surname").HasColumnType("nvarchar(100)");

        }
    }
}
