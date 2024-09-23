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
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.StudentCode)
                .IsRequired()
                .ValueGeneratedNever()
                .HasMaxLength(8);            

            builder.Property(e => e.Email)
                .HasMaxLength(255);

            ////Student - Department MtO Departmente aprasyta
            //builder.HasOne(d => d.Department)
            //    .WithMany(s => s.Students)
            //    .HasForeignKey(d => d.DepartmentId);

            //Lecture aprasyta
            //Student - Lecture MtM
            //builder.HasMany(l => l.Lectures)
            //    .WithMany(s => s.Students)
            //    .UsingEntity<StudentLecture>(
            //    l => l.HasOne(l => l.Lecture)
            //        .WithMany(sl => sl.StudentLectures)
            //        .HasForeignKey(l => l.LectureName),

            //    s => s.HasOne(s => s.Student)
            //        .WithMany(sl => sl.StudentLectures)
            //        .HasForeignKey(s => s.StudentId)
            //    );

        }
    }
}
