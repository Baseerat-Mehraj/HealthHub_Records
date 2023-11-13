using HealthHub_Records.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HealthHub_Records.ViewModels;

namespace HealthHub_Records.Models
{
    public class HealthhubDbContext : DbContext
    {
        public HealthhubDbContext(DbContextOptions<HealthhubDbContext> options)
            : base(options)
        {

        }
        public DbSet<PatientRegistration> PatientRegs { get; set; }
        public DbSet<HospitalRegistration> HospitalRegs { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Reports> Reports { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Appoinment> Appoinment { get; set; }

        public DbSet<MedicalDescription> MedicalDescription { get; set; }
     
    }
}
