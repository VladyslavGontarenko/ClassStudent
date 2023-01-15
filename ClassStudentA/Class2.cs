using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudentA
{
    public delegate void MyDelegate();

    internal class System  /// <summary>
                           /// Используется для реализации интерфейса, управления группой, пользователем
                           /// </summary>
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
        public System()  /// <summary>
                         /// конструктор по умолчанию
                         /// </summary>
                         /// <code> System name = new System() </code>
        {
            a = new Group();
        }
        public System(Group a)  /// <summary>
                                /// конструктор принимающий в группу
                                /// <code> System name(group) </code>
                                /// </summary>
        {
            GSa = a;
        }

        public Group GSa  /// <value> Переопределяет или возвращает значение поля Group a </value>
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

        public void Menu()  /// <summary> осуществляет управление интерфейсом, пользователем </summary>
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