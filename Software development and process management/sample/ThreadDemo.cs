using System;
using System.Threading;

// Thread demo
// run a worker thread to do a long calculation
// main thread waits for calculation to finish
// calculation thread has above normal priority
// threads named for traceability
// a thread can run any method which returns void via a delegate

// test class
class ThreadDemo
{
    // method to be run in a separate thread, via delegate
    static void DoCalculation()
    {
        long total = 0;
        Thread thisThread;

        thisThread = Thread.CurrentThread;
        Console.WriteLine("Starting " + thisThread.Name);

        // long calculation total
        for (int i = 0; i < 10; i++)
        {
            total += i;
            Thread.Sleep(100);               // 100 milliseconds
        }

        Console.WriteLine("Finished " + thisThread.Name + " " + total);
    }


    // main method
    public static void Main()
    {
        // name this thread "Main thread", default name is blank
        Thread thisThread;
        thisThread = Thread.CurrentThread;
        thisThread.Name = "Main thread";

        Console.WriteLine(thisThread.Name + " has started");

        // create and run foreground thread for DoCalculation
        ThreadStart threadStart = new ThreadStart(DoCalculation);	// public delegate void ThreadStart()
        Thread thread = new Thread(threadStart);

        // default thread type is foregound i.e. thread.IsBackground  = false
        // for a background set thread.IsBackground  = true
        // a background thread cannot live on after parent thread, a foreground thread can

        thread.Name = "DoCalculation worker thread";
        thread.Priority = ThreadPriority.AboveNormal;
        thread.Start();

        thread.Join();							                    // wait for foreground thread it terminate

        Console.WriteLine("Finishing " + thisThread.Name);

        // use thread pools for efficiency
    }
}