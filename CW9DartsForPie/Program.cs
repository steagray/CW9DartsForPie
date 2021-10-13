using System;
using System.Threading;
using System.Collections.Generic;

namespace CW9DartsForPie
{
    class Program
    {

        static void Main(string[] args)
        {
            int threadCount = 1;
            int dartNum = 0;

            
            Console.Write("How many threads would you like to run? ");
            threadCount = int.Parse(Console.ReadLine());
            Console.Write("How many darts would you like to throw? ");
            dartNum = int.Parse(Console.ReadLine());

            int totalDartNum = threadCount * dartNum;

            //checks to make sure inputs are valid
            if(dartNum <= 0)
            {
                Console.WriteLine("Number of Darts must be greater than 0");
                return;
            }

            if(threadCount <= 0)
            {
                Console.WriteLine("Number of Threads must be greater than 0");
                return;
            }

            List<Thread> threadList = new List<Thread>();
            List<FindPiThread> FPTList = new List<FindPiThread>();

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            //creates all the threads requested from the user
            //and ties them to the subsequent FindPiThreadObject
            for (int i = 0; i < threadCount; i++)
            {
                FPTList.Add(new FindPiThread(dartNum));
                threadList.Add(new Thread(new ThreadStart(FPTList[i].throwDarts)));
                threadList[i].Start();
                Thread.Sleep(16);
            }

            //tells main() to wait until all threads are done before continuing
            for(int i = 0; i < threadCount; i++)
            {
                threadList[i].Join();
            }

            stopWatch.Stop();

            int totalDartsInside = 0;
            //pools the data from all the FindPiThread objects
            for(int i = 0; i < threadCount; i++)
            {
                totalDartsInside += FPTList[i].getInnerCircleDarts();
            }

            Console.Write("Pi Estimation: ");
            Console.WriteLine(((double)(4 * totalDartsInside) / (double)totalDartNum).ToString());
            Console.WriteLine("Time Taken: {0}", stopWatch.Elapsed.ToString());
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
