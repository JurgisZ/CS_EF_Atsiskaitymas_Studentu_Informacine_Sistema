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
    internal class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.ToTable("Lectures");
            builder.HasKey(e => e.LectureId);

            builder.Property(e => e.LectureId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.LectureName)
                .IsRequired();  //Lenght >= 5

            builder.Property(e => e.Time)
                .IsRequired();

            builder.Property(e => e.Duration)
            .IsRequired();

            builder.HasMany(s => s.Students)
                .WithMany(l => l.Lectures)
                .UsingEntity<StudentLecture>(

                    s => s.HasOne(s => s.Student)
                        .WithMany(sl => sl.StudentLectures)
                        .HasForeignKey(s => s.StudentId),
                    
                    l => l.HasOne(l => l.Lecture)
                        .WithMany(sl => sl.StudentLectures)
                        .HasForeignKey(s => s.LectureId));

        }
    }
}
