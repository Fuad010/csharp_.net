using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dictionary
            // dictionary

            //int a = 14;
            //int b = 14;
            //bool c = false;

            //if (a == b) Console.WriteLine("true");
            //else if (a > b) Console.WriteLine("a is more than b");
            //else if (a < b) Console.WriteLine("a is less than b");
            //else Console.WriteLine("false");

            //Dictionary<string, string> myFirstDictionaries = new Dictionary<string, string>();
            //myFirstDictionaries.Add("34", "privvet");
            //myFirstDictionaries.Add("345", "privvet1");
            //myFirstDictionaries.Add("346", "privvet3");
            //myFirstDictionaries.Add("347", "privvet4");

            //foreach (var my in myFirstDictionaries)
            //{
            //    Console.WriteLine(my.Key);
            //}
            #endregion

            #region Threads

            //string result = "";
            //string result1 = "";
            //string result2 = "";

            //var thread1 = new Thread(() => result = PrintThreadInfo(352));
            //thread1.Name = "thread1";
            //var thread2 = new Thread(new ThreadStart(() => result1 = PrintThreadInfo(5474578)));
            //thread2.Name = "thread2";
            //thread2.IsBackground = true;

            //ThreadPool.QueueUserWorkItem<int>((x) => { result2 = PrintThreadInfo(25635); }, 10, true);

            //thread1.Start();
            //thread2.Start();

            //for (int i = 0; i < 100; i++)
            //{
            var worker = new Worker();

            ThreadPool.QueueUserWorkItem((x) => worker.AddNumber());
            //ThreadPool.QueueUserWorkItem((x) => worker.AddNumber());
            //ThreadPool.QueueUserWorkItem((x) => worker.AddNumber());
            //ThreadPool.QueueUserWorkItem((x) => worker.AddNumber());

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            Console.WriteLine(worker);
            //}

            #endregion

        }

        public static void DoAction()
        {
            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;

            Console.WriteLine($"processorId: {processorId}, name: {name}, threadId: {threadId}, priority: {priority}, threadState: {threadState}");
        }
        public static string PrintThreadInfo(int myThreadId)
        {
            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;
            var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            var isBackground = Thread.CurrentThread.IsBackground;

            Console.WriteLine("myThreadId: " + myThreadId);

            Console.WriteLine("processorId: " + processorId);
            Console.WriteLine("name: " + name);
            Console.WriteLine("threadId: " + threadId);
            Console.WriteLine("priority: " + priority);
            Console.WriteLine("threadState: " + threadState);
            Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
            Console.WriteLine("isBackground: " + isBackground);
            Console.WriteLine();

            return Guid.NewGuid().ToString();
        }
    }
    public class Worker
    {
        private List<int> _numbers = new List<int>();
        private int _counter = 0;
        private Random _random = new Random();

        private Mutex _mutex = new Mutex(false, "Mutex");
        private AutoResetEvent _autoResetEvent = new AutoResetEvent(true);
        private Semaphore _semaphore = new Semaphore(1, 1);
        private SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public void AddNumberWithSemaphorSlim()
        {
            _semaphoreSlim.Wait();
            _numbers.Add(_random.Next());
            _counter++;

            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;
            var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            var isBackground = Thread.CurrentThread.IsBackground;

            Console.WriteLine("processorId: " + processorId);
            Console.WriteLine("name: " + name);
            Console.WriteLine("threadId: " + threadId);
            Console.WriteLine("priority: " + priority);
            Console.WriteLine("threadState: " + threadState);
            Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
            Console.WriteLine("isBackground: " + isBackground);
            Console.WriteLine();

            _semaphoreSlim.Release();
        }

        public void AddNumberSemaphore()
        {
            _semaphore.WaitOne();
            _numbers.Add(_random.Next());
            _counter++;

            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;
            var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            var isBackground = Thread.CurrentThread.IsBackground;

            Console.WriteLine("processorId: " + processorId);
            Console.WriteLine("name: " + name);
            Console.WriteLine("threadId: " + threadId);
            Console.WriteLine("priority: " + priority);
            Console.WriteLine("threadState: " + threadState);
            Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
            Console.WriteLine("isBackground: " + isBackground);
            Console.WriteLine();

            _semaphore.Release();
        }

        public void AddNumberWithAuthResetEvent()
        {
            _autoResetEvent.WaitOne();
            _numbers.Add(_random.Next());
            _counter++;

            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;
            var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            var isBackground = Thread.CurrentThread.IsBackground;

            Console.WriteLine("processorId: " + processorId);
            Console.WriteLine("name: " + name);
            Console.WriteLine("threadId: " + threadId);
            Console.WriteLine("priority: " + priority);
            Console.WriteLine("threadState: " + threadState);
            Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
            Console.WriteLine("isBackground: " + isBackground);
            Console.WriteLine();

            _autoResetEvent.Set();
        }

        public void AddNumberWithLock()
        {
            lock (_numbers)
            {
                _numbers.Add(_random.Next());
                _counter++;
            }

            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;
            var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            var isBackground = Thread.CurrentThread.IsBackground;

            Console.WriteLine("processorId: " + processorId);
            Console.WriteLine("name: " + name);
            Console.WriteLine("threadId: " + threadId);
            Console.WriteLine("priority: " + priority);
            Console.WriteLine("threadState: " + threadState);
            Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
            Console.WriteLine("isBackground: " + isBackground);
            Console.WriteLine();
        }

        public void AddNumber()
        {
            _mutex.WaitOne();
            _numbers.Add(_random.Next());
            _counter++;
            _mutex.ReleaseMutex();

            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;
            var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            var isBackground = Thread.CurrentThread.IsBackground;

            Console.WriteLine("processorId: " + processorId);
            Console.WriteLine("name: " + name);
            Console.WriteLine("threadId: " + threadId);
            Console.WriteLine("priority: " + priority);
            Console.WriteLine("threadState: " + threadState);
            Console.WriteLine("isThreadPoolThread: " + isThreadPoolThread);
            Console.WriteLine("isBackground: " + isBackground);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"counter: {_counter}, numbers: [{string.Join(", ", _numbers)}]";
        }
    }
}
