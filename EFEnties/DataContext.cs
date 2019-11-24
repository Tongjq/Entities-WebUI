using EFEnties.EFConfig;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFEnties
{
    public class DataContext:DbContext
    {
        public DataContext() : base("name=conStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 实体模型有变化就删除从新创建
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            // 禁用一对多级联删除
            modelBuilder.Conventions
                .Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();

            // 禁用多对多级联删除
            modelBuilder.Conventions
                .Remove<System.Data.Entity.ModelConfiguration.Conventions.ManyToManyCascadeDeleteConvention>();
            // 禁用延迟加载
            this.Configuration.LazyLoadingEnabled = false;



            //从某个程序集中加载所有继承自EntityTypeConfiguration类到配置中
            // modelBuilder.Configurations.AddFromAssembly(Assembly.Load("程序集名称"));

            //Assembly.GetExecutingAssembly()当前代码的程序集
            modelBuilder.Configurations.AddFromAssembly
                (Assembly.GetExecutingAssembly());


            //加载对应的数据库映射配置文件类
            //modelBuilder.Configurations.Add(new StudentMapConfig());
            //modelBuilder.Configurations.Add(new ClassMapConfig());
            //modelBuilder.Configurations.Add(new TeacherMapConfig());
            //modelBuilder.Configurations.Add(new StudentProfileMapConfig());




            #region MyRegion
            /*
              // 禁用一对多级联删除
              modelBuilder.Conventions
                  .Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();


              // 禁用多对多级联删除
              modelBuilder.Conventions
                  .Remove<System.Data.Entity.ModelConfiguration.Conventions.ManyToManyCascadeDeleteConvention>();
              // 禁用延迟加载
              this.Configuration.LazyLoadingEnabled = false;

              // 禁用默认表名复数形式
              modelBuilder.Conventions
                  .Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

              // 数据库中不存在就创建，存在就不创建
              //Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
              // 实体模型有变化就删除从新创建
              Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
              // 每次都先删除，再重新创建
              //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
              // 关闭数据库初始化功能，运行程序的时候EF不会帮我们创建或者删除数据库
              // Database.SetInitializer<DataContext>(null); 
              #endregion

              modelBuilder.Entity<Student>().ToTable("T_Student");
              modelBuilder.Entity<Class>().ToTable("T_Class");

              //Student或者Class只配置其中一个即可
              //一个Student对应多一个Class
              modelBuilder.Entity<Student>()
                  .HasRequired<Class>(c => c.Class)
                  .WithMany(s=>s.Students)
                  .HasForeignKey(k=>k.Cid)
                  .WillCascadeOnDelete(false);

              //一个Class对用多个Student
              //modelBuilder.Entity<Class>()
              //    .HasMany<Student>(s => s.Students)
              //    .WithRequired(c => c.Class)
              //    .HasForeignKey(k=>k.Cid);


              modelBuilder.Entity<Student>().Property(s => s.Id).IsRequired();
              modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired()
                  .HasColumnName("StudentName")
                  .HasMaxLength(30);*/ 
            #endregion

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
    }
}
