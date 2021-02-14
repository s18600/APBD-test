using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test.Models
{
    public partial class s18600Context : DbContext
    {
        public s18600Context()
        {
        }

        public s18600Context(DbContextOptions<s18600Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Medicament1> Medicaments1 { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Prescription1> Prescriptions1 { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
        public virtual DbSet<PrescritionMedicament> PrescritionMedicaments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Study> Studies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18600;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("Doctor_pk");

                entity.ToTable("Doctor");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.ToTable("Enrollment");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament)
                    .HasName("Medicament_pk");

                entity.ToTable("Medicament");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Medicament1>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);

                entity.ToTable("Medicaments");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("Patient_pk");

                entity.ToTable("Patient");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription)
                    .HasName("Prescription_pk");

                entity.ToTable("Prescription");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");
            });

            modelBuilder.Entity<Prescription1>(entity =>
            {
                entity.HasKey(e => e.IdPrescrition);

                entity.ToTable("Prescriptions");

                entity.HasIndex(e => e.ClientId, "IX_Prescriptions_ClientId");

                entity.HasIndex(e => e.IdDoctor, "IX_Prescriptions_IdDoctor");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Prescription1Clients)
                    .HasForeignKey(d => d.ClientId);

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescription1IdDoctorNavigations)
                    .HasForeignKey(d => d.IdDoctor);
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription })
                    .HasName("Prescription_Medicament_pk");

                entity.ToTable("Prescription_Medicament");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Medicament");

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Prescription");
            });

            modelBuilder.Entity<PrescritionMedicament>(entity =>
            {
                entity.ToTable("Prescrition_Medicament");

                entity.HasIndex(e => e.IdMedicament, "IX_Prescrition_Medicament_IdMedicament");

                entity.HasIndex(e => e.IdPrescrtiption, "IX_Prescrition_Medicament_IdPrescrtiption");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Details).IsRequired();

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescritionMedicaments)
                    .HasForeignKey(d => d.IdMedicament);

                entity.HasOne(d => d.IdPrescrtiptionNavigation)
                    .WithMany(p => p.PrescritionMedicaments)
                    .HasForeignKey(d => d.IdPrescrtiption);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.ToTable("Student");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Study>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
