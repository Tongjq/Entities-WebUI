using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Class
    {
        public long ClassId { get; set; }
        public string Name { get; set; }  
    
        //这个属性可要可不要，很多人不建议双向的关联导航属性，多了容易混乱
        public ICollection<Student> Students { get; set; }
    }
}
