using System;
using System.Threading;

namespace Pj_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            //无参数简单调用1
            Thread thread1 = new Thread(new ThreadStart(Thread_no_param));
            thread1.Start();

            //无参数简单调用2
            Thread thread2 = new Thread(Thread_no_param);
            thread2.Start();

            //调用test实例的MyThread方法
            ThreadTest test = new ThreadTest();
            Thread thread3 = new Thread(test.MyThread);
            thread3.Start();

            //通过匿名委托创建
            Thread thread4 = new Thread(delegate () { Console.WriteLine("匿名委托线程方法"); });
            thread4.Start();

            //通过Lambda表达式创建
            Thread thread5 = new Thread(() => { Console.WriteLine("Lambda表达式委托方法"); });
            thread5.Start();

            //通过ParameterizedThreadStart创建带参线程
            Thread thread6 = new Thread(new ParameterizedThreadStart(Thread_param));
            thread6.Start("这是参数"); //需带参数启动

            //不使用ParameterizedThreadStart创建带参线程
            Thread thread7 = new Thread(Thread_param);
            thread7.Priority = ThreadPriority.Lowest;
            thread7.Start("这是参数"); //需带参数启动

            //后台线程,线程位结束就会退出。
            Thread thread8 = new Thread(Thread_param);
            thread8.IsBackground = true;
            thread8.Start("后台线程");

            //多线程管理 Thread.join
            Thread joinThread = new Thread(Thread_join_all);
            joinThread.Start(new Thread[] { thread1, thread2, thread3, thread4, thread5, thread6, thread7, thread8 });

            //线程同步|线程安全
            ThreadBookShop bookshop = new ThreadBookShop();
            Thread thread11 = new Thread(bookshop.Sale);
            Thread thread12 = new Thread(bookshop.Sale);
            thread11.Start();
            thread12.Start();

            ThreadBookShopLook bookshoplook = new ThreadBookShopLook();
            Thread thread13 = new Thread(bookshoplook.Sale);
            Thread thread14 = new Thread(bookshoplook.Sale);
            thread13.Start();
            thread14.Start();

        }
        static void Thread_no_param()
        {
            Console.WriteLine("无参方法");
        }
        static void Thread_param(object param)
        {
            Console.WriteLine("有参方法:" + param.ToString());
        }
        static void Thread_join_all(object obj)
        {
            Thread[] threads = obj as Thread[];
            foreach (var t in threads)
            {
                t.Join();
            }
            Console.WriteLine("所有线程结束");
            Console.WriteLine("-------------------------------------------------------------------");
        }

    }
}
