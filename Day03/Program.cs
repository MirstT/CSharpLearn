using System;

namespace Day03
{
    class Program
    {
        static void Main2(string[] args)
        {
            #region test
            Console.WriteLine("请输入性别:");
            string sex = Console.ReadLine();
            if (sex == "男")
            {
                Console.WriteLine("您好，先生!");
            }
            else if (sex == "女")
            {
                Console.WriteLine("您好，女士!");
            }
            else
            {
                Console.WriteLine("性别未知!");
            }

            #endregion


            //获取数据
            Console.WriteLine("请输入第一个数字:");
            int numberOne = int.Parse(Console.ReadLine());

            Console.WriteLine("请输入第二个数字:");
            int numberTwo = int.Parse(Console.ReadLine());

            Console.WriteLine("请输入运算符:");
            string op = Console.ReadLine();

            //逻辑处理
            float result = 0;
            if (op == "+") result = numberOne + numberTwo;
            else if (op == "-") result = numberOne - numberTwo;
            else if (op == "*") result = numberOne * numberTwo;
            else if (op == "/") result = numberOne / numberTwo;

            //显示结果
            if (op == "+" || op == "-" || op == "*" || op == "/")
                Console.WriteLine("结果为:" + result);
            else
                Console.WriteLine("运算符输入有误!");


            ////获取数据
            //Console.WriteLine("请输入第一个数字:");
            //int numberOne = int.Parse(Console.ReadLine());

            //Console.WriteLine("请输入第二个数字:");
            //int numberTwo = int.Parse(Console.ReadLine());

            //Console.WriteLine("请输入运算符:");
            //string op = Console.ReadLine();

            ////逻辑处理
            //float result = 0;
            //switch (op)
            //{
            //    case "+": 
            //        result = numberOne + numberTwo; 
            //        break;
            //    case "-":
            //        result = numberOne - numberTwo;
            //        break;
            //    case "1":
            //    case "4":
            //    case "*":
            //        result = 0;
            //        break;
            //    default:
            //        break;
            //}
            //if (op == "+") result = numberOne + numberTwo;
            //else if (op == "-") result = numberOne - numberTwo;
            //else if (op == "*") result = numberOne * numberTwo;
            //else if (op == "/") result = numberOne / numberTwo;

            ////显示结果
            //if (op == "+" || op == "-" || op == "*" || op == "/")
            //    Console.WriteLine("结果为:" + result);
            //else
            //    Console.WriteLine("运算符输入有误!");

        }

        static void Main3()
        {
            Console.WriteLine("成绩:");
            int score = int.Parse(Console.ReadLine());

            string message;
            if (score < 0 || score > 100) message = "成绩有误";
            else if (score >= 90) message = "优秀";
            else if (score >= 80) message = "良好";
            else if (score >= 60) message = "及格";
            else message = "差";

            Console.WriteLine(message);

            //短路逻辑 运算量大的放在后面,降低CPU负载
            int n1 = 1, n2 = 2;

            bool re1 = n1 > 2 && n1++ > 1;
            Console.WriteLine(n1);//1

            bool re2 = n1 < n2 || n2++ < 1;
            Console.WriteLine(n2);//2
        }

        static void Main4()
        {
            Random random = new Random();

            int number = random.Next(1, 101);
            int inputNumber;
            int count = 0;
            //do
            //{
            //    count++;
            //    Console.WriteLine("input:");
            //     inputNumber= int.Parse(Console.ReadLine());
            //    if (inputNumber > number)
            //    {
            //        Console.WriteLine("big");
            //    }
            //    else if (inputNumber < number)
            //    {
            //        Console.WriteLine("small");
            //    }
            //    else
            //    {
            //        Console.WriteLine("{0}次", count);
            //    }
            //} while (number!=inputNumber);


            while(true)
            {
                count++;
                Console.WriteLine("input:");
                inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber > number)
                {
                    Console.WriteLine("big");
                }
                else if (inputNumber < number)
                {
                    Console.WriteLine("small");
                }
                else
                {
                    Console.WriteLine("{0}次", count);
                    break;
                }
            }

        }


        static void Main()
        {
            /*1.在控制台中实现年历的方法
             * --调用12遍->月历
             * 2.在控制台中实现月历的方法
             * --显示表头 cw ("sun\tMon\t...")
             * --计算当月1日星期数，输出空白（\t）
             * --计算当月当月天数 1\t 2 3 4
             * --每逢周六换行
             * 
             * 3.根据年月日计算星期数
             * 4.计算指定月份的天数
             * 5.判断闰年的方法（可能要第一个调用）
             * --2月 闰年 平年28
             * --/4 !/100
             * --/400
             */
            Console.WriteLine("请输入需要显示的年历：");
            int year = int.Parse(Console.ReadLine());
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("{0}月份",i+1);
                GetMonthlyCalendar(year, i + 1);
            }


        }
        private static void GetMonthlyCalendar(int year,int Month)
        {
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六");
            int weekOfFirstDayInMonth=GetWeekByDay(year, Month, 1);
            
            while (weekOfFirstDayInMonth!=0)
            {
                Console.Write("\t");
                weekOfFirstDayInMonth--;
            }

            int daysOfMonth = DaysOfMonth(year, Month);
            for (int i = 1; i <= daysOfMonth; i++)
            {
                Console.Write(i+"\t");
                if (GetWeekByDay(year, Month, i) == 6)
                {
                    Console.Write("\n");
                }
            }
            Console.Write("\n");
        }

        /// <summary>
        /// 根据年月日，计算星期数的方法
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="day">天</param>
        /// <returns>星期</returns>
        private static int GetWeekByDay(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day);
            return (int)dt.DayOfWeek;
        }

        /// <summary>
        /// 判断是否为闰年
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>闰年：True,平年：False</returns>
        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        /// <summary>
        /// 获取指定年月的月天数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns>月天数</returns>
        private static int DaysOfMonth(int year,int month)
        {
            if (month < 1 || month > 12) return 0;
            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return IsLeapYear(year) ? 29 : 28;
                default:
                    return 31;
            }
            //int daysOfMonth = 0;
            //switch (month) 
            //{
            //    case 4:
            //    case 6:
            //    case 9:
            //    case 11:
            //        daysOfMonth = 30;
            //        break;
            //    case 2:
            //        if (IsLeapYear(year))
            //        {
            //            daysOfMonth = 29;
            //        }
            //        else
            //        {
            //            daysOfMonth = 28;
            //        }
            //        break; 
            //    default:
            //        daysOfMonth = 31;
            //        break;
            //}
            //return daysOfMonth;
        }

        private static int TotalDaysOfYear(int year,int month,int day)
        {
            int daysOfYear = 0;
            while (month!=0)
                daysOfYear += DaysOfMonth(year, month--);
            return daysOfYear+day;
        }
    }
}
