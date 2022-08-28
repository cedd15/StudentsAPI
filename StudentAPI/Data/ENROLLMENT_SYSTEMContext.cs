using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentAPI.Models;

namespace StudentAPI.Data
{
    public partial class ENROLLMENT_SYSTEMContext : DbContext
    {
        public ENROLLMENT_SYSTEMContext()
        {
        }

        public ENROLLMENT_SYSTEMContext(DbContextOptions<ENROLLMENT_SYSTEMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<COURSES> COURSES { get; set; } = null!;
        public virtual DbSet<STUDENTS> STUDENTS { get; set; } = null!;
        public virtual DbSet<STUDENTS_COURSES> STUDENTS_COURSES { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<COURSES>(entity =>
            {
                entity.Property(e => e.COURSE_TITLE)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<STUDENTS>(entity =>
            {
                entity.Property(e => e.BIRTH_DT).HasColumnType("date");

                entity.Property(e => e.FNAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LNAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<STUDENTS_COURSES>(entity =>
            {
                entity.HasKey(e => new { e.STUDENT_ID, e.COURSE_ID });

                entity.Property(e => e.CREATED_DT)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.COURSE)
                    .WithMany(p => p.STUDENTS_COURSES)
                    .HasForeignKey(d => d.COURSE_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTS_COURSES_COURSES");

                entity.HasOne(d => d.STUDENT)
                    .WithMany(p => p.STUDENTS_COURSES)
                    .HasForeignKey(d => d.STUDENT_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTS_COURSES_STUDENTS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
