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
    public class UserConfiguration : BaseEntityConfiguration<User>, IEntityConfigurationAble
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Surname).HasColumnName("Surname").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Patronymic).HasColumnName("Patronymic").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar(100)");
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("nvarchar(100)");
            builder.Property(x => x.SecretAnswer).HasColumnName("SecretAnswer").HasColumnType("nvarchar(100)");
            builder.Property(x => x.SecretQuestion).HasColumnName("SecretQuestion").HasColumnType("nvarchar(100)");

            builder.HasData(new List<User>()
            {
                new User(){ CreatorDate= new DateTime(), CreatorUserId=1, Email="admin@gmail.com", Id=1, IsActive=true, Name="admin", Password="admin123", Patronymic="admin", PhoneNumber="12345", SecretAnswer="Sevdiyiniz reng", SecretQuestion="Yasil", Surname="adminov"}
            });

            //Relations
            builder.HasMany(x => x.Employees)
                .WithOne(x => x.CreateUser)
                .HasForeignKey(x => x.CreatorUserId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasMany(x => x.Departments)
                .WithOne(x => x.CreateUser)
                .HasForeignKey(x => x.CreatorUserId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasMany(x => x.EmployeesEdit)
                .WithOne(x => x.EditUser)
                .HasForeignKey(x => x.EditorUserId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasMany(x => x.DepartmentsEdit)
                .WithOne(x => x.EditUser)
                .HasForeignKey(x => x.EditorUserId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
