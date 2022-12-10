using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    
    internal class Person
    {
        public delegate void Reaction(string m);
        public event Reaction React;
        public string name { get; set; }
        public string hobby { get; set; }
        public Person(string name, string hobby)
        {
            this.name = name;
            this.hobby = hobby;
        }
        public void Check(string q)
        {
            if (q.ToLower() == hobby.ToLower())
            {
                React.Invoke($"{name} рад событию");
            }
        }
    }
}
