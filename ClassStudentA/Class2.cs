using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudentA
{
    public delegate void MyDelegate();

    internal class System
    {
        // static
        static Group a = new Group();
        static MyDelegate[] mg = new MyDelegate[4] { AddStudent, DeleteStudent, PrintGroup, Exit };

        static void AddStudent()
        {
            Student s = new Student();

            a.AddStudent(s);
            Console.ReadKey();
        }
        static void DeleteStudent()
        {
            int num = 0;

            a.DeleteStudent(num);
            Console.ReadKey();
        }
        static public void PrintGroup()
        {
            foreach (Student st in a)
            {
                st.Print();
            }
            Console.ReadKey();
        }
        static public void Exit()
        {
            Environment.Exit(0);
            Console.ReadKey();
        }

        // public
        public System()
        {
            a = new Group();
        }
        public System(Group a)
        {
            GSa = a;
        }

        public Group GSa
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }

        public void Menu()
        {
            vib:
            Console.Write("1.Add student\n2.Delete student\n3.Print group\n4.Exit\n:");
            int vib = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (vib > 0 && vib <= 4)
            {
                mg[vib - 1]();
                Console.Clear();
                goto vib;
            }
            else
            {
                goto vib;
            }
        }
    }
}