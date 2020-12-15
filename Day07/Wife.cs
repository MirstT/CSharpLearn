using System;

namespace Day07
{
    internal class Wife
    {
        //字段 存错数据
        //属性 保护字段
        //构造函数 提供创建对象的方式 初始化类的数据成员
        //方法 向类的外部提供某种功能

        private string name;
        private int age;
        private bool sex;

        //私有字段 小写开头， 属性当作方法，首字母大写
        //属性:保护字段，实质上还是操作字段，需要对应私有字段（）读写时保护
        //需要在类外访问读写的
        //内部操作的还是私有字段
        //get{return ;}
        //set{this.age=value;}
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 0 && value < 110)
                    this.age = value;
            }
        }

        //如果不希望在类的外部被创建对象，就将构造函数私有化 private
        public Wife()
        {
        }

        public Wife(string name) : this()
        {
            this.Name = name;
        }

        //构造函数  方便实例化
        //无返回值，与类同名
        public Wife(string name, int age) : this(name)
        {
            this.Age = age;//还是使用属性
        }

        public Wife(String name, int age, bool sex) : this(name, age)
        {
            this.sex = sex;//这个时候没有调用属性
        }

        public bool GetSex()
        {
            return this.sex;
        }

        public void SetSex(bool sex)
        {
            this.sex = sex;
        }
    }
}