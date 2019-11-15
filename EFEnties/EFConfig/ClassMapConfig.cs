using Models;
using System.Data.Entity.ModelConfiguration;

namespace EFEnties.EFConfig
{
    public class ClassMapConfig:EntityTypeConfiguration<Class>
    {
        public ClassMapConfig()
        {
            // Primary Key
            this.HasKey(t => t.ClassId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Class");
            this.Property(t => t.ClassId).HasColumnName("ClassId");//映射数据库列名称
            this.Property(t => t.Name).HasColumnName("ClassName");
        }
    }
}
