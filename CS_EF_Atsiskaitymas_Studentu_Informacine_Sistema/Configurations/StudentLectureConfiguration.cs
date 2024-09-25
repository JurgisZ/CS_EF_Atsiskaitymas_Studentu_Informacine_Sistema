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
    public class StudentLectureConfiguration : IEntityTypeConfiguration<StudentLecture>
    {
        public void Configure(EntityTypeBuilder<StudentLecture> builder)
        {
            builder.ToTable("StudentLectures");
            builder.HasKey(sl => new { sl.StudentId, sl.LectureId });
        }
    }
}
