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

            //var thread1 = new Thread(DoAction);
            //var thread2 = new Thread(new ThreadStart(DoAction));
            //var thread3 = new Thread(()=>DoAction());

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();

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

    }
}
