using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        [TestMethod]
        public void TestMethod4()
        {
            Person person1 = new Person { Id = 1, Name = "name01"};
            Person person2 = new Person { Id = 2, Name = "name02" };
            Person person3 = new Person { Id = 3, Name = "name03" };

            Person personAnother = new Person {Id = 1, Name = "another"};

            Console.WriteLine("person1 == person2: {0}", person1.Equals(person2));
            Console.WriteLine("person1 == personAnother: {0}", person1.Equals(personAnother));

            List<Person> listPerson = new List<Person> {person1, person2, person3};
            Console.WriteLine("Before Remove: {0}", listPerson.Count);
            listPerson.Remove(personAnother);
            Console.WriteLine("Before After: {0}", listPerson.Count);

            ArrayList alPerson = new ArrayList {person1, person2, person3};
            Console.WriteLine("Before Remove: {0}", alPerson.Count);
            alPerson.Remove(personAnother);
            Console.WriteLine("Before After: {0}", alPerson.Count);
        }

        const int ArraySize = 200 * 1000 * 1000;
        static int[] bigArray = new int[ArraySize];

        static void DoWithoutLocks()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                bigArray[i] = i;
            }
        }

        static void DoWithLocks()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                lock (bigArray)
                {
                    bigArray[i] = i;
                }
            }
        }

        delegate void TestDelegate();

        static void DoWith2Locks()
        {
            //TestDelegate t1 = new TestDelegate(DoWithoutLocks);
            //TestDelegate t2 = new TestDelegate(DoWithoutLocks);
            //IAsyncResult ia1 = t1.BeginInvoke(null, null);
            //IAsyncResult ia2 = t2.BeginInvoke(null, null);
            //t1.EndInvoke(ia1);
            //t2.EndInvoke(ia2);

            // Replace the call to DoWithLocks with this code
            TestDelegate t1 = new TestDelegate(DoWithLocks);
            TestDelegate t2 = new TestDelegate(DoWithLocks);
            IAsyncResult ia1 = t1.BeginInvoke(null, null);
            IAsyncResult ia2 = t2.BeginInvoke(null, null);
            t1.EndInvoke(ia1);
            t2.EndInvoke(ia2);
        }

        static void DoWith16Locks()
        {
            int size = 16;

            TestDelegate[] t = new TestDelegate[size];
            for (int i = 0; i < size; i++)
            {
                t[i] = new TestDelegate(DoWithLocks);
            }

            IAsyncResult[] ia = new IAsyncResult[size];
            for (int i = 0; i < size; i++)
            {
                ia[i] = t[i].BeginInvoke(null, null);
            }
            //IAsyncResult ia16 = t16.BeginInvoke(null, null);

            for (int i = 0; i < size; i++)
            {
                t[i].EndInvoke(ia[i]);
            }
        }


        private static void DoWith64Locks()
        {
            int size = 64;

            TestDelegate[] t = new TestDelegate[size];
            for (int i = 0; i < size; i++)
            {
                t[i] = new TestDelegate(DoWithLocks);
            }

            IAsyncResult[] ia = new IAsyncResult[size];
            for (int i = 0; i < size; i++)
            {
                ia[i] = t[i].BeginInvoke(null, null);
            }
            //IAsyncResult ia16 = t16.BeginInvoke(null, null);

            for (int i = 0; i < size; i++)
            {
                t[i].EndInvoke(ia[i]);
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Ensures that the array is allocated and initialized
            DoWithoutLocks();

            long nolockTicks;
            long lockTicks;
            Stopwatch sw = new Stopwatch();

            // Time a run without locks
            sw.Start();
            DoWithoutLocks();
            sw.Stop();
            nolockTicks = sw.ElapsedTicks;
            long noLocksMs = (nolockTicks * 1000) / Stopwatch.Frequency;
            Console.WriteLine("Without locks = {0} milliseconds", noLocksMs);

            sw.Reset();

            // Time a run with locks
            sw.Start();
            DoWithLocks();
            sw.Stop();
            lockTicks = sw.ElapsedTicks;

            long withLocksMs = (lockTicks * 1000) / Stopwatch.Frequency;
            Console.WriteLine("With locks  = {0} milliseconds", withLocksMs);
            //Console.WriteLine("Difference  = {0} milliseconds", withLocksMs - noLocksMs);

            // Compute differences and per-lock time
            long tickDiff = lockTicks - nolockTicks;
            long msDiff = (tickDiff * 1000) / Stopwatch.Frequency;
            double lockms = (double)msDiff / ArraySize;

            //Console.WriteLine("{0} locks requires {1} milliseconds", ArraySize, msDiff);
            //Console.WriteLine("Lock requires {0} microseconds", 1000 * lockms);

            sw.Start();
            DoWith2Locks();
            sw.Stop();
            lockTicks = sw.ElapsedTicks;
            withLocksMs = (lockTicks * 1000) / Stopwatch.Frequency /2;
            Console.WriteLine("With 2 locks  = {0} milliseconds", withLocksMs);

            sw.Start();
            DoWith16Locks();
            sw.Stop();
            lockTicks = sw.ElapsedTicks;
            withLocksMs = (lockTicks * 1000) / Stopwatch.Frequency / 16;
            Console.WriteLine("With 16 locks  = {0} milliseconds", withLocksMs);

            sw.Start();
            DoWith64Locks();
            sw.Stop();
            lockTicks = sw.ElapsedTicks;
            withLocksMs = (lockTicks * 1000) / Stopwatch.Frequency / 64;
            Console.WriteLine("With 64 locks  = {0} milliseconds", withLocksMs);
        }

        [TestMethod]
        public void TestMethod6()
        {
            ParallelLoopResult result = Parallel.For(0, 10, i => {
                Console.WriteLine("{0}, task: {1} , thread: {2}", i, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
            Console.WriteLine(result.IsCompleted);

            Parallel.For<string>(0, 20,
                () => {
                    Console.WriteLine("init thread {0},  task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                    return string.Format("t: {0}", Thread.CurrentThread.ManagedThreadId);
                },
                (i, pls, str) => {
                    Console.WriteLine("body  i {0}  str1 {1}  thread {2}  task {3}", i, str, Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                    return string.Format("i {0}", i);
                },
                (str1) => {
                    Console.WriteLine("finally {0}", str1);
                }
                );
        }
    }
}
