using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    class Program
    {
        static void Main1(string[] args)
        {
            //继承 static 结构体

            //父类只能使用父类成员
            Person person01 = new Person();

            //子类可以使用父类成员
            Student stu01 = new Student();
            stu01.Name = "wh";

            //父类型的引用 指向 子类的对象
            //只能使用父类成员
            Person person02 = new Student();
            //如果需要访问该子类成员，需要强制类型转换
            //Student stu02 = (Student)person02;//报错
            //_ = stu02.Score;//报错
            //Teacher teacher02 = (Teacher)person02;
            Teacher teacher02 = person02 as Teacher;
            //teacher02.Salary=100;//报错
            if (teacher02!=null)
            {
                teacher02.Salary = 100;//不报错,这也是用as的原因
            }
            

        }

        static void Main()
        {
            //static
            Student stu01 = new Student();//0->1
            Student stu02 = new Student();//0->1
            Student stu03 = new Student();//0->1
            //需求：统计Student类，创建的对象数量

            Console.WriteLine(stu03.InstanceCount);//1
            Console.WriteLine(Student.StaticInstanceCount);//3

            Direction dir = Direction.Left;



        }
    }
}
