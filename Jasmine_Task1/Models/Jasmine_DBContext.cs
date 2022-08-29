using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Jasmine_Task1.Models
{
    public partial class Jasmine_DBContext : DbContext
    {
        public Jasmine_DBContext()
        {
        }

        public Jasmine_DBContext(DbContextOptions<Jasmine_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillMap> SkillMaps { get; set; }
        public virtual DbSet<SoftLock> SoftLocks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQL201901.SOFTURA.COM;Database=Jasmine_DB;User Id=Jasmine;Password=Jasmine@778866; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Employee_Id");

                entity.Property(e => e.Experience).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Lockstatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileId).HasColumnName("Profile_Id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WfmManager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Wfm_Manager");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkillMap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SkillMap");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.SkillId).HasColumnType("decimal(5, 0)");
            });

            modelBuilder.Entity<SoftLock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SoftLock");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.Lastupdated).HasColumnType("date");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Managerstatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mgrlastupdate).HasColumnType("date");

                entity.Property(e => e.Mgrstatuscomment).HasColumnType("text");

                entity.Property(e => e.Reqdate).HasColumnType("date");

                entity.Property(e => e.Requestmessage).HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Wfmremark).HasColumnType("text");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Users__C9F284573AD9DE26");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
