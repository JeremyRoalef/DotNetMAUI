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

        public Student()
        {

        }

        public Student(string id, string name, string dept_name, string gpa, string email)
        {
            this.id = id;
            this.name = name;
            this.dept_name = dept_name;
            this.gpa = gpa;
            this.email = email;
        }

        public bool Equals(Student other)
        {
            return other.id == id &&
                other.name == name &&
                other.email == email &&
                other.gpa == gpa &&
                other.dept_name == dept_name;
        }
    }
}
