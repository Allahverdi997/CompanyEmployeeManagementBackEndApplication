﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RusMProject.Persistance.DbContexts;

#nullable disable

namespace RusMProject.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RusMProject.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatorDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatorDate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorUserId");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EditorDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditorDate");

                    b.Property<int?>("EditorUserId")
                        .HasColumnType("int")
                        .HasColumnName("EditorUserId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("EditorUserId");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("RusMProject.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<DateTime>("CreatorDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatorDate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorUserId");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentId");

                    b.Property<DateTime?>("EditorDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditorDate");

                    b.Property<int?>("EditorUserId")
                        .HasColumnType("int")
                        .HasColumnName("EditorUserId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EditorUserId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("RusMProject.Domain.Entities.ExceptionNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatorDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatorDate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorUserId");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Description");

                    b.Property<DateTime?>("EditorDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditorDate");

                    b.Property<int?>("EditorUserId")
                        .HasColumnType("int")
                        .HasColumnName("EditorUserId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ExceptionNotifications", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5034),
                            CreatorUserId = 1,
                            Description = "There is no data available corresponding this request",
                            IsActive = true,
                            Name = "Not Found"
                        },
                        new
                        {
                            Id = 2,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5080),
                            CreatorUserId = 1,
                            Description = "The request the you made is incorrect or corrupt",
                            IsActive = true,
                            Name = "Bad Request"
                        },
                        new
                        {
                            Id = 3,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5083),
                            CreatorUserId = 1,
                            Description = "An error occurred on the server",
                            IsActive = true,
                            Name = "Server Error"
                        },
                        new
                        {
                            Id = 4,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5085),
                            CreatorUserId = 1,
                            Description = "Data is must not null,zero or empty",
                            IsActive = true,
                            Name = "Client Error"
                        },
                        new
                        {
                            Id = 5,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5089),
                            CreatorUserId = 1,
                            Description = "No matching language found",
                            IsActive = true,
                            Name = "Client Error For Lang"
                        },
                        new
                        {
                            Id = 6,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5093),
                            CreatorUserId = 1,
                            Description = "There is no data in the database that matches the given language",
                            IsActive = true,
                            Name = "Not Found For Language"
                        },
                        new
                        {
                            Id = 7,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5095),
                            CreatorUserId = 1,
                            Description = "The given language does not exist in the databases",
                            IsActive = true,
                            Name = "Server Error Parent Child"
                        },
                        new
                        {
                            Id = 8,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5098),
                            CreatorUserId = 1,
                            Description = "There is no word in the database that matches the given id",
                            IsActive = true,
                            Name = "Not Found For Id"
                        },
                        new
                        {
                            Id = 9,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5100),
                            CreatorUserId = 1,
                            Description = "There is no data in the database that matches the given language or id",
                            IsActive = true,
                            Name = "Not Found For Language Or Id"
                        },
                        new
                        {
                            Id = 10,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5104),
                            CreatorUserId = 1,
                            Description = "The given language does not exist in the databases",
                            IsActive = true,
                            Name = "Client Error For Model"
                        },
                        new
                        {
                            Id = 11,
                            CreatorDate = new DateTime(2023, 2, 1, 22, 48, 55, 709, DateTimeKind.Local).AddTicks(5106),
                            CreatorUserId = 1,
                            Description = "AuthenticationToken Is Required",
                            IsActive = true,
                            Name = "AuthenticationTokenIsRequired"
                        });
                });

            modelBuilder.Entity("RusMProject.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatorDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatorDate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorUserId");

                    b.Property<DateTime?>("EditorDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EditorDate");

                    b.Property<int?>("EditorUserId")
                        .HasColumnType("int")
                        .HasColumnName("EditorUserId");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Password");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Patronymic");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PhoneNumber");

                    b.Property<string>("SecretAnswer")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SecretAnswer");

                    b.Property<string>("SecretQuestion")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SecretQuestion");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("RusMProject.Domain.Entities.Department", b =>
                {
                    b.HasOne("RusMProject.Domain.Entities.User", "CreateUser")
                        .WithMany("Departments")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("RusMProject.Domain.Entities.User", "EditUser")
                        .WithMany("DepartmentsEdit")
                        .HasForeignKey("EditorUserId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("CreateUser");

                    b.Navigation("EditUser");
                });

            modelBuilder.Entity("RusMProject.Domain.Entities.Employee", b =>
                {
                    b.HasOne("RusMProject.Domain.Entities.User", "CreateUser")
                        .WithMany("Employees")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("RusMProject.Domain.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RusMProject.Domain.Entities.User", "EditUser")
                        .WithMany("EmployeesEdit")
                        .HasForeignKey("EditorUserId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("CreateUser");

                    b.Navigation("Department");

                    b.Navigation("EditUser");
                });

            modelBuilder.Entity("RusMProject.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("RusMProject.Domain.Entities.User", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("DepartmentsEdit");

                    b.Navigation("Employees");

                    b.Navigation("EmployeesEdit");
                });
#pragma warning restore 612, 618
        }
    }
}
