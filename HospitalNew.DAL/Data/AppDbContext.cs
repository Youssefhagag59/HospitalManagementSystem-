using HospitalNew.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace HospitalNew.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=HospitalData;Integrated Security=True");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Appointment)
            .WithOne(a => a.Invoice)
            .HasForeignKey<Invoice>(i => i.AppId);


            modelBuilder.Entity<Appointment>()
                .HasOne(v => v.Patient)
                .WithMany(w => w.Appointments)
                .HasForeignKey(v => v.PatientId);
            
            modelBuilder.Entity<Appointment>()
                .HasOne(x=>x.Doctor)
                .WithMany(y=>y.Appointments)
                .HasForeignKey(x => x.DocId);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

    }
}
