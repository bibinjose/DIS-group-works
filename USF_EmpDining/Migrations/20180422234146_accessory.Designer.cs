﻿// <auto-generated />
using EmpApp.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EmpApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180422234146_accessory")]
    partial class accessory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpApp.Models.Accessory", b =>
                {
                    b.Property<int>("AccessoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessoryName")
                        .IsRequired();

                    b.Property<int?>("EmployeeId");

                    b.HasKey("AccessoryId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("EmpApp.Models.Award", b =>
                {
                    b.Property<int>("AwardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AwardName")
                        .IsRequired();

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("PrizeAmount");

                    b.HasKey("AwardId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("EmpApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Designation");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmpApp.Models.Leave", b =>
                {
                    b.Property<int>("LeaveId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovalStatus");

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("LeaveId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("EmpApp.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId");

                    b.Property<float>("HourlyWage");

                    b.Property<float>("HoursWorked");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("PaymentType");

                    b.Property<float>("Salary");

                    b.HasKey("PaymentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("EmpApp.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("ScheduleDate");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("WorkLocation");

                    b.HasKey("ScheduleId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("EmpApp.Models.Accessory", b =>
                {
                    b.HasOne("EmpApp.Models.Employee", "Employee")
                        .WithMany("Accessories")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("EmpApp.Models.Award", b =>
                {
                    b.HasOne("EmpApp.Models.Employee", "Employee")
                        .WithMany("Awards")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("EmpApp.Models.Leave", b =>
                {
                    b.HasOne("EmpApp.Models.Employee", "Employee")
                        .WithMany("Leaves")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("EmpApp.Models.Payment", b =>
                {
                    b.HasOne("EmpApp.Models.Employee", "Employee")
                        .WithMany("Payments")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("EmpApp.Models.Schedule", b =>
                {
                    b.HasOne("EmpApp.Models.Employee", "Employee")
                        .WithMany("Schedules")
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}