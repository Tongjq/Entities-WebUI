using EFEnties;
using Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;

namespace MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (DataContext dbContext = new DataContext())
            {
                List<Student> students = new List<Student>
                {
                    new Student{ Id=2,Name="lisi",Age=6, StudentProfile=new StudentProfile{ CardId="22222"},  Class=new Class{ ClassId=1,Name="三年二班"} },
                    new Student{ Id=3,Name="wangwu",Age=7,StudentProfile=new StudentProfile{ CardId="22222"},Class= new Class{ ClassId=2,Name="五年三班"} },
                    new Student{ Id=1,Name="zhangsan",Age=2,StudentProfile=new StudentProfile{ CardId="22222"},Class=new Class{ ClassId=1,Name="小二班"} },
                    new Student{ Id=4,Name="zhaoliu",Age=3,StudentProfile=new StudentProfile{ CardId="22222"},Class=new Class{ ClassId=2,Name="大班"} }
                    //new Student{ Id=2,Name="lisi",Age=6,ClassId=1,Class=   new Class{ Id=1,Name="三年二班"} },
                    //new Student{ Id=3,Name="wangwu",Age=7,ClassId=2,Class= new Class{ Id=2,Name="五年三班"} },
                    //new Student{ Id=1,Name="zhangsan",Age=2,ClassId=1,Class=new Class{ Id=1,Name="小二班"} },
                    //new Student{ Id=4,Name="zhaoliu",Age=3,ClassId=2,Class=new Class{ Id=2,Name="大班"} }
                };

                dbContext.Students.AddRange(students);   
                dbContext.SaveChanges();

            }
            return Content("ok");
        }
    }
}