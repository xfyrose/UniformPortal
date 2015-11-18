using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.Threads
{
    [TestClass]
    public class UnitTestThread
    {
        static int count = 100000;

        public static void Task1(object obj)
        {
            for (int i = 0; i < 100000; i++)
            {
                count++;
            }

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Task1 count {0}", count);
        }

        public static void Task2(object obj)
        {
            for (int i = 0; i < 100000; i++)
            {
                count++;
            }
            Console.WriteLine("Task2 count {0}", count);
        }

        [TestMethod]
        public void TestMethod_Thread()
        {
            Nullable<int> nullable = 5;

            object boxed = nullable;
            Console.WriteLine(boxed.GetType());

            int normal = (int)boxed;
            Console.WriteLine(normal);

            nullable = (Nullable<int>)boxed;
            Console.WriteLine(nullable);

            nullable = new Nullable<int>();
            boxed = nullable;
            Console.WriteLine(boxed == null);

            nullable = (Nullable<int>)boxed;
            Console.WriteLine(nullable.HasValue);

            Console.WriteLine("Thread" + Thread.CurrentThread.ManagedThreadId);

            ThreadLocal<string> ThreadName = new ThreadLocal<string>(() =>
            {
                return "Thread" + Thread.CurrentThread.ManagedThreadId;
            });

            Console.WriteLine("TheadValue:" + ThreadName.Value);
            Console.WriteLine("TheadValue:" + ThreadName.Value);

            // Action that prints out ThreadName for the current thread
            Action action = () =>
            {
                // If ThreadName.IsValueCreated is true, it means that we are not the
                // first action to run on this thread.
                bool repeat = ThreadName.IsValueCreated;

                Console.WriteLine("ThreadName = {0} {1}", ThreadName.Value, repeat ? "(repeat)" : "");
            };

            //action();
            //action();
            // Launch eight of them.  On 4 cores or less, you should see some repeat ThreadNames
            Parallel.Invoke(action, action, action, action, action, action, action, action);

            // Dispose when you are done
            ThreadName.Dispose();
        }
    }
}
