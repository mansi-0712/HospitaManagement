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

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<LabTest> LabTests { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

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

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.ToTable("Billing");

            entity.Property(e => e.BillingId)
                .ValueGeneratedNever()
                .HasColumnName("billingId");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.BillingDate)
                .HasColumnType("datetime")
                .HasColumnName("billingDate");
            entity.Property(e => e.IsPaid).HasColumnName("isPaid");
            entity.Property(e => e.PatientId).HasColumnName("patientId");

            entity.HasOne(d => d.Patient).WithMany(p => p.Billings)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Billing_Patient");
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

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId)
                .ValueGeneratedNever()
                .HasColumnName("inventoryId");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("expiryDate");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("itemName");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<LabTest>(entity =>
        {
            entity.HasKey(e => e.TestId);

            entity.ToTable("LabTest");

            entity.Property(e => e.TestId)
                .ValueGeneratedNever()
                .HasColumnName("testId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Result)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("result");
            entity.Property(e => e.TestDate)
                .HasColumnType("datetime")
                .HasColumnName("testDate");
            entity.Property(e => e.TestName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("testName");

            entity.HasOne(d => d.Patient).WithMany(p => p.LabTests)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LabTest_Patient");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId);

            entity.ToTable("MedicalRecord");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("recordId");
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("diagnosis");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.RecordDate)
                .HasColumnType("datetime")
                .HasColumnName("recordDate");
            entity.Property(e => e.Treatment)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("treatment");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalRecord_Patient");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId)
                .ValueGeneratedNever()
                .HasColumnName("notificationId");
            entity.Property(e => e.IsRead).HasColumnName("isRead");
            entity.Property(e => e.Message)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("message");
            entity.Property(e => e.SentOn)
                .HasColumnType("datetime")
                .HasColumnName("sentOn");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_User");
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

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.ToTable("Prescription");

            entity.Property(e => e.PrescriptionId)
                .ValueGeneratedNever()
                .HasColumnName("prescriptionId");
            entity.Property(e => e.DatePrescribed)
                .HasColumnType("datetime")
                .HasColumnName("datePrescribed");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.Dosage)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("dosage");
            entity.Property(e => e.Medication)
                .HasMaxLength(100)
                .HasColumnName("medication");
            entity.Property(e => e.PatientId).HasColumnName("patientId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Patient");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.ToTable("Report");

            entity.Property(e => e.ReportId)
                .ValueGeneratedNever()
                .HasColumnName("reportId");
            entity.Property(e => e.Data)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("data");
            entity.Property(e => e.GeneratedOn)
                .HasColumnType("datetime")
                .HasColumnName("generatedOn");
            entity.Property(e => e.ReportType)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("reportType");
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

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
