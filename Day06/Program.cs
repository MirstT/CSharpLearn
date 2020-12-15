using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    class Program
    {
        static void Main1(string[] args)
        {

            int num = 1;
            refTest(ref num);
            Console.WriteLine(num);
            outTest(out num);
            Console.WriteLine(num);
        }

        //值参数
        //作用:传递数据

        //引用参数
        //作用:改变数据
        private static void refTest(ref int a)
        {
            a = 3;
        }

        //输出参数
        //作用：返回结果 多个out,多个返回
        //参数需要的仅仅是接受方法的结果，因此参数传递之前无需赋值
        private static void outTest(out int a)
        {
            //1.方法内部 输出参数函数内部必须赋值
            //传递之前可以不为参数赋值
            a = 4;
        }

        private static void mySwap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void mySquare(int length,int width,out int m2,out int l2)
        {
            m2 = length * width;
            l2 = (length + width) * 2;
        }

        static void Main2()
        {
            int a = 1;
            int b = a;

            //装箱："比较"消耗性能（最）
            object o = a;
            a = 2;
            Console.WriteLine(o);
            Console.ReadLine();

            //拆箱：“比较”消耗性能
            b = (int)o;


            int num = 100;
            //不存在装箱
            string str = num.ToString();
            string str02 = num.ToString() + "";

            //存在装箱！！！！！！！
            str02 = num + "";
            //string str02 = string.Concat("", num); //int==>object
        }

        //形参object类型，实参传递值类型，则装箱
        //可以通过重载，泛型避免。
        private static void Fun1(int obj)
        {
        }

        static void Main444()
        {
            string s1 = "ddd";
            string s2 = "ddd";
            string s3 = new string(new char[] { 'd', 'd', 'd' });
            string s4 = new string(new char[] { 'd', 'd', 'd' });

            bool r1 = object.ReferenceEquals(s1, s2);
            bool r2 = object.ReferenceEquals(s1, s3);
            bool r3 = object.ReferenceEquals(s3, s4);


            //避免不断开辟新空间
            //可变字符串，一次开辟可以容纳n个字符大小的空间
            //优点:可以在原有空间修改字符串，避免产生垃圾
            //适用性：频繁对字符串操作（增，替换，移除）
            StringBuilder builder = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {
                builder.Append(i);
            }
            builder.Append("超出重新new");
            //可变字符串，无须接收，
            builder.Insert(0, "dfs");
            string result = builder.ToString();

            //string 开辟新空间，insert需要重新接收
            string str = "dfsadf";
            str = str.Insert(0, "dfs");
        }

        static void Main()
        {
            string s = "How are you";
            Console.WriteLine(s);
            string[] ss= s.Split(' ');
            for (int i = ss.Length-1; i >=0; i--)
                Console.Write(ss[i]+" ");
            Console.WriteLine();
            for (int i = ss.Length - 1; i >= 0; i--)
            {
                for (int j = ss[i].Length-1; j >=0; j--)
                {
                    Console.Write(ss[i][j]);
                }
                Console.Write(" ");
            }
            Console.WriteLine();

            string testStr = "dfadfasdfasdfwwwdffqx";
            StringBuilder noRepeatStr = new StringBuilder(testStr.Length);
            ArrayList singleList = new ArrayList();

            for (int i = 0; i < testStr.Length; i++)
            {
                if (testStr.IndexOf(testStr[i]) == testStr.LastIndexOf(testStr[i]))
                    noRepeatStr.Append(testStr[i]);
                if (!singleList.Contains(testStr[i]))
                    singleList.Add(testStr[i]);
            }
            StringBuilder singleStr = new StringBuilder(singleList.Capacity);
            foreach (var item in singleList)
                singleStr.Append(item);

            Console.WriteLine(noRepeatStr);
            Console.WriteLine(singleStr);
            testStr.ToCharArray();

            Console.ReadLine();
        }
    }
}
