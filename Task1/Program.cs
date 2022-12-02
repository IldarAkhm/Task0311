using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace Task1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Создание мероприятий
            Event hakaton = new Event("Хакатон", 5);
            Event funnystarts = new Event("Веселые старты", 5);
            Event misterIvmiit = new Event("Мистер Ивмиит", 1);
            Event Dota = new Event("Дота", 5);
            Event CSGO = new Event("КСГО", 5);
            Event MIssisIvmiit = new Event("Миссис Ивмиит", 5);
            Event Final = new Event("Финал", 30);

            List<Event> events = new List<Event>() { hakaton, funnystarts, misterIvmiit,
                Dota, CSGO, MIssisIvmiit, Final 
            };

            // Работа с Файлом студентов
            string filepath1 = @"C:\Users\ahmet\Desktop\Студенты и группа.txt";
            List<string[]> students = new List<string[]>();
            List<List<string>> students2 = new List<List<string>>();
            
            // Работа с файлом мероприятие 1 - запись мероприятий в файл
            string filepath2 = @"C:\Users\ahmet\Desktop\Мероприятия и участники.txt";
            using (StreamWriter streamWriter = new StreamWriter(filepath2))
            {
                try
                {
                    foreach (var i in events)
                    {
                        streamWriter.WriteLine(i.name);
                    }
                }
                catch { }

            }
            
            //CheckFile(filepath1, ref students);
            CheckMass(students, ref students2);
            foreach (var i in students)
            {
                foreach (var q in events)
                {
                    if (i.Contains(q.name))
                    {
                        RedactFile(filepath2, events, i[0], i[1], i[2]);
                        Console.WriteLine(i[0], i[1], i[2], q.name);
                    }
                    
                }
            }





            Console.Read();
        }
        public static void RedactFile(string b, List<Event> a, string q, string w, string e)
        {
            using (StreamWriter streamWriter = new StreamWriter(b, true))
            {
                streamWriter.Write(q, w, e);
            }

        }

        public static void CheckFile(string b, ref List<string[]> j)
        {
            using (StreamReader streamReader = new StreamReader(b))
            {
                string a = "fff";
                while (a != null)
                {
                    try
                    {
                        a = streamReader.ReadLine();
                        Console.WriteLine(a);
                        j.Add(a.Split());
                        
                    }
                    catch { }
                }
                

            }
        }
        public static void CheckMass(string[] a, ref List<List<string>> b)
        {
            
            foreach (var j in b)
            {
                
                foreach (var i in a) 
                {
                    j.Add(i); Console.WriteLine(i);
                }
            }
            Console.Write("\n");
            
        }
        public static void CheckMass(List<string[]> a, bool b)
        {

            foreach (var i in a)
            {
                foreach (var q in i)
                {
                    Console.Write(q + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

        }
    }
}
