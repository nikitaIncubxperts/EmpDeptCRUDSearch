using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

//run this command in Package Manager Console to create this dbContext file
//Scaffold-DbContext "server=NIKITAS\SQLEXPRESS;database=EmployeeDB;Trusted_Connection=True;" microsoft.entityframeworkcore.sqlserver -OutPutDir Models

namespace EmpDeptCrudSearch.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CityMaster> CityMasters { get; set; } = null!;
        public virtual DbSet<CountryMaster> CountryMasters { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; } = null!;
        public virtual DbSet<StateMaster> StateMasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityMaster>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__CityMast__F2D21B766EED7B3C");

                entity.ToTable("CityMaster");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CityMasters)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__CityMaste__Count__534D60F1");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.CityMasters)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__CityMaste__State__52593CB8");
            });

            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__CountryM__10D1609FA9C5527C");

                entity.ToTable("CountryMaster");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__0148818E18E3E04B");

                entity.ToTable("Department");

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK__Employee__DeptID__5CD6CB2B");
            });

            modelBuilder.Entity<EmployeeMaster>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__7AD04FF12C9DE4DF");

                entity.ToTable("EmployeeMaster");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateofBirth).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.EmployeeMasters)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__EmployeeM__CityI__5812160E");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.EmployeeMasters)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__EmployeeM__Count__5629CD9C");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EmployeeMasters)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__EmployeeM__State__571DF1D5");
            });

            modelBuilder.Entity<StateMaster>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("PK__StateMas__C3BA3B3A27E135B4");

                entity.ToTable("StateMaster");

                entity.Property(e => e.StateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StateMasters)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__StateMast__Count__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
