using System;

namespace _2048
{
    internal class Program
    {
        private static void Main()
        {
            GameCore core = new GameCore();
            core.GenerateNumber();
            core.GenerateNumber();
            DrawMap(core.Map);

            while (true)
            {
                KeyDown(core);
                if (core.IsWin)
                {
                    DrawMap(core.Map);
                    Console.WriteLine("You WIN!!!");
                    return;
                }
                if (core.IsChange)
                {
                    core.GenerateNumber();
                    Console.Clear();
                    DrawMap(core.Map);
                    continue;
                }
                if (core.IsLose)
                {
                    DrawMap(core.Map);
                    Console.WriteLine("You LOSE!!!");
                    return;
                }
            }
        }

        private static void DrawMap(int[,] map)
        {
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                    Console.Write(map[r, c] + "\t");
                Console.WriteLine();
            }
        }

        private static void KeyDown(GameCore core)
        {
            string direction = Console.ReadLine();
            switch (direction)
            {
                case "w":
                    core.Move(MoveDirection.Up);
                    break;

                case "a":
                    core.Move(MoveDirection.Left);
                    break;

                case "s":
                    core.Move(MoveDirection.Down);
                    break;

                case "d":
                    core.Move(MoveDirection.Right);
                    break;
            }
        }

        private static void Main1(string[] args)
        {
            Init2048();
        }

        public enum winOrLose2048
        {
            win2048 = 1,
            lose2048 = -1,
            continue2048 = 0
        }

        private static void Init2048()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("2048");
            Console.WriteLine("--------------------------------------");

            int rowNum = 5, colNum = 5;
            int[,] data2048 = new int[rowNum, colNum];
            int[,] lastData2048 = new int[rowNum, colNum];
            InsertTwoOrFour(data2048);

            while (true)
            {
                InsertTwoOrFour(data2048, lastData2048);
                UpdateUI(data2048, lastData2048);
                Array.Copy(data2048, lastData2048, rowNum * colNum);
                Control2048(data2048);

                switch (WinOrLose(data2048))
                {
                    case winOrLose2048.win2048:
                        Console.WriteLine("You WIN!!!");
                        Console.WriteLine("You WIN!!!");
                        Console.WriteLine("You WIN!!!");
                        return;

                    case winOrLose2048.lose2048:
                        Console.WriteLine("You LOSE!!!");
                        Console.WriteLine("You LOSE!!!");
                        Console.WriteLine("You LOSE!!!");
                        return;

                    default:
                        break;
                }
            }
        }

        private static void Control2048(int[,] data2048)
        {
            Console.WriteLine("请输入移动方向：");
            string direction = Console.ReadLine();
            switch (direction)
            {
                case "w":
                    Move(data2048, MoveDirection.Up);
                    break;

                case "a":
                    Move(data2048, MoveDirection.Left);
                    break;

                case "s":
                    Move(data2048, MoveDirection.Down);
                    break;

                case "d":
                    Move(data2048, MoveDirection.Right);
                    break;

                default:
                    break;
            }
        }

        private static void Move(int[,] data2048, MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    UpMove(data2048);
                    break;

                case MoveDirection.Down:
                    DownMove(data2048);
                    break;

                case MoveDirection.Left:
                    LeftMove(data2048);
                    break;

                case MoveDirection.Right:
                    RightMove(data2048);
                    break;
            }
        }

        private static void RightMove(int[,] data2048)
        {
            for (int row = 0; row < data2048.GetLength(0); row++)
            {
                int[] array = new int[data2048.GetLength(1)];
                for (int col = 0; col < data2048.GetLength(1); col++)
                    array[col] = data2048[row, col];
                Array.Reverse(array);
                MergeSingleArray(array);
                Array.Reverse(array);
                for (int col = 0; col < data2048.GetLength(1); col++)
                    data2048[row, col] = array[col];
            }
        }

        private static void DownMove(int[,] data2048)
        {
            for (int col = 0; col < data2048.GetLength(1); col++)
            {
                int[] array = new int[data2048.GetLength(0)];
                for (int row = 0; row < data2048.GetLength(0); row++)
                    array[row] = data2048[row, col];
                Array.Reverse(array);
                MergeSingleArray(array);
                Array.Reverse(array);
                for (int row = 0; row < data2048.GetLength(0); row++)
                    data2048[row, col] = array[row];
            }
        }

        private static void LeftMove(int[,] data2048)
        {
            for (int row = 0; row < data2048.GetLength(0); row++)
            {
                int[] array = new int[data2048.GetLength(1)];
                for (int col = 0; col < data2048.GetLength(1); col++)
                    array[col] = data2048[row, col];
                MergeSingleArray(array);
                for (int col = 0; col < data2048.GetLength(1); col++)
                    data2048[row, col] = array[col];
            }
        }

        private static void UpMove(int[,] data2048)
        {
            for (int col = 0; col < data2048.GetLength(1); col++)
            {
                int[] array = new int[data2048.GetLength(0)];
                for (int row = 0; row < data2048.GetLength(0); row++)
                    array[row] = data2048[row, col];
                MergeSingleArray(array);
                for (int row = 0; row < data2048.GetLength(0); row++)
                    data2048[row, col] = array[row];
            }
        }

        private static void UpdateUI(int[,] data2048, int[,] lastData2048)
        {
            if (IsSame(data2048, lastData2048) || IsFull(data2048)) return;
            for (int i = 0; i < data2048.GetLength(0); i++)
            {
                for (int j = 0; j < data2048.GetLength(1); j++)
                    Console.Write(data2048[i, j] + "\t");
                Console.WriteLine();
            }
        }

        private static Random random = new Random();

        private static void InsertTwoOrFour(int[,] data2048, int[,] lastData2048)
        {
            if (IsSame(data2048, lastData2048) || IsFull(data2048)) return;
            while (true)
            {
                int row = random.Next(data2048.GetLength(0));
                int col = random.Next(data2048.GetLength(1));
                if (data2048[row, col] == 0)
                {
                    if (random.Next(2) == 0)
                    {
                        data2048[row, col] = 2;
                        break;
                    }
                    else
                    {
                        data2048[row, col] = 4;
                        break;
                    }
                }
            }
        }

        private static void InsertTwoOrFour(int[,] data2048)
        {
            int row = random.Next(data2048.GetLength(0));
            int col = random.Next(data2048.GetLength(1));
            if (random.Next(2) == 0)
                data2048[row, col] = 2;
            else
                data2048[row, col] = 4;
        }

        private static void MergeSameNumberInArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0) continue;
                int temp = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] == 0) continue;
                    if (array[j] == temp)
                    {
                        array[j] *= 2;
                        array[i] = 0;
                        i = j;
                    }
                    else
                        i = j - 1;
                    break;
                }
            }
        }

        //private static void MergeSingleArray(int[] array)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i] == 0) continue;
        //        int temp = array[i];
        //        for (int j = i + 1; j < array.Length; j++)
        //        {
        //            if (array[j] == 0) continue;
        //            if (array[j] == temp)
        //            {
        //                array[j] *= 2;
        //                array[i] = 0;
        //                i = j - 1;
        //                break;
        //            }
        //            else
        //            {
        //                i = j - 1;
        //                break;
        //            }
        //        }
        //    }
        //}

        //private static void DeleteSuperfluousZero(int[] array)
        //{
        //    int[] noZeroArray = new int[array.Length];
        //    int index = 0;
        //    for (int i = 0; i < array.Length; i++)
        //        if (array[i] != 0)
        //            noZeroArray[index++] = array[i];
        //    noZeroArray.CopyTo(array, 0);
        //}

        private static void RemoveZeroToEnd(int[] array)
        {
            int indexFlag = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0) continue;
                array[indexFlag] = array[i];
                if (indexFlag++ != i) array[i] = 0;
            }
        }

        private static void MergeSingleArray(int[] array)
        {
            MergeSameNumberInArray(array);
            RemoveZeroToEnd(array);
        }

        private static winOrLose2048 WinOrLose(int[,] data2048)
        {
            if (IsWin(data2048))
                return winOrLose2048.win2048;
            if (IsLose(data2048))
                return winOrLose2048.lose2048;
            return winOrLose2048.continue2048;
        }

        private static bool IsLose(int[,] data2048)
        {
            if (!IsFull(data2048)) return false;
            for (int i = 0; i < data2048.GetLength(0); i++)
                for (int j = 0; j < data2048.GetLength(1) - 1; j++)
                    if (data2048[i, j] == data2048[i, j + 1])
                        return false;
            for (int i = 0; i < data2048.GetLength(0) - 1; i++)
                for (int j = 0; j < data2048.GetLength(1); j++)
                    if (data2048[i, j] == data2048[i + 1, j])
                        return false;
            return true;
        }

        //private static bool IsLose(int[,] data2048)
        //{
        //    if (IsFull(data2048))
        //    {
        //        int[,] copyData2048 = new int[data2048.GetLength(0), data2048.GetLength(1)];
        //        Array.Copy(data2048, copyData2048, data2048.GetLength(0) * data2048.GetLength(1));
        //        UpMove(copyData2048);
        //        if (!IsSame(data2048, copyData2048))
        //            return false;
        //        Array.Copy(data2048, copyData2048, data2048.GetLength(0) * data2048.GetLength(1));
        //        DownMove(copyData2048);
        //        if (!IsSame(data2048, copyData2048))
        //            return false;
        //        Array.Copy(data2048, copyData2048, data2048.GetLength(0) * data2048.GetLength(1));
        //        LeftMove(copyData2048);
        //        if (!IsSame(data2048, copyData2048))
        //            return false;
        //        Array.Copy(data2048, copyData2048, data2048.GetLength(0) * data2048.GetLength(1));
        //        RightMove(copyData2048);
        //        if (!IsSame(data2048, copyData2048))
        //            return false;
        //        return true;
        //    }
        //    return false;
        //}

        private static bool IsFull(int[,] data2048)
        {
            foreach (var item in data2048)
                if (item == 0) return false;
            return true;
        }

        private static bool IsWin(int[,] data2048)
        {
            foreach (var item in data2048)
                if (item >= 2048) return true;
            return false;
        }

        private static int GetSumOfData2048(int[,] data2048)
        {
            int sum = 0;
            foreach (var item in data2048)
                sum += item;
            return sum;
        }

        private static bool IsSame(int[,] data2048, int[,] lastData2048)
        {
            for (int i = 0; i < data2048.GetLength(0); i++)
                for (int j = 0; j < data2048.GetLength(1); j++)
                    if (data2048[i, j] != lastData2048[i, j])
                        return false;
            return true;
        }
    }
}