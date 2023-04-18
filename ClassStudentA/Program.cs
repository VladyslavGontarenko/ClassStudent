using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ClassStudentA
{
    struct MyDate  /// <summary> 
                   /// MyDate - альтернатива класса DataTime 
                   /// хранит информацию о дне ,месяце и годе
                   /// </summary>
                   /// <code> MyDate name(Year, Month, Day) </code>
    {
        // private
        int Day;
        int Month;
        int Year;

        // public
        public MyDate()
        {
            Day = 0;
            Month = 0;
            Year = 0;
        }
        public MyDate(int Year, int Month, int Day)
        {
            GSDay = Day;
            GSMonth = Month;
            GSYear = Year;
        }

        public int GSDay  /// <value> Переопределяет или возвращает значение поля Day </value>
        {
            get
            {
                return Day;
            }
            set
            {
                Day = value;
            }
        }
        public int GSMonth  /// <value> Переопределяет или возвращает значение поля Month </value>
        {
            get
            {
                return Month;
            }
            set
            {
                Month = value;
            }
        }
        public int GSYear  /// <value> Переопределяет или возвращает значение поля Year </value>
        {
            get
            {
                return Year;
            }
            set
            {
                Year = value;
            }
        }

        public void Print()   /// <summary> метод выводящий в консоль информацию записанную в объекте </summary>
        {
            Console.WriteLine($"{Day}.{Month}.{Year}");
        }

        public static bool operator ==(MyDate a, MyDate b)
        {
            if(a.GSDay != b.GSDay)
            {
                return false;
            }
            else if(a.GSMonth != b.GSMonth)
            {
                return false;
            }
            else if(a.GSYear != b.GSYear)
            {
                return false;
            }

            return true;
        }
        public static bool operator !=(MyDate a, MyDate b)
        {
            if (a.GSDay != b.GSDay)
            {
                return true;
            }
            else if (a.GSMonth != b.GSMonth)
            {
                return true;
            }
            else if (a.GSYear != b.GSYear)
            {
                return true;
            }

            return false;
        }
    }

    class StateSaver
    {
        //public:
        public void SaveStudent(Student s, string file)
        {
            string jstring = JsonSerializer.Serialize(s);
            File.WriteAllText(file, jstring);
        }
        public void SaveGroup(Group g, string file)
        {
            string jstring = JsonSerializer.Serialize(g);
            jstring += JsonSerializer.Serialize(g.GetGroup());
            File.WriteAllText(file, jstring);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[][] zke = new int[3][];
            for (int i = 0; i < zke.Length; i++)
            {
                zke[i] = new int[5];
                zke[i][0] = 0;
            }
            for (int i = 0; i < zke.Length; i++)
            {
                for (int j = 0; j < zke[i].Length; j++)
                {
                    zke[i][j] = rnd.Next(1, 13);
                }
            }

            Student[] arr = new Student[4];
            arr[0] = new Student("Greg", "Dregorevich", "Gregoriev", "waldstrasse", new MyDate(2022, 10, 07), 987654321, zke);
            arr[1] = new Student("Greg", "Cregorevich", "Gregoriev", "waldstrasse", new MyDate(2022, 10, 07), 987654321, zke);
            arr[2] = new Student("Greg", "Bregorevich", "Gregoriev", "waldstrasse", new MyDate(2022, 10, 07), 987654321, zke);
            arr[3] = new Student("Greg", "Aregorevich", "Gregoriev", "waldstrasse", new MyDate(2022, 10, 07), 987654321, zke);

            Group gr = new Group(arr);

            StateSaver r = new StateSaver();
            r.SaveStudent(arr[0], @"C:\Users\ирина\Desktop\GitHub\ClassStudent\ClassStudentA\st3.json");
            r.SaveGroup(gr, @"C:\Users\ирина\Desktop\GitHub\ClassStudent\ClassStudentA\st3.json");
        }
    }
}