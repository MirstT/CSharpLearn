using System;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int[] array = { 4, 6, 23, 7, 1, 88, 9, 0, 55 };
            SelectSorting(array);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------实参形参传参----------");

            int a = 1;
            int b = 2;
            Test(b);
            Console.WriteLine(b);
        }

        private static void Test(int test)
        {
            test += 1;
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="array"></param>
        private static void SelectSorting(int[] array)
        {
            for (int currentIndex = 0; currentIndex < array.Length - 1; currentIndex++)
            {
                int minIndex = currentIndex;
                for (int i = currentIndex; i < array.Length; i++)
                    minIndex = array[minIndex] < array[i] ? minIndex : i;
                if (minIndex != currentIndex)
                {
                    int temp = array[currentIndex];
                    array[currentIndex] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }

        //private static void BubbleSorting(int[] array)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        int maxIndex = 0;
        //        for (int j = 0; j < array.Length - i; j++)
        //        {
        //            maxIndex = array[maxIndex] > array[j] ? maxIndex : j;
        //        }
        //        int temp = array[array.Length - 1 - i];
        //        array[array.Length - 1 - i] = array[maxIndex];
        //        array[maxIndex] = temp;

        //    }
        //}
    }
}
