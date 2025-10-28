using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.Domain.Models;

public partial class DoctorappointmentContext : DbContext
{
    public DoctorappointmentContext()
    {
    }

    public DoctorappointmentContext(DbContextOptions<DoctorappointmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Maritalstatus> Maritalstatuses { get; set; }

    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<Patientdetail> Patientdetails { get; set; }

    public virtual DbSet<Relationship> Relationships { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=doctorappointment;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Appointmentid).HasName("appointments_pkey");

            entity.ToTable("appointments", "master");

            entity.Property(e => e.Appointmentid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("appointmentid");
            entity.Property(e => e.Appointmentdate).HasColumnName("appointmentdate");
            entity.Property(e => e.Appointmenttime).HasColumnName("appointmenttime");
            entity.Property(e => e.Createdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Patientid).HasColumnName("patientid");
            entity.Property(e => e.Reason)
                .HasMaxLength(500)
                .HasColumnName("reason");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasColumnName("status");
            entity.Property(e => e.Updatedate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.Doctor).WithMany(p => p.AppointmentDoctors)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.AppointmentPatients)
                .HasForeignKey(d => d.Patientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patient");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Countryid).HasName("country_pkey");

            entity.ToTable("country", "master");

            entity.Property(e => e.Countryid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("countryid");
            entity.Property(e => e.Countryname)
                .HasMaxLength(100)
                .HasColumnName("countryname");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
        });

        modelBuilder.Entity<Maritalstatus>(entity =>
        {
            entity.HasKey(e => e.Maritalstatusid).HasName("maritalstatus_pkey");

            entity.ToTable("maritalstatus", "master");

            entity.Property(e => e.Maritalstatusid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("maritalstatusid");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Maritalstatus1)
                .HasMaxLength(50)
                .HasColumnName("maritalstatus");
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.HasKey(e => e.Occupationid).HasName("occupation_pkey");

            entity.ToTable("occupation", "master");

            entity.Property(e => e.Occupationid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("occupationid");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Occupationname)
                .HasMaxLength(100)
                .HasColumnName("occupationname");
        });

        modelBuilder.Entity<Patientdetail>(entity =>
        {
            entity.HasKey(e => e.Patientid).HasName("patientdetails_pkey");

            entity.ToTable("patientdetails", "master");

            entity.HasIndex(e => e.Username, "patientdetails_username_key").IsUnique();

            entity.Property(e => e.Patientid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("patientid");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Maritalstatusid).HasColumnName("maritalstatusid");
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .HasColumnName("mobile");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nationalityid).HasColumnName("nationalityid");
            entity.Property(e => e.Occupationid).HasColumnName("occupationid");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Pincode)
                .HasMaxLength(20)
                .HasColumnName("pincode");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .HasColumnName("state");
            entity.Property(e => e.Titleid).HasColumnName("titleid");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
            entity.Property(e => e.Visitdate).HasColumnName("visitdate");
            entity.Property(e => e.Visittime).HasColumnName("visittime");

            entity.HasOne(d => d.Maritalstatus).WithMany(p => p.Patientdetails)
                .HasForeignKey(d => d.Maritalstatusid)
                .HasConstraintName("fk_maritalstatus");

            entity.HasOne(d => d.Nationality).WithMany(p => p.Patientdetails)
                .HasForeignKey(d => d.Nationalityid)
                .HasConstraintName("fk_nationality");

            entity.HasOne(d => d.Occupation).WithMany(p => p.Patientdetails)
                .HasForeignKey(d => d.Occupationid)
                .HasConstraintName("fk_occupation");

            entity.HasOne(d => d.Title).WithMany(p => p.Patientdetails)
                .HasForeignKey(d => d.Titleid)
                .HasConstraintName("fk_title");
        });

        modelBuilder.Entity<Relationship>(entity =>
        {
            entity.HasKey(e => e.Relationshipid).HasName("relationship_pkey");

            entity.ToTable("relationship", "master");

            entity.Property(e => e.Relationshipid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("relationshipid");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Relationshipname)
                .HasMaxLength(50)
                .HasColumnName("relationshipname");
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.HasKey(e => e.Religionid).HasName("religion_pkey");

            entity.ToTable("religion", "master");

            entity.Property(e => e.Religionid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("religionid");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Religionname)
                .HasMaxLength(100)
                .HasColumnName("religionname");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecializationId).HasName("specialization_pkey");

            entity.ToTable("specialization", "master");

            entity.HasIndex(e => e.SpecializationName, "specialization_specialization_name_key").IsUnique();

            entity.Property(e => e.SpecializationId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("specialization_id");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.SpecializationName)
                .HasMaxLength(100)
                .HasColumnName("specialization_name");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Titleid).HasName("title_pkey");

            entity.ToTable("title", "master");

            entity.Property(e => e.Titleid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("titleid");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Titlename)
                .HasMaxLength(50)
                .HasColumnName("titlename");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users", "master");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Userid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("userid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Availabilityendtime).HasColumnName("availabilityendtime");
            entity.Property(e => e.Availabilitystarttime).HasColumnName("availabilitystarttime");
            entity.Property(e => e.Consultationfee)
                .HasPrecision(10, 2)
                .HasColumnName("consultationfee");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Hashedpassword)
                .HasMaxLength(255)
                .HasColumnName("hashedpassword");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("isdelete");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Maritalstatusid).HasColumnName("maritalstatusid");
            entity.Property(e => e.Occupationid).HasColumnName("occupationid");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Qualification)
                .HasMaxLength(100)
                .HasColumnName("qualification");
            entity.Property(e => e.Relationshipid).HasColumnName("relationshipid");
            entity.Property(e => e.Religionid).HasColumnName("religionid");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Patient'::character varying")
                .HasColumnName("role");
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .HasColumnName("specialization");
            entity.Property(e => e.Titleid).HasColumnName("titleid");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Yearsofexperience).HasColumnName("yearsofexperience");

            entity.HasOne(d => d.Country).WithMany(p => p.Users)
                .HasForeignKey(d => d.Countryid)
                .HasConstraintName("users_countryid_fkey");

            entity.HasOne(d => d.Maritalstatus).WithMany(p => p.Users)
                .HasForeignKey(d => d.Maritalstatusid)
                .HasConstraintName("users_maritalstatusid_fkey");

            entity.HasOne(d => d.Occupation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Occupationid)
                .HasConstraintName("users_occupationid_fkey");

            entity.HasOne(d => d.Relationship).WithMany(p => p.Users)
                .HasForeignKey(d => d.Relationshipid)
                .HasConstraintName("users_relationshipid_fkey");

            entity.HasOne(d => d.Religion).WithMany(p => p.Users)
                .HasForeignKey(d => d.Religionid)
                .HasConstraintName("users_religionid_fkey");

            entity.HasOne(d => d.Title).WithMany(p => p.Users)
                .HasForeignKey(d => d.Titleid)
                .HasConstraintName("users_titleid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
