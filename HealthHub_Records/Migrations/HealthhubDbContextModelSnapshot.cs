﻿// <auto-generated />
using System;
using HealthHub_Records.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthHub_Records.Migrations
{
    [DbContext(typeof(HealthhubDbContext))]
    partial class HealthhubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthHub_Records.Models.Appoinment", b =>
                {
                    b.Property<int>("AppoinmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppoinmentId"));

                    b.Property<string>("Advice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Disease")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicines")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NextAppoinment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("AppoinmentId");

                    b.HasIndex("userid");

                    b.ToTable("Appoinment");
                });

            modelBuilder.Entity("HealthHub_Records.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("HealthHub_Records.Models.HospitalRegistration", b =>
                {
                    b.Property<int>("Hospitalid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hospitalid"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("licienceno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("phoneno")
                        .HasColumnType("bigint");

                    b.Property<int>("pincode")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("Hospitalid");

                    b.HasIndex("userid");

                    b.ToTable("HospitalRegs");
                });

            modelBuilder.Entity("HealthHub_Records.Models.MedicalDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Allergies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnyMedication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Asthematic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodPressure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DAllergies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DAnyMedication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DAsthematic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DBloodPressure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DDiabetic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOtherProblem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DPreviousInjury")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DSeriousInjury")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diabetic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OtherProblem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousInjury")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeriousInjury")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userid");

                    b.ToTable("MedicalDescription");
                });

            modelBuilder.Entity("HealthHub_Records.Models.PatientRegistration", b =>
                {
                    b.Property<int>("patientid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("patientid"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("phoneno")
                        .HasColumnType("bigint");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("patientid");

                    b.HasIndex("userid");

                    b.ToTable("PatientRegs");
                });

            modelBuilder.Entity("HealthHub_Records.Models.Reports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userid");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("HealthHub_Records.Models.Users", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userid"));

                    b.Property<bool>("Request")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HealthHub_Records.Models.Appoinment", b =>
                {
                    b.HasOne("HealthHub_Records.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HealthHub_Records.Models.HospitalRegistration", b =>
                {
                    b.HasOne("HealthHub_Records.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HealthHub_Records.Models.MedicalDescription", b =>
                {
                    b.HasOne("HealthHub_Records.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HealthHub_Records.Models.PatientRegistration", b =>
                {
                    b.HasOne("HealthHub_Records.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HealthHub_Records.Models.Reports", b =>
                {
                    b.HasOne("HealthHub_Records.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
