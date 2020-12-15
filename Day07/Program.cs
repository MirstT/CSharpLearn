using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    [Flags]
    enum Test
    {
        aa = 1,
        bb = 2,
        cc = 4,
        dd = 8,
        ee = 16
    }

    class Program
    {

        static void Main1(string[] args)
        {
            Wife wife01 = new Wife();
            wife01.Name = "aaaaaaaaaaa";
            wife01.Age = 33;
            wife01.SetSex(true);

            Wife wife02 = new Wife("bbbb",55);


            int[] a1 = new int[] { 1 };
            Fun1(ref a1);
            Console.WriteLine(a1[0]);
            TestEnum(Test.aa | Test.bb);

            //int==>enum
            Test intToEnum = (Test)2;
            //enum=>int
            int enumToInt1 = (int)Test.aa;
            int enumToInt2 = (int)(Test.aa|Test.bb);
            //string=>enum
            Test stringToEnum=(Test)Enum.Parse(typeof(Test),"ffffffffff");
            //enum=>string
            string enumToString = Test.aa.ToString();

            Console.ReadLine();
        }

        private static void Fun1(ref int[] a)
        {
            a = new int[] { 2 };
            a[0] = 3;
        }

        private static void Fun1(int[] a)
        {
            a = new int[] { 2 };
            a[0] = 3;
        }

        private static void TestEnum(Test test)
        {
            if ((test&Test.aa)==Test.aa)
            {
                Console.WriteLine("aa");
            }
            if ((test&Test.bb)!=0)
            {
                Console.WriteLine("bb");
            }
        }

        static void Main2()
        {
            Wife w01 = new Wife();
            w01.Age = 33;
            w01.Name = "01";
            Wife w02 = new Wife("02", 13);

            Wife[] wifeArray = new Wife[6];
            wifeArray[0] = w01;
            wifeArray[1] = w02;
            wifeArray[2] = new Wife("03", 40);
            wifeArray[3] = new Wife("04", 22);
            wifeArray[4] = new Wife("05", 25);
            wifeArray[5] = new Wife("06", 28);

            //Wife youngestWife = FindYoungestWifeInArray(wifeArray);
            Console.WriteLine(GetWifeByMinimumAge(wifeArray).Age);
            Console.WriteLine(FindYoungestWifeInArray(wifeArray).Age);


            Console.ReadLine();
        }

        private static Wife FindYoungestWifeInArray(Wife[] wifeArray)
        {
            int youngestWifeIndex = 0;
            for (int i=1; i < wifeArray.Length; i++)
                if (wifeArray[i].Age < wifeArray[youngestWifeIndex].Age)
                    youngestWifeIndex = i;
            return wifeArray[youngestWifeIndex];
        }

        private static Wife GetWifeByMinimumAge(Wife[] wives)
        {
            Wife minWife = wives[0];
            for (int i = 0; i < wives.Length; i++)
                if (minWife.Age>wives[i].Age)
                    minWife = wives[i];
            return minWife;
        }

        static void Main()
        {
            User user01 = new User();

            //数组初始化 必须指定大小
            //User[] userArray = new User[?];
            //读写元素 必须通过 索引
            //userArray[?] = user01;

            //StringBuilder


            //c#泛型集合 
            List<User> listUser = new List<User>();
            listUser.Add(user01);
            listUser.Add(new User());


            //Dictionary<string, User> dic = new Dictionary<string, User>;
            //dic.Add("wh", new User("wh", "233"));
            //User whUser = dic["wh"];
        }
    }
}
