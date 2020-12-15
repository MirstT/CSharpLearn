using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    class Person
    {
        private int privateTest;
        public int publicTest;
        //仅仅本“家族”使用
        protected int protectedTest;
        public string Name { get; set; }
    }
}
