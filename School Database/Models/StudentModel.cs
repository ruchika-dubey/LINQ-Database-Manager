using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Database.Models
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }

        public int Age { get; set; }

        public int OOPS_Marks { get; set; }
        public int C_Marks { get; set; }
    }
}

