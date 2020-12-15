using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    class Program
    {

        static void Main()
        {
            string gunName;
            int gunBulletCapacity;
            int gunBulletCurrentNum;
            int gunBulletRemainNum;
            Console.WriteLine("名称：");
            gunName = Console.ReadLine();
            Console.WriteLine("容量:");
            gunBulletCapacity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("数量:");
            gunBulletCurrentNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("剩余:");
            gunBulletRemainNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("名称:" + gunName + " 容量:"
                + gunBulletCapacity + " 数量:" + gunBulletCurrentNum +
                " 剩余:" + gunBulletRemainNum);
            
            Console.WriteLine(string.Format("名称：{0}，容量：{1}，数量：{2}，" +
                "剩余：{3}", 
                gunName, gunBulletCapacity, gunBulletCurrentNum, 
                gunBulletRemainNum));
            Console.ReadLine();
        }
        static void Maintest(string[] args)
        {
            Console.Title = "hello_world";
            Console.WriteLine("hello,world");
            string input = Console.ReadLine();
            Console.WriteLine("test" + input);

            float num1 = 1.0f;
            float num2 = 0.9f;
            float result = num1 - num2;
            bool b1 = result == 0.1f;
            Console.WriteLine(b1);

            decimal num3 = 1.0m;
            decimal num4 = 0.9m;
            decimal result2 = num3 - num4;
            bool b2 = result2 == 0.1m;
            Console.WriteLine(result2);
            Console.WriteLine(b2);
            Console.ReadLine();
        }
    }
}
