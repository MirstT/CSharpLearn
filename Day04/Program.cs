using System;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetAnswer(4));

            PrintTest(40);

            //声明
            int[] array;
            //初始化new数据类型[容量]
            array = new int[6];
            //通过索引读写每个元素
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 3;
            array[4] = 5;
            array[5] = 6;

            Console.WriteLine(array[0]);
            Console.WriteLine(array[1]);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("for");
                Console.WriteLine(array[i]);
            }

            foreach (int aItem in array)
            {
                Console.WriteLine("foreach");
                Console.WriteLine(aItem);
            }

            var aa = 2;
            var bb = "dd";

            Array.IndexOf(array,2);
            //Array.Copy();

            //声明 父类类型   赋值 子类对象
            Array arr01 = new int[2];
            Array arr02 = new string[3];

            PrintElement(new int[] { 12, 22, 33, 44 });
            PrintElement(new string[] { "233", "333" });


            //object 万类之祖
            //声明object类型，赋值任意类型
            object o1 = 1;
            object o2 = true;
            object o3 = new int[3];


            string[] array01 = new string[2] { "1", "bnb" };
            //声明+初始化+赋值
            bool[] array02 = { true, false, true };

            //还可以这样测试
            float max = GetMax(new float[] { 5, 3, 7 });
            Console.WriteLine(GetTotalDays(2020, 2, 28)); 

        }

        private static int GetFactorial(int num)
        {
            //递归核心思想：将问题转移给范围小的子问题
            if (num == 1) return 1;
            return num*GetFactorial(num-1);
        }


        private static int GetAnswer(int num)
        {
            if (num == 1) return 1;
            if (num % 2 == 0) return GetAnswer(num - 1) - num;
            else return GetAnswer(num - 1) + num;
        }

        private static bool IsOdd(int num)
        {
            return num % 2 != 0;
        }

        private static float[] CreateScoreArray()
        {
            Console.WriteLine("num：");
            int count = int.Parse(Console.ReadLine());
            float[] scoreArray = new float[count];
            for (int i = 0; i < scoreArray.Length;)
            {
                Console.WriteLine("{0}", i + 1);
                float score = float.Parse(Console.ReadLine());
                if (score>=0&&score<=100)
                    scoreArray[i++] = score;
                else
                    Console.WriteLine("成绩有误");
            }
            return scoreArray;
        }

        //数组最大值float[]

        private static float GetMax(float[] array)
        {
            float max=array[0];
            for (int i = 0; i < array.Length; i++)
            {
                _ = max > array[i] ? max : array[i];
            }
            return max;
        }
        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }
        private static int GetTotalDays(int year,int month,int day)
        {
            int[] daysOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (IsLeapYear(year)) daysOfMonth[1] = 29;
            int days = 0;
            for (int i = 0; i < month-1; i++)
            {
                days += daysOfMonth[i];
            }
            days += day;
            return days;
        }

        private static void PrintElement(Array arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static int[] BuyTicket()
        {
            int[] ticket = new int[7];

            for (int i = 0; i < 6;)
            {
                Console.WriteLine("第{0}个红球：",i);

                int redNumber = int.Parse(Console.ReadLine());
                if (redNumber < 1 || redNumber > 33)
                    Console.WriteLine("out range");
                else if (Array.IndexOf(ticket, redNumber) >= 0)
                    Console.WriteLine("repeat");
                else
                    ticket[i++] = redNumber;
            }

            while (true)
            {
                Console.WriteLine("blue:");
                int blueNumber = int.Parse(Console.ReadLine());
                if (blueNumber >= 1 && blueNumber <= 16)
                {
                    ticket[6] = blueNumber;
                    break;
                }
                else
                    Console.WriteLine("outrange");
            }

            return ticket;
        }

        //static Random random = new Random();
        //private static int[] CreateRandomTicket()
        //{
        //    int[] ticket = new int[7];
        //    for (int i = 0; i < 6; i++)
        //    {
        //        int redNumber = random.Next(1, 34);
        //    }
        //}

        private static void PrintTest(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < i; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < n-i; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }
    }
}
