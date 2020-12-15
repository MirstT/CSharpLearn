using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    //数组初始化 必须指定大小
    //User[] userArray = new User[?];
    //读写元素 必须通过 索引
    //userArray[?] = user01;

    //StringBuilder
    class UserList
    {
        //字段
        private User[] data;
        private int currentIndex;
        //属性
        /// <summary>
        /// 有效元素个数
        /// </summary>
        public int Count
        {
            get
            {
                return currentIndex+1;
            }
        }

        //构造函数
        public UserList() : this(8)
        {
        }
        public UserList(int capacity)
        {
        data = new User[capacity];
        }

        //方法
        public void Add(User value)
        {
            //容量不够的时候扩容
            CheckCapacity();
            data[currentIndex++] = value;
        }
        public User GetElement(int index)
        {
            return data[index];
        }

        private void CheckCapacity()
        {
            if(currentIndex>=data.Length)
            {
                User[] newData = new User[data.Length * 2];
                data.CopyTo(newData, 0);
                data = newData;
            }
        }
    }
}
