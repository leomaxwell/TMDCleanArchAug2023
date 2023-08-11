﻿// <auto-generated />
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using PayrollLite.Infrastructure.Persistence.Contexts;

#nullable disable

namespace PayrollLite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230810192805_ChangesFieldDecimalDataType")]
    partial class ChangesFieldDecimalDataType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PayrollLite.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRecorded")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<decimal>("GrossSalary")
                        .HasColumnType("DECIMAL(10, 4)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RecordedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.GenderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRecorded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RecordedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("GenderTypes");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.MonthOfYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRecorded")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("RecordedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("MonthsOfYear");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.Payroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRecorded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("DECIMAL(10, 4)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("MonthId")
                        .HasColumnType("int");

                    b.Property<string>("RecordedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MonthId");

                    b.HasIndex("StatusId");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.PayrollItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRecorded")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("GrossSalary")
                        .HasColumnType("DECIMAL(10, 4)");

                    b.Property<decimal>("IncomeTax")
                        .HasColumnType("DECIMAL(10, 4)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PayrollId")
                        .HasColumnType("int");

                    b.Property<string>("RecordedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PayrollId");

                    b.ToTable("PayrollItems");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.PayrollStatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRecorded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RecordedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("PayrollStatusTypes");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.Employee", b =>
                {
                    b.HasOne("PayrollLite.Domain.Entities.GenderType", "GenderType")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GenderType");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.Payroll", b =>
                {
                    b.HasOne("PayrollLite.Domain.Entities.MonthOfYear", "MonthOfYear")
                        .WithMany("Payrolls")
                        .HasForeignKey("MonthId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PayrollLite.Domain.Entities.PayrollStatusType", "PayrollStatusType")
                        .WithMany("Payrolls")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MonthOfYear");

                    b.Navigation("PayrollStatusType");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.PayrollItem", b =>
                {
                    b.HasOne("PayrollLite.Domain.Entities.Employee", "Employee")
                        .WithMany("PayrollItems")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PayrollLite.Domain.Entities.Payroll", "Payroll")
                        .WithMany("PayrollItems")
                        .HasForeignKey("PayrollId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Payroll");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.Employee", b =>
                {
                    b.Navigation("PayrollItems");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.GenderType", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.MonthOfYear", b =>
                {
                    b.Navigation("Payrolls");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.Payroll", b =>
                {
                    b.Navigation("PayrollItems");
                });

            modelBuilder.Entity("PayrollLite.Domain.Entities.PayrollStatusType", b =>
                {
                    b.Navigation("Payrolls");
                });
#pragma warning restore 612, 618
        }
    }
}
