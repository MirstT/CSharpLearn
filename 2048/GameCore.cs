using System;
using System.Collections.Generic;

namespace _2048
{
    internal class GameCore
    {
        private int[,] data2048;
        private int rowNum;
        private int colNum;
        private int[] mergeRowArray;
        private int[] mergeColArray;
        private List<Location> emptyLocationList;
        private Random random;
        private int[,] lastData2048;

        public bool IsChange
        {
            get
            {
                for (int r = 0; r < rowNum; r++)
                    for (int c = 0; c < colNum; c++)
                        if (data2048[r, c] != lastData2048[r, c])
                            return true;
                return false;
            }
        }

        public bool IsWin
        {
            get
            {
                foreach (var item in data2048)
                    if (item >= 2048) return true;
                return false;
            }
        }

        public bool IsLose
        {
            get
            {
                if (!IsFull) return false;
                for (int r = 0; r < rowNum; r++)
                    for (int c = 0; c < colNum - 1; c++)
                        if (data2048[r, c] == data2048[r, c + 1])
                            return false;
                for (int r = 0; r < rowNum - 1; r++)
                    for (int c = 0; c < colNum; c++)
                        if (data2048[r, c] == data2048[r + 1, c])
                            return false;
                return true;
            }
        }

        public bool IsFull
        {
            get
            {
                foreach (var item in data2048)
                    if (item == 0) return false;
                return true;
            }
        }

        public int[,] Map
        {
            get
            {
                return this.data2048;
            }
        }

        public GameCore() : this(4, 4)
        { }

        public GameCore(int rowNum, int colNum)
        {
            this.rowNum = rowNum;
            this.colNum = colNum;
            data2048 = new int[rowNum, colNum];
            mergeRowArray = new int[colNum];
            mergeColArray = new int[rowNum];
            emptyLocationList = new List<Location>(rowNum * colNum);
            random = new Random();
            lastData2048 = new int[rowNum, colNum];
        }

        private void FindEmpty()
        {
            emptyLocationList.Clear();
            for (int r = 0; r < rowNum; r++)
                for (int c = 0; c < colNum; c++)
                    if (data2048[r, c] == 0)
                        emptyLocationList.Add(new Location(r, c));
        }

        private void MoveZeroToEnd(int[] array)
        {
            int indexFlag = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0) continue;
                array[indexFlag] = array[i];
                if (indexFlag++ != i) array[i] = 0;
            }
        }

        private void MergeSingleArray(int[] array)
        {
            MoveZeroToEnd(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != 0 && array[i] == array[i + 1])
                {
                    array[i + 1] *= 2;
                    array[i] = 0;
                }
            }
            MoveZeroToEnd(array);
        }

        private void RightMove()
        {
            for (int row = 0; row < rowNum; row++)
            {
                for (int col = 0; col < colNum; col++)
                    mergeRowArray[colNum - col - 1] = data2048[row, col];
                MergeSingleArray(mergeRowArray);
                for (int col = 0; col < colNum; col++)
                    data2048[row, col] = mergeRowArray[colNum - col - 1];
            }
        }

        private void DownMove()
        {
            for (int col = 0; col < colNum; col++)
            {
                for (int row = 0; row < rowNum; row++)
                    mergeColArray[rowNum - row - 1] = data2048[row, col];
                MergeSingleArray(mergeColArray);
                for (int row = 0; row < rowNum; row++)
                    data2048[row, col] = mergeColArray[rowNum - row - 1];
            }
        }

        private void LeftMove()
        {
            for (int row = 0; row < rowNum; row++)
            {
                for (int col = 0; col < colNum; col++)
                    mergeRowArray[col] = data2048[row, col];
                MergeSingleArray(mergeRowArray);
                for (int col = 0; col < colNum; col++)
                    data2048[row, col] = mergeRowArray[col];
            }
        }

        private void UpMove()
        {
            for (int col = 0; col < colNum; col++)
            {
                for (int row = 0; row < rowNum; row++)
                    mergeColArray[row] = data2048[row, col];
                MergeSingleArray(mergeColArray);
                for (int row = 0; row < rowNum; row++)
                    data2048[row, col] = mergeColArray[row];
            }
        }

        public void Move(MoveDirection direction)
        {
            Array.Copy(data2048, lastData2048, data2048.Length);
            switch (direction)
            {
                case MoveDirection.Up:
                    UpMove();
                    break;

                case MoveDirection.Down:
                    DownMove();
                    break;

                case MoveDirection.Left:
                    LeftMove();
                    break;

                case MoveDirection.Right:
                    RightMove();
                    break;
            }
        }

        public void GenerateNumber()
        {
            FindEmpty();
            if (emptyLocationList.Count > 0)
            {
                int randomIndex = random.Next(0, emptyLocationList.Count);
                Location loc = emptyLocationList[randomIndex];
                data2048[loc.Rindex, loc.CIndex] = random.Next(0, 3) == 0 ? 4 : 2;
            }
        }
    }
}