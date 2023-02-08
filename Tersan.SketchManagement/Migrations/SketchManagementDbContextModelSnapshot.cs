﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tersan.SketchManagement.Infrastructure;

#nullable disable

namespace Tersan.SketchManagement.Migrations
{
    [DbContext(typeof(SketchManagementDbContext))]
    partial class SketchManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Building", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SketchID")
                        .HasColumnType("int");

                    b.Property<decimal>("WindowHeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WindowWidth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("X")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Y")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("ID");

                    b.HasIndex("SketchID");

                    b.ToTable("Buildings", (string)null);
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Credential", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Credentials", (string)null);
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OfficeID")
                        .HasColumnType("int");

                    b.Property<int?>("OfficeID1")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("OfficeID");

                    b.HasIndex("OfficeID1");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Office", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BuildingID")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("X")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Y")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("BuildingID");

                    b.ToTable("Offices", (string)null);
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Ship", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipStatusID")
                        .HasColumnType("int");

                    b.Property<int?>("ShipStatusID1")
                        .HasColumnType("int");

                    b.Property<int>("SketchID")
                        .HasColumnType("int");

                    b.Property<decimal>("X")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Y")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ShipStatusID");

                    b.HasIndex("ShipStatusID1");

                    b.HasIndex("SketchID");

                    b.ToTable("Ships", (string)null);
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.ShipStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("StatusType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("ShipStatuses", (string)null);
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Sketch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Sketches", (string)null);
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.UserCredential", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CredentialID")
                        .HasColumnType("int");

                    b.Property<int?>("CredentialID1")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CredentialID");

                    b.HasIndex("CredentialID1");

                    b.HasIndex("EmployeeID");

                    b.ToTable("UserCredentials", (string)null);
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Building", b =>
                {
                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.Sketch", "Sketch")
                        .WithMany()
                        .HasForeignKey("SketchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sketch");
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Employee", b =>
                {
                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.Office", null)
                        .WithMany("Employees")
                        .HasForeignKey("OfficeID1");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Office", b =>
                {
                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Ship", b =>
                {
                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.ShipStatus", "ShipStatus")
                        .WithMany()
                        .HasForeignKey("ShipStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.ShipStatus", null)
                        .WithMany("Ships")
                        .HasForeignKey("ShipStatusID1");

                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.Sketch", "Sketch")
                        .WithMany()
                        .HasForeignKey("SketchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShipStatus");

                    b.Navigation("Sketch");
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.UserCredential", b =>
                {
                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.Credential", "Credential")
                        .WithMany()
                        .HasForeignKey("CredentialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.Credential", null)
                        .WithMany("UserCredentials")
                        .HasForeignKey("CredentialID1");

                    b.HasOne("Tersan.SketchManagement.Infrastructure.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credential");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Credential", b =>
                {
                    b.Navigation("UserCredentials");
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.Office", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Tersan.SketchManagement.Infrastructure.Models.ShipStatus", b =>
                {
                    b.Navigation("Ships");
                });
#pragma warning restore 612, 618
        }
    }
}
