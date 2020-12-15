using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    class Student:Person
    {
        //prop tab tab
        public int Score { get; set; }

        public int InstanceCount { get;}
        //仅仅存储一份，所有对象共享
        public static int StaticInstanceCount;

        public Student()
        {
            StaticInstanceCount++;
            InstanceCount++;
        }
    }
}
