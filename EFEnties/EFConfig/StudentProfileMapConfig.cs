using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFEnties.EFConfig
{
    public class StudentProfileMapConfig: EntityTypeConfiguration<StudentProfile>
    {
        public StudentProfileMapConfig()
        {
            HasKey(s => s.Id);
            // 主键不自动增加
            Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // 设置StudentProfile实体类的CardId在生成的数据库表的列名为身份证号码
            Property(s => s.CardId).HasColumnName("身份证号码");
            // StudentProfile实体类生成的数据库表名为T_StudentProfile
            ToTable("T_StudentProfile");
        }
    }
}
