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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(e => e.DepartmentId);

            builder.Property(e => e.DepartmentId) //Id string, 3 letters + 3 numbers
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(e => e.DepartmentName)
                 .HasMaxLength(100)
                 .IsRequired();


            //MtM Lectures <DepartmentLectures>
            builder.HasMany(l => l.Lectures)
                .WithMany(d => d.Departments)
                .UsingEntity<DepartmentLecture>(

                d => d.HasOne<Lecture>(l => l.Lecture)
                    .WithMany(d => d.DepartmentLectures)
                    .HasForeignKey(dl => dl.LectureId),

                l => l.HasOne<Department>(d => d.Department)
                    .WithMany(l => l.DepartmentLectures)
                    .HasForeignKey(dl => dl.DepartmentId));
            
        }
    }
}
