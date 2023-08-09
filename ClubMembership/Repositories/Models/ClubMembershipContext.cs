using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Repositories.Models
{
    public partial class ClubMembershipContext : DbContext
    {
        public ClubMembershipContext()
        {
        }

        public ClubMembershipContext(DbContextOptions<ClubMembershipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<ClubActivity> ClubActivities { get; set; } = null!;
        public virtual DbSet<ClubBoard> ClubBoards { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<GroupMember> GroupMembers { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Membership> Memberships { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ClubMembership"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.HasIndex(e => e.Name, "UQ__Club__737584F6A22D1AE0")
                    .IsUnique();

                entity.HasIndex(e => e.Code, "UQ__Club__A25C5AA7A417E0B1")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Logo).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ClubActivity>(entity =>
            {
                entity.ToTable("ClubActivity");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubActivities)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__ClubActiv__ClubI__46E78A0C");
            });

            modelBuilder.Entity<ClubBoard>(entity =>
            {
                entity.ToTable("ClubBoard");

                entity.Property(e => e.EndSemester).HasColumnType("datetime");

                entity.Property(e => e.Semester).HasMaxLength(100);

                entity.Property(e => e.StartSemester).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubBoards)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__ClubBoard__ClubI__3D5E1FD2");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.HasIndex(e => e.Code, "UQ__Grade__A25C5AA78F5D2CCB")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.ToTable("GroupMember");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('Member')");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ClubBoard)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.ClubBoardId)
                    .HasConstraintName("FK__GroupMemb__ClubB__440B1D61");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK__GroupMemb__Membe__4316F928");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.HasIndex(e => e.Name, "UQ__Major__737584F6671582A1")
                    .IsUnique();

                entity.HasIndex(e => e.Code, "UQ__Major__A25C5AA7AAC57AA4")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("Membership");

                entity.HasIndex(e => e.Code, "UQ__Membersh__A25C5AA71061E842")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__Membershi__ClubI__398D8EEE");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Membershi__Stude__38996AB5");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.Attend).HasDefaultValueSql("((1))");

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.Mission)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('Nothing')");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ClubActivity)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.ClubActivityId)
                    .HasConstraintName("FK__Participa__ClubA__4BAC3F29");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK__Participa__Membe__4AB81AF0");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.Code, "UQ__Student__A25C5AA729F3BDB3")
                    .IsUnique();

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.DateEnroll).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK__Student__GradeId__2F10007B");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Student__MajorId__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
