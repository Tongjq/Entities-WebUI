using System.Data.Entity.ModelConfiguration;

namespace EFEnties.EFConfig
{
    public class TeacherMapConfig:EntityTypeConfiguration<Teacher>
    {
        public TeacherMapConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("T_Teacher");
            this.Property(t => t.Id).HasColumnName("TeacherID");
            this.Property(t => t.Name).HasColumnName("TeacherName");
          
        }
    }
}
