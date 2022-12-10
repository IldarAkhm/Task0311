using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
     
    
    internal class Program
    { 
        static void Main(string[] args)
        {
            List<Person> listperson = new List<Person>
            {
                new Person("Ильдар", "Кино"),
                new Person("Илназ", "Сериал"),
                new Person("Илья", "Комиксы")
            };
            Console.WriteLine("Введите название вашего события");
            string even_t = Console.ReadLine();
            foreach (var i in listperson)
            {
                if (i.hobby.ToLower() == even_t.ToLower())
                {
                    i.React += Message;
                    i.Check(even_t);
                }
            }



            Console.Read();
         
        }
        public static void Message(string msg) { Console.WriteLine(msg); }
    }
}
