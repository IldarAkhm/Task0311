using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Event
    {
        public string name { get; set; }
        public int cnt { get; set; }
        public int cntagree { get; set; } = 0;
        public List<string> students { get; } = new List<string>() { };
        public Event(string name, int cnt)
        {
            this.name = name;
            this.cnt = cnt;
        }
        public Event() { }
    }
}
