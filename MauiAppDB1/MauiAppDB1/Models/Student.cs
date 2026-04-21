using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDB1.Models
{
    public class Student
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? dept_name { get; set; }

        public string? gpa { get; set; }
        public string? email { get; set; }
    }
}
