﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassStudentA
{
    abstract class Persona : ICloneable, IComparable, IComparer  /// <summary>
                                                                 /// абстрактный родительский класс
                                                                 /// для класса Student
                                                                 /// </summary>
    {
        // private
        protected string name;
        protected string familianame;
        protected string vatername;
        protected MyDate geburtsdatum;

        // public
        abstract public void Print();
        abstract public object Clone();
        abstract public int CompareTo(object o);
        abstract public int Compare(object o1, object o2);
    }

    internal class Student : Persona  /// <summary>
                                      /// Потомок класса Persona
                                      /// Выполняет хранение информации о студенте
                                      /// </summary>
    {
        // private:
        protected string ort;
        protected int nummer;
        protected int[][] zke;

        protected delegate void Handler(string message);
        protected event Handler? Automath;
        // public:
        public Student()  /// <summary>
                          /// конструктор по умолчанию
                          /// </summary>
                          /// <code> Student name = new Student() </code>
        {
            SetName("Name");
            SetFamilianame("Familianame");
            SetVatername("Vatername");
            SetOrt("strasse");
            SetGeburtsdatum(new MyDate(2022, 09, 29));
            SetNummer(0);
            zke = new int[3][];
            zke[0] = new int[1] { 0 };
            zke[1] = new int[1] { 0 };
            zke[2] = new int[1] { 0 };
        }
        public Student(string name, string familianame, string vatername, string ort, MyDate geburtsdatum, int nummer, int[][] zke)  /// <summary>
                                                                                                                                     /// конструктор со всеми параметрами класса
                                                                                                                                     /// <code> Student name(string name, string familianame, string vatername, string ort, MyDate geburtsdatum, int nummer, int[][] zke) </code>
                                                                                                                                     /// </summary>
        {
            SetName(name);
            SetFamilianame(familianame);
            SetVatername(vatername);
            SetOrt(ort);
            SetGeburtsdatum(geburtsdatum);
            SetNummer(nummer);
            SetZke(zke);
        }
        public Student(Student s)  /// <summary>
                                   /// конструктор принимающий в себя другого студента
                                   /// <code> Student name(Student) </code>
                                   /// </summary>
        {
            SetName(s.name);
            SetFamilianame(s.familianame);
            SetVatername(s.vatername);
            SetOrt(s.ort);
            SetGeburtsdatum(s.geburtsdatum);
            SetNummer(s.nummer);
            SetZke(s.zke);
        }

        public void SetName(string name)  /// <summary> переопределяет значение поля Name </summary>
        {
            this.name = name;
        }
        public void SetFamilianame(string familianame)  /// <summary> переопределяет значение поля Familianame </summary>
        {
            this.familianame = familianame;
        }
        public void SetVatername(string vatername)  /// <summary> переопределяет значение поля Vatername </summary>
        {
            this.vatername = vatername;
        }
        public void SetOrt(string ort)  /// <summary> переопределяет значение поля Ort </summary>
        {
            this.ort = ort;
        }
        public void SetGeburtsdatum(MyDate geburtsdatum)  /// <summary> переопределяет значение поля Geburtsdatum </summary>
        {
            this.geburtsdatum = geburtsdatum;
        }
        public void SetNummer(int nummer)  /// <summary> переопределяет значение поля Nummer </summary>
        {
            this.nummer = nummer;
        }
        public void SetZke(int[][] zke)  /// <summary> переопределяет значение поля Zke </summary>
        {
            this.zke = new int[zke.Length][];
            for (int i = 0; i < zke.Length; i++)
            {
                this.zke[i] = new int[zke[i].Length];
                for (int j = 0; j < zke[i].Length; j++)
                {
                    this.zke[i][j] = zke[i][j];
                }
            }
        }
        public void SetZ(int z)  /// <summary> переопределяет значение части поля Zke </summary>
                                 /// <exception cref="score less than or equal to zero || over 12"> 
                                 /// если переданное значение меньше или равно нулю
                                 /// а так же если значение больше 12
                                 /// </exception>
        {
            try
            {
                if (z <= 0 || z > 12)
                {
                    throw new Exception("score less than or equal to zero || over 12\n");
                }
                else
                {
                    int[] tm = zke[0];
                    zke[0] = new int[tm.Length + 1];

                    int i = 0;
                    for (; i < tm.Length; i++)
                    {
                        zke[0][i] = tm[i];
                    }
                    zke[0][i] = z;
                    if (zke[0].Length > 11 && zke[0].Average() > 100)
                    {
                        Automath?.Invoke($"авто-зачет курсовой на {zke[0].Average()}");
                        zke[0] = new int[1];
                        zke[0][0] = 0;
                        SetK(Convert.ToInt32(zke[0].Average()));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SetK(int k)  /// <summary> переопределяет значение части поля Zke </summary>
                                 /// <exception cref="score less than or equal to zero || over 12"> 
                                 /// если переданное значение меньше или равно нулю
                                 /// а так же если значение больше 12
                                 /// </exception>
        {
            try
            {
                if (k <= 0 || k > 12)
                {
                    throw new Exception("score less than or equal to zero || over 12\n");
                }
                else
                {
                    int[] tm = zke[1];
                    zke[1] = new int[tm.Length + 1];

                    int i = 0;
                    for (; i < tm.Length; i++)
                    {
                        zke[1][i] = tm[i];
                    }
                    zke[1][i] = k;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SetE(int e)  /// <summary> переопределяет значение части поля Zke </summary>
                                 /// <exception cref="score less than or equal to zero || over 12"> 
                                 /// если переданное значение меньше или равно нулю
                                 /// а так же если значение больше 12
                                 /// </exception>
        {
            try
            {
                if (e <= 0 || e > 12)
                {
                    throw new Exception("score less than or equal to zero || over 12\n");
                }
                else
                {
                    int[] tm = zke[2];
                    zke[2] = new int[tm.Length + 1];

                    int i = 0;
                    for (; i < tm.Length; i++)
                    {
                        zke[2][i] = tm[i];
                    }
                    zke[2][i] = e;
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
        }

        public string GetName()  /// <summary> возвращает значение поля Name </summary>
        {
            return name;
        }
        public string GetFamilianame()  /// <summary> возвращает значение поля Familianame </summary>
        {
            return familianame;
        }
        public string GetVatername()  /// <summary> возвращает значение поля Vatername </summary>
        {
            return vatername;
        }
        public string GetOrt()  /// <summary> возвращает значение поля Ort </summary>
        {
            return ort;
        }
        public MyDate GetGeburtsdatum()  /// <summary> возвращает значение поля Geburtsdatum </summary>
        {
            return geburtsdatum;
        }
        public int GetNummer()  /// <summary> возвращает значение поля Nummer </summary>
        {
            return nummer;
        }
        public int[][] GetZke()  /// <summary> возвращает значение поля Zke </summary>
        {
            return zke;
        }
        public int[] GetZ()  /// <summary> возвращает значение части поля Zke </summary>
        {
            return zke[0];
        }
        public int[] GetK()  /// <summary> возвращает значение части поля Zke </summary>
        {
            return zke[1];
        }
        public int[] GetE()  /// <summary> возвращает значение части поля Zke </summary>
        {
            return zke[2];
        }

        public string GSName  /// <value> Переопределяет или возвращает значение поля Name </value>
        {
            get
            {
                return name;
            }
            set
            {
                SetName(value);
            }
        }
        public string GSFamilianame  /// <value> Переопределяет или возвращает значение поля Familianame </value>
        {
            get
            {
                return familianame;
            }
            set
            {
                SetFamilianame(value);
            }
        }
        public string GSVatername  /// <value> Переопределяет или возвращает значение поля Vatername </value>
        {
            get
            {
                return vatername;
            }
            set
            {
                SetVatername(value);
            }
        }
        public string GSOrt  /// <value> Переопределяет или возвращает значение поля Ort </value>
        {
            get
            {
                return ort;
            }
            set
            {
                SetOrt(value);
            }
        }
        public int GSGeburtsdatum  /// <value> Переопределяет или возвращает значение поля Geburtsdatum </value>
        {
            get
            {
                DateTime td = DateTime.Today;

                return Convert.ToInt32(td.Year) - geburtsdatum.GSYear;
            }
        }
        public int GSNummer  /// <value> Переопределяет или возвращает значение поля Nummer </value>
        {
            get
            {
                return nummer;
            }
            set
            {
                SetNummer(value);
            }
        }
        public int[][] GSZke  /// <value> Переопределяет или возвращает значение поля Zke </value>
        {
            get
            {
                return zke;
            }
            set
            {
                SetZke(value);
            }
        }

        public override void Print()  /// <summary> метод выводящий в консоль информацию записанную в объекте </summary>
        {
            Console.WriteLine(name);
            Console.WriteLine(familianame);
            Console.WriteLine(vatername);
            Console.WriteLine(ort);
            geburtsdatum.Print();
            Console.WriteLine(nummer);
            for (int i = 0; i < zke.Length; i++)
            {
                for (int j = 1; j < zke[i].Length; j++)
                {
                    Console.Write($"{zke[i][j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public int GetSA()   /// <summary> возвращает среднее арифметическое вссех баллов студента </summary>
        {
            int z = 0;

            for (int i = 0; i < zke.Length; i++)
            {
                for (int j = 0; j < zke[i].Length; j++)
                {
                    z = z + zke[i][j];
                }
            }

            return z;
        }

        public static bool operator ==(Student a, Student b)
        {
            if (a.name != b.name)
            {
                return false;
            }
            else if (a.familianame != b.familianame)
            {
                return false;
            }
            else if (a.vatername != b.vatername)
            {
                return false;
            }
            else if (a.ort != b.ort)
            {
                return false;
            }
            else if (a.geburtsdatum != b.geburtsdatum)
            {
                return false;
            }
            else if (a.nummer != b.nummer)
            {
                return false;
            }
            else if (a.zke != b.zke)
            {
                return false;
            }

            return true;
        }
        public static bool operator !=(Student a, Student b)
        {
            if (a.name != b.name)
            {
                return true;
            }
            else if (a.familianame != b.familianame)
            {
                return true;
            }
            else if (a.vatername != b.vatername)
            {
                return true;
            }
            else if (a.ort != b.ort)
            {
                return true;
            }
            else if (a.geburtsdatum != b.geburtsdatum)
            {
                return true;
            }
            else if (a.nummer != b.nummer)
            {
                return true;
            }
            else if (a.zke != b.zke)
            {
                return true;
            }

            return false;
        }

        public static bool operator >(Student a, Student b)
        {
            return a.GetSA() > b.GetSA();
        }
        public static bool operator <(Student a, Student b)
        {
            return a.GetSA() < b.GetSA();
        }

        public override object Clone()
        {
            return new Student(this);
        }
        public override int CompareTo(object o)
        {
            Student re = (Student)o;

            if (this.GetSA() < re.GetSA())
            {
                return 1;
            }
            else if (this.GetSA() > re.GetSA())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public override int Compare(object o1, object o2)
        {
            Student re = (Student)o1;
            Student rd = (Student)o2;

            if (re.GetSA() < rd.GetSA())
            {
                return 1;
            }
            else if (re.GetSA() > rd.GetSA())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    class Aspirant : Student  /// <summary>
                              /// Потомок класса Student
                              /// Выполняет хранение информации о аспиранте
                              /// </summary>
    {
        // private
        string desertationtheme;

        // public
        public Aspirant()  /// <summary>
                           /// конструктор по умолчанию
                           /// </summary>
                           /// <code> Aspirant name = new Aspirant() </code>
        {
            SetName("Name");
            SetFamilianame("Familianame");
            SetVatername("Vatername");
            SetOrt("strasse");
            SetGeburtsdatum(new MyDate(2022, 09, 29));
            SetNummer(0);
            zke = new int[3][];
            zke[0] = new int[1] { 0 };
            zke[1] = new int[1] { 0 };
            zke[2] = new int[1] { 0 };
            desertationtheme = "desertationtheme";
        }
        public Aspirant(string name, string familianame, string vatername, string ort, MyDate geburtsdatum, int nummer, int[][] zke, string desertationtheme)  /// <summary>
                                                                                                                                                               /// конструктор со всеми параметрами класса
                                                                                                                                                               /// <code> Aspirant name(string name, string familianame, string vatername, string ort, MyDate geburtsdatum, int nummer, int[][] zke, string desertationtheme) </code>
                                                                                                                                                               /// </summary>
        {
            SetName(name);
            SetFamilianame(familianame);
            SetVatername(vatername);
            SetOrt(ort);
            SetGeburtsdatum(geburtsdatum);
            SetNummer(nummer);
            SetZke(zke);
            SetDesertationtheme(desertationtheme);
        }
        public Aspirant(Aspirant a)  /// <summary>
                                     /// конструктор принимающий в себя другого студента
                                     /// <code> Aspirant name(Aspirant) </code>
                                     /// </summary>
        {
            SetName(a.name);
            SetFamilianame(a.familianame);
            SetVatername(a.vatername);
            SetOrt(a.ort);
            SetGeburtsdatum(a.geburtsdatum);
            SetNummer(a.nummer);
            SetZke(a.zke);
            SetDesertationtheme(a.desertationtheme);
        }

        public void SetDesertationtheme(string desertationtheme)  /// <summary> переопределяет значение поля Desertationtheme </summary>
        {
            this.desertationtheme = desertationtheme;
        }
        public string GetDesertationtheme()  /// <summary> возвращает значение поля Desertationtheme </summary>
        {
            return this.desertationtheme;
        }

        public string GSDesertationtheme  /// <value> Переопределяет или возвращает значение поля Desertationtheme </value>
        {
            get
            {
                return this.desertationtheme;
            }
            set
            {
                SetDesertationtheme(value);
            }
        }

        public override void Print()   /// <summary> метод выводящий в консоль информацию записанную в объекте </summary>
        {
            base.Print();
            Console.WriteLine(desertationtheme);
        }
        public override object Clone()
        {
            return new Aspirant(this);
        }
        public override int CompareTo(object o)
        {
            Aspirant re = (Aspirant)o;

            if (this.GetSA() < re.GetSA())
            {
                return 1;
            }
            else if (this.GetSA() > re.GetSA())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public override int Compare(object o1, object o2)
        {
            Aspirant re = (Aspirant)o1;
            Aspirant rd = (Aspirant)o2;

            if (re.GetSA() < rd.GetSA())
            {
                return 1;
            }
            else if (re.GetSA() > rd.GetSA())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    interface IClonable
    {
        object Clone();
    }
    interface IComparable
    {
        int CompareTo(object o);
    }
    interface IComparer
    {
        int Compare(object o1, object o2);
    }
}
