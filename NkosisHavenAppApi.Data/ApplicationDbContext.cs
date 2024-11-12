using Microsoft.EntityFrameworkCore;
using NkosisHavenAppApi.Data.Entities;

namespace NkosisHavenAppApi.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		internal DbSet<Patient> Patient { get; set; }
		internal DbSet<Appointment> Appointment { get; set; }
        internal DbSet<Doctor> Doctors { get; set; }
        internal DbSet<Diagnoses> Diagnoses { get; set; }
		internal DbSet<Medication> Medications { get; set; }
		public DbSet<Nurse> Nurses { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Patient>(entity =>
			{
				entity.HasKey(e => e.PatientId);
			});

			modelBuilder.Entity<Appointment>(entity =>
			{
				entity.HasKey(e => e.AppointmentId);
			});

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);
            });

            modelBuilder.Entity<Diagnoses>(entity =>
            {
                entity.HasKey(e => e.DiagnosisId);
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.HasKey(e => e.MedicationId);
            });

			modelBuilder.Entity<Nurse>(entity =>
			{
				entity.HasKey(e => new { e.NurseId, e.PatientId }); 
			});
		}
	}
}