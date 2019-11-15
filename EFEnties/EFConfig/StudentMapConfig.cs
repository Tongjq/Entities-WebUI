using Models;
using System.Data.Entity.ModelConfiguration;

namespace EFEnties.EFConfig
{
    public class StudentMapConfig:EntityTypeConfiguration<Student>
    {
        public StudentMapConfig()
        {

            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Student");
            this.Property(t => t.Id).HasColumnName("StudentId");
            this.Property(t => t.Age).HasColumnName("StudentAge");           
            this.Property(t => t.Name).HasColumnName("StudentName");
            this.Property(t => t.ClassId).HasColumnName("ClassId");
            this.Property(t => t.TeacherId).HasColumnName("TeacherId");

            // Relationships
            // 和Class一对多的关系
            this.HasRequired(t => t.Class)
                .WithMany(t => t.Students)
                .HasForeignKey(d => d.ClassId);

            // Relationships
            // 和Teacher多对多的关系
            this.HasMany(t=>t.Teachers)
                .WithMany(s=>s.Students)
                .Map(m =>
                {
                    m.ToTable("T_TeacherStudent");//中间表名
                    m.MapLeftKey("TeacherID");//列名
                    m.MapRightKey("StudentID");
                });

            // Relationships
            // 和StudentProfile一对一的关系
            this.HasRequired(t => t.StudentProfile)
                .WithRequiredDependent(t => t.Student);

        }
    }
}
