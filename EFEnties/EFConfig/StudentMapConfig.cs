using Models;
using System.Data.Entity.ModelConfiguration;

namespace EFEnties.EFConfig
{
    public class StudentMapConfig:EntityTypeConfiguration<Student>
    {
        public StudentMapConfig()
        {
            
             //默认规则是主键不可以为空，引用类型允许为空，值类型不允许为空，可空的值类型可以为空 int?
             //基于尽量少配置的原则：如果属性是值类型并且允许为null，那么就配置成 int？可空，否则就声明成int
             //如果属性是引用类型，只有不允许为空的时候设置成IsRequired();
            
            // 配置属性映射到数据库列名不能为空
            this.Property(s => s.Name).IsRequired();
            // 配置属性映射到数据库的列名可以为空
            this.Property(s => s.Name).IsOptional();
            // 设置属性在数据库为主键
            this.HasKey(s => s.Id);
            // 设置这个属性不映射生成到数据库
            this.Ignore(s => s.Age);
            // 设置这个属性映射到数据库是固定长度 nvarcher
            this.Property(s => s.Name).IsFixedLength();
            // 设置这个属性对应的数据库字段是varchar类型，而不是nvarchar类型
            this.Property(s => s.Name).IsUnicode(false);
            // 设置Id属性在数据库映射生成的列名为StudentId
            this.Property(s => s.Id).HasColumnName("StudentId");
            // 设置是自动增长类型  none就是不自动增长
            this.Property(s => s.Id).HasDatabaseGeneratedOption
                (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            // 设置映射在数据的类型不自动增长
            this.Property(s => s.Id).HasDatabaseGeneratedOption
              (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);







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
