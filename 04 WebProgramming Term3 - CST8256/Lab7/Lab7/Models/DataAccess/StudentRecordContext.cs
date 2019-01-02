using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab7.Models.DataAccess
{
    public partial class StudentRecordContext : DbContext
    {
        public StudentRecordContext()
        {
        }

        public StudentRecordContext(DbContextOptions<StudentRecordContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicRecord> AcademicRecord { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRole { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Config.ConnectionString("StudentRecord");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity<AcademicRecord>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseCode })
                    .HasName("PK__Academic__3D052599DF5F5580");

                entity.Property(e => e.StudentId).HasMaxLength(10);

                entity.Property(e => e.CourseCode).HasMaxLength(10);

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.AcademicRecord)
                    .HasForeignKey(d => d.CourseCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcademicRecord_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AcademicRecord)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcademicRecord_Student");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Course__A25C5AA6BB989221");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.RoleId });

                entity.ToTable("Employee_Role");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeRole)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToEmployee");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EmployeeRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToRole");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Role1)
                    .HasColumnName("Role")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(10);
            });
        }
    }
}
