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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
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
                .ValueGeneratedNever();

            builder.Property(e => e.Email)
                .IsRequired(false)
                .HasMaxLength(255);

            //OtM Students
            //builder.HasMany(s => s.Students)
            //    .WithOne(d => d.Department)
            //    .HasForeignKey(s => s.DepartmentId);    //StudentId buvo
            builder.HasOne(d => d.Department)
                .WithMany(s => s.Students)
                .HasForeignKey(d => d.DepartmentId);

        }
    }
}
