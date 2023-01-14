using System.Text.RegularExpressions;

namespace ClassStudentA
{
    struct MyDate
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

        public int GSDay
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
        public int GSMonth
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
        public int GSYear
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

        public void Print()
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

            System s = new System();
            s.Menu();
        }
    }
}