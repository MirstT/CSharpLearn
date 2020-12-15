using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //标准数字格式字符串
            char c1 = '\'';
            char c2 = '\0';
            Console.WriteLine("Hi,\r\ntest\r\test;");
            Console.WriteLine("金额：{0:c0}",10);
            Console.WriteLine("{0:d2}",5);
            Console.WriteLine("{0:d2}",15);

            Console.WriteLine("{0:f1}", 1.26);
            Console.WriteLine("{0:p0}", 0.1);
            //Array.Sort()

            int n1 = 5, n2 = 2;
            int r1 = n1 / n2;
            float r2 = n1 / n2;
            float r22 = n1 / n2;
            int r3 = n1 / n2;

            bool rr = n1 % 2 == 0;

            int intnum = n1 % 10;

            //（）显示转换
            int i4 = 300;
            byte b4 = (byte)i4;

            byte number1 = 1;
            short number2 = 2;
            short result = (short)(number1 + number2);
            int resultttt = number1 + number2;
            //byte short （太小了）相加为int（超范围）
            //自动向较大类型提升

            byte b = 1;
            b += 3;
            //b = b + 3; 不等效 快捷运算符不做自动类型提升
            b = (byte)(b + 3);
        }
    }
}
