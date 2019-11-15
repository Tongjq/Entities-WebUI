using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEnties
{
    public class StudentProfile
    {
        public long Id { get; set; }
        public string CardId { get; set; }
        public virtual Student Student { get; set; }
    }
}
