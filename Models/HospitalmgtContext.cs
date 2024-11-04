using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HospitaManagement.Models;

public partial class HospitalmgtContext : DbContext
{
    public HospitalmgtContext()
    {
    }

    public HospitalmgtContext(DbContextOptions<HospitalmgtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appoinment> Appoinments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-UK133JKD\\SQLSERVER2022;Database=HOSPITALMGT;User Id=sa;Password=user123;Trusted_Connection=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appoinment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId);

            entity.ToTable("Appoinment");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("appointmentId");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("appointmentDate");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Reason)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("reason");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appoinments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appoinment_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appoinments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appoinment_Patient");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("doctorId");
            entity.Property(e => e.DoctorContact).HasColumnName("doctorContact");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("doctorName");
            entity.Property(e => e.Schedule)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("schedule");
            entity.Property(e => e.Speciality)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("speciality");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patientId");
            entity.Property(e => e.MedicalHistory)
                .HasMaxLength(500)
                .IsFixedLength()
                .HasColumnName("medicalHistory");
            entity.Property(e => e.PatientAddress)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("patientAddress");
            entity.Property(e => e.PatientDob).HasColumnName("patientDOB");
            entity.Property(e => e.PatientName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("patientName");
            entity.Property(e => e.PatientPhone).HasColumnName("patientPhone");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("staffId");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.StaffContact).HasColumnName("staffContact");
            entity.Property(e => e.StaffName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("staffName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
