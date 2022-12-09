using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Task1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string filepath_students = @"C:\Users\ahmet\Desktop\Студенты и группа.txt";
            string filepath_events = @"C:\Users\ahmet\Desktop\Мер с участ.txt";
            Program.FileCreatorAndOverwriting(filepath_events, @"C:\Users\ahmet\Desktop\DZ\Task0312\Task0312\Task1\Files\Events_and_countstud.txt");
            Program.FileCreatorAndOverwriting(filepath_students, @"C:\Users\ahmet\Desktop\DZ\Task0312\Task0312\Task1\Files\Students.txt");

            List<Event> events = new List<Event>(); // Список с обьектами Event(события)
            using (StreamReader rd = new StreamReader(filepath_events)) // Считываем с файла события и нужное кол-во людей и добавляем в список событий
            {
                string fille = rd.ReadLine();
                while (fille != null)
                {
                    string[] b = fille.Split();
                    int cnt;
                    if (int.TryParse(b[1], out cnt))
                    {
                        events.Add(new Event(b[0], cnt));
                    }
                    else { events.Add(new Event(b[0] + b[1], Convert.ToInt32(b[2]))); }
                    fille = rd.ReadLine();
                }
            }
            List<List<string>> studevent = new List<List<string>>(events.Count()); // мероприятие и люди желающие там участвовать
            
            foreach (var q in events)
            {
                List<string> s = new List<string>();
                s.Add(q.name);
                studevent.Add(s);
            }
            
           

            List<Student> students = new List<Student>(); // список со студентами и их мероприятиями

            List<Student> studoutsiders = new List<Student>(); // студенты которые нигде не участвуют
            using (StreamReader rw = new StreamReader(filepath_students)) // смотрим на желания студентов
            {
                string variable = rw.ReadLine();
                while (variable != null)
                {
                    
                    string[] a = variable.Split();
                    
                    List<string> s = new List<string>();
                    foreach (var q in studevent)
                    {
                        for (int i = 3; i < a.Count(); i++)
                        {

                            if (q.Contains(a[i])) { q.Add(a[0] + a[1]);s.Add(a[i]); a[i] = "";  }
                            
                        }
                    }
                    students.Add(new Student(s, a[0] + a[1]));
                    variable = rw.ReadLine();
                }
            }
            

            
            foreach (var y in students) // находим студентов оутсайдеров 
            {
                if (y.events.Count() == 0)
                {
                    studoutsiders.Add(y);
                }
                else
                {
                    foreach (var i in events)
                    {
                        if (y.events.Contains(i.name))
                        {
                            i.cntagree += 1;
                            i.students.Add(y.name);
                        }
                    }
                }
            }

            foreach (var i in studoutsiders) // заполняем оутсайдерами оставшиейся места
            {
                foreach (var q in events)
                {
                    if (q.cntagree != q.cnt)
                    {
                        i.events.Add(q.name);
                        q.cntagree += 1;
                        q.students.Add(i.name);
                        continue;
                    }
                }
            }
            
            foreach (var q in events)
            {
                Console.WriteLine(q.name);
                foreach (var i in q.students)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            string filepath_participants = @"C:\Users\ahmet\Desktop\мероприятия и участники.txt";
            Program.FileCreatorAndOverwriting(filepath_participants);
            using (StreamWriter srt = new StreamWriter(filepath_participants, true))
            {
                foreach (var s in events)
                {
                    srt.WriteLine(s.name);
                    foreach (var q in s.students)
                    {
                        srt.Write(" " + q);
                    }
                    srt.WriteLine();
                }
            }
            

            Console.Read();
        }
        
        public static void FileCreatorAndOverwriting(string filepath, string file2) //Метод для проверки наличия файлов и заполнения
        {
            if (File.Exists(filepath)) { FileCreatorAndOverwriting(filepath); }
            else
            {
                using (FileStream file = new FileStream(filepath, FileMode.Append))
                {
                    using (StreamReader fps = new StreamReader(file2, Encoding.Default))
                    {
                        using (StreamWriter st = new StreamWriter(file))
                        {
                            st.Write(fps.ReadToEnd());
                        }
                    }

                }
            }
        }
        public static void FileCreatorAndOverwriting(string filepath) { using (FileStream file = new FileStream(filepath, FileMode.OpenOrCreate)) ; }


    }
}