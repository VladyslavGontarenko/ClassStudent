using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudentA
{
    internal class Group : ICloneable, IComparable  /// <summary>
                                                    /// Выполняет хранение информации о группе студентов
                                                    /// </summary>
    {
        // private:
        Student[] group;
        int count;
        string name;
        string specialization;
        int num;

        void Sort()
        {
            Student tm;
            for (int i = 1; i < group.Length; ++i)
            {
                for (int j = 0; j < group.Length - i; ++j)
                {
                    if (group[j].GetFamilianame()[0] > group[j + 1].GetFamilianame()[0])
                    {
                        tm = group[j];
                        group[j] = group[j + 1];
                        group[j + 1] = tm;
                    }
                }
            }
        }
        // public:
        public Group()  /// <summary>
                        /// конструктор по умолчанию
                        /// </summary>
                        /// <code> Group name = new Group() </code>
        {
            SetCount(8);
            SetName("NewGroup");
            SetSpecialization("Programmiren");
            SetNum(1);
            group = new Student[8];
            for (int i = 0; i < count; i++)
            {
                group[i] = new Student();
            }

            Sort();
        }
        public Group(int count)  /// <summary>
                                 /// конструктор принимающий в себя к-во требуемых студентов
                                 /// <code> Group name(count) </code>
                                 /// </summary>
        {
            name = "NewGroup";
            specialization = "nicht";
            num = 1;
            this.count = count;
            group = new Student[count];
            for (int i = 0; i < count; i++)
            {
                group[i] = new Student();
            }

            Sort();
        }
        public Group(Student[] group)  /// <summary>
                                       /// конструктор принимающий в себя группу студентов
                                       /// <code> Group name(student_group) </code>
                                       /// </summary>
        {
            name = "NewGroup";
            specialization = "nicht";
            num = 1;
            this.group = group;
            count = group.Length;

            Sort();
        }
        public Group(Group eg)  /// <summary>
                                /// конструктор принимающий в себя другую группу
                                /// <code> Group name(group) </code>
                                /// </summary>
        {
            group = eg.group;
            count = eg.count;
            name = eg.name;
            specialization = eg.specialization;
            num = eg.num;

            Sort();
        }

        public void SetGroup(Student[] group)  /// <summary> переопределяет значение поля Group </summary>
        {
            this.group = group;
        }
        public void SetCount(int count)  /// <summary> переопределяет значение поля Count </summary>
        {
            this.count = count;
        }
        public void SetName(string name)  /// <summary> переопределяет значение поля Name </summary>
        {
            this.name = name;
        }
        public void SetSpecialization(string specialization)  /// <summary> переопределяет значение поля Specialization </summary>
        {
            this.specialization = specialization;
        }
        public void SetNum(int num)  /// <summary> переопределяет значение поля Num </summary>
        {
            this.num = num;
        }

        public Student[] GetGroup()  /// <summary> возвращает значение поля Group </summary>
        {
            return this.group;
        }
        public int GetCount()  /// <summary> возвращает значение поля Count </summary>
        {
            return this.count;
        }
        public string GetName()  /// <summary> возвращает значение поля Name </summary>
        {
            return this.name;
        }
        public string GetSpecialization()  /// <summary> возвращает значение поля Specialization </summary>
        {
            return this.specialization;
        }
        public int GetNum()  /// <summary> возвращает значение поля Num </summary>
        {
            return num;
        }

        public Student this[uint index]  /// <value> Переопределяет или возвращает значение для части поля Group </value>
        {
            get
            {
                return group[index];
            }
            set
            {
                AddStudent(value);
            }
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
        public string GSSpecialization  /// <value> Переопределяет или возвращает значение поля Specialization </value>
        {
            get
            {
                return specialization;
            }
            set
            {
                SetSpecialization(value);
            }
        }
        public int GSNum  /// <value> Переопределяет или возвращает значение поля Num </value>
        {
            get
            {
                return num;
            }
            set
            {
                SetNum(value);
            }
        }
        public int GSCount  /// <value> Переопределяет или возвращает значение поля Count </value>
        {
            get
            {
                return count;
            }
        }

        public void Print()  /// <summary> метод выводящий в консоль информацию записанную в объекте </summary>
        {
            Console.WriteLine($"{name} - {specialization}");
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{group[i].GetFamilianame()} {group[i].GetName()}");
            }
            Console.WriteLine();
        }
        public void PrintStudent(int num)  /// <summary> метод выводящий в консоль информацию о конкретном студене записанную в объекте </summary>
        {
            group[num - 1].Print();
        }
        public void AddStudent(Student s)  /// <summary> добавляет переданного студента в группу </summary>
        {
            count++;

            Student[] temp = group;
            group = new Student[count];
            int i = 0;
            for (; i < count - 1; i++)
            {
                group[i] = temp[i];
            }
            group[i] = s;

            Sort();
        }
        public void DeleteStudent(int num)  /// <summary> удаляет студента из группы по индексу </summary>
        {
            --count;

            Student[] temp = group;
            group = new Student[temp.Length - 1];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i == num)
                {

                }
                else if (i < num)
                {
                    group[i] = temp[i];
                }
                else
                {
                    group[i - 1] = temp[i];
                }
            }
        }
        public void FromToThis(Group a, int num)  /// <summary> переносит студента из одной группы в другую </summary>
        {
            this.AddStudent(a.GetGroup()[num - 1]);
            a.DeleteStudent(num - 1);
        }
        public void DeleteNSS()  /// <summary> удаление всех учеников не здавших зачет </summary>
        {
            for (int i = 0; i < group.Length; i++)
            {
                if (group[i].GetZ()[group[i].GetZ().Length - 1] <= 6)
                {
                    DeleteStudent(i);
                    i--;
                }
                else
                {

                }
            }
        }
        public void DeleteOBS()  /// <summary> удаление ученика с самой плохой успеваемостью </summary>
        {
            int numm = 0;

            int numb = group[0].GetSA();
            for (int i = 0; i < group.Length; i++)
            {
                if (group[i].GetSA() < numb)
                {
                    numm = i;
                    numb = group[i].GetSA();
                }
            }

            DeleteStudent(numm);
        }

        static public bool operator ==(Group a, Group b)
        {
            return a.GetCount() == b.GetCount();
        }
        static public bool operator !=(Group a, Group b)
        {
            return a.GetCount() != b.GetCount();
        }

        public object Clone()
        {
            return new Group(this);
        }
        public int CompareTo(object o)
        {
            Group re = (Group)o;

            if (this.GetCount() < re.GetCount())
            {
                return 1;
            }
            else if (this.GetCount() > re.GetCount())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public IEnumerator GetEnumerator() => new GroupEnumerator(this.group);
    }
    class GroupEnumerator : IEnumerator
    {
        Student[] group;
        int position = -1;
        public GroupEnumerator(Student[] group) => this.group = group;

        public object Current
        {
            get
            {
                if (position == -1 || position >= group.Length) throw new ArgumentException();
                return group[position];
            }
        }
        public bool MoveNext()
        {
            if (position < group.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset() => position = -1;
    }

    interface IEnumerable
    {
        IEnumerable GetEnumerator();
    }
    interface IEnumerator
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
    }
}
