//c#

using System;
using System.Diagnostics;

namespace Shvydkist
{
    class Program
    {
        //3TASK

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Random rnd = new Random();
            int n = 500;
            double[,] arr1 = new double[n, n];
            double[,] arr2 = new double[n, n];


            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    arr1[i, j] = GetRandomNumber(1.0, 1.1);
                    arr2[i, j] = GetRandomNumber(1.0, 1.1);
                }
            }

            double[,] sum = new double[n, n];

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    for (int k = 1; k < n; k++)
                    {
                        sum[i, j] += arr1[i, k] * arr2[k, j];
                    }
                }
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            Console.WriteLine("\nRunTime " + elapsedTime);
            //release: 01.57 debug 02.64

            Console.Read();
        }

        //1TASK

        //static void Main(string[] args)
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();

        //    int n = 3000;
        //    Console.WriteLine(n);

        //    double sum = 0;

        //    for (int i = 1; i < n; i++)
        //    {
        //        for (int j = 1; j < n; j++)
        //        {
        //            sum += (1 /(i * j));
        //        }
        //    }
        //    Console.Write("SUM: "+ sum);

        //    stopWatch.Stop();
        //    TimeSpan ts = stopWatch.Elapsed;
        //    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        //        ts.Hours, ts.Minutes, ts.Seconds,
        //        ts.Milliseconds / 10);

        //    Console.WriteLine("\nRunTime " + elapsedTime);

        //    //release: 00.02 debug 00.03

        //    Console.Read();
        //}


        //2TASK

        //public static double GetRandomNumber(double minimum, double maximum)
        //{
        //    Random random = new Random();
        //    return random.NextDouble() * (maximum - minimum) + minimum;
        //}

        //static void Main(string[] args)
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();

        //    Random rnd = new Random();
        //    int n = 10000;
        //    double[] arr = new double[n];

        //    for (int i = 0; i < n; i++)
        //    {
        //        arr[i] = GetRandomNumber(1.0, 1.1);
        //    }

        //    double sum = 0;

        //    for (int i = 1; i < n; i++)
        //    {
        //        for (int j = 1; j < n; j++)
        //        {
        //            sum += (1 / (arr[i] * arr[j]));
        //        }
        //    }

        //    Console.Write("SUM: " + sum);

        //    stopWatch.Stop();
        //    TimeSpan ts = stopWatch.Elapsed;
        //    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        //        ts.Hours, ts.Minutes, ts.Seconds,
        //        ts.Milliseconds / 10);

        //    Console.WriteLine("\nRunTime " + elapsedTime);

        //    //release: 00.14 debug 00.32

        //    Console.Read();
        //}

    }
}
