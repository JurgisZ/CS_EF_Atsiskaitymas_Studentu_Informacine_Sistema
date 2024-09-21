using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Configuration
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(e => e.StudentId);

            builder.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .HasMaxLength(255);

            //Student - Department MtO
            builder.HasOne(d => d.Department)
                .WithMany(s => s.Students)
                .HasForeignKey(d => d.DepartmentId);

            //Student - Lecture MtM
            builder.HasMany(l => l.Lectures)
                .WithMany(s => s.Students)
                .UsingEntity<StudentLecture>(
                l => l.HasOne(l => l.Lecture)
                    .WithMany(sl => sl.StudentLectures)
                    .HasForeignKey(l => l.LectureId),

                s => s.HasOne(s => s.Student)
                    .WithMany(sl => sl.StudentLectures)
                    .HasForeignKey(s => s.StudentId)
                );
          
        }
    }
}
