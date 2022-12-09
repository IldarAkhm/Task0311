using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Student
    {
        public List<string> events { get; set; } = new List<string>() { };
        public string name { get; }
        public Student(List<string> events, string name)
        {
            this.events = events;
            this.name = name;
        }
        public Student(string name)
        {
            this.name = name;
        }

    }
}
