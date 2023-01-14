using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStudentA
{
    internal class Group : ICloneable, IComparable
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
        public Group()
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
        public Group(int count)
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
        public Group(Student[] group)
        {
            name = "NewGroup";
            specialization = "nicht";
            num = 1;
            this.group = group;
            count = group.Length;

            Sort();
        }
        public Group(Group eg)
        {
            group = eg.group;
            count = eg.count;
            name = eg.name;
            specialization = eg.specialization;
            num = eg.num;

            Sort();
        }

        public void SetGroup(Student[] group)
        {
            this.group = group;
        }
        public void SetCount(int count)
        {
            this.count = count;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetSpecialization(string specialization)
        {
            this.specialization = specialization;
        }
        public void SetNum(int num)
        {
            this.num = num;
        }

        public Student[] GetGroup()
        {
            return this.group;
        }
        public int GetCount()
        {
            return this.count;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetSpecialization()
        {
            return this.specialization;
        }
        public int GetNum()
        {
            return num;
        }

        public Student this[uint index]
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
        public string GSName
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
        public string GSSpecialization
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
        public int GSNum
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
        public int GSCount
        {
            get
            {
                return count;
            }
        }

        public void Print()
        {
            Console.WriteLine($"{name} - {specialization}");
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{group[i].GetFamilianame()} {group[i].GetName()}");
            }
            Console.WriteLine();
        }
        public void PrintStudent(int num)
        {
            group[num - 1].Print();
        }
        public void AddStudent(Student s)
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
        public void DeleteStudent(int num)
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
        public void FromToThis(Group a, int num)
        {
            this.AddStudent(a.GetGroup()[num - 1]);
            a.DeleteStudent(num - 1);
        }
        public void DeleteNSS()
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
        public void DeleteOBS()
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
