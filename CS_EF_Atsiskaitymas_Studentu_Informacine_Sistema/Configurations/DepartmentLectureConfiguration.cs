using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Configuration
{
    internal class DepartmentLectureConfiguration : IEntityTypeConfiguration<DepartmentLecture>
    {
        public void Configure(EntityTypeBuilder<DepartmentLecture> builder)
        {
            builder.ToTable("DepartmentsLectures");
            builder.HasKey(dl => new { dl.DepartmentId, dl.LectureName });

            builder.HasOne(d => d.Department)
                .WithMany(dl => dl.DepartmentLectures)
                .HasForeignKey(d => d.DepartmentId);

            builder.HasOne(l => l.Lecture)
                .WithMany(dl => dl.DepartmentLectures)
                .HasForeignKey(l => l.LectureName);
        }
    }
}
