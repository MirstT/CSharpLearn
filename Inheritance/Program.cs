using System;

namespace Inheritance
{
    internal class Employee
    {
        public virtual void EmpInfo()
        {
            Console.WriteLine("用virtual关键字修饰的方法是虚拟方法");
        }
    }

    internal class DervEmployee : Employee
    {
        public override void EmpInfo()
        {
            base.EmpInfo();//base关键字将在下面拓展中提到
            Console.WriteLine("该方法重写base方法");
        }
    }

    internal class Test
    {
        private static void Main(string[] args)
        {
            Employee test = new Employee();
            test.EmpInfo();
            Console.WriteLine("------------------------");
            DervEmployee objDervEmployee = new DervEmployee();
            objDervEmployee.EmpInfo();
            Console.WriteLine("------------------------");
            //注意：objDervEmployee派生类的实例是赋给Employee类的objEmployee的引用，
            // 所以objEmployee引用调用EmpInfo()方法时 还是调用DervEmployee类的方法
            Employee objEmployee = objDervEmployee;
            objEmployee.EmpInfo();
            Console.ReadLine();
        }
    }
}