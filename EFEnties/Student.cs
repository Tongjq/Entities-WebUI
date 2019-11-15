using EFEnties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[Table("T_Student")]
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //[ForeignKey("Class")]
        //public long Cid { get; set; }
        //[ForeignKey("Cid")]
        //public virtual Class Class { get; set; }
        public long ClassId { get; set; }
        public virtual Class Class { get; set; }
        public long TeacherId { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        public long StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

    }
}
