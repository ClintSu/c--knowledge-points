using System;
using System.Threading;

namespace Pj_Thread
{
    public class ThreadBookShop
    {
        //剩余图书数量
        public int num = 1;
        public void Sale()
        {
            int tmp = num;
            if (tmp > 0)//判断是否有书，如果有就可以卖
            {
                Thread.Sleep(1000);
                num -= 1;
                Console.WriteLine("售出一本图书，还剩余{0}本", num);
            }
            else
            {
                Console.WriteLine("没有了");
            }
        }
    }
}