using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassWork2Codewars
{
    public class Kata
    {
        //1
        public static bool BetterThanAverage(int[] ClassPoints, int YourPoints)
        {
            float res = 0;
            foreach (int i in ClassPoints)
            {
                res += i;
            }
            return (res + YourPoints) / (ClassPoints.Length + 1) < YourPoints;
            //return ClassPoints.Average() < YourPoints;
        }

        //2
        public static int Grow(int[] x)
        {
            int res = 1;
            foreach (int i in x)
            {
                res *= i;
            }
            return res;
            //return x.Aggregate((a,b) => a*b);
        }

        //3
        public static int PositiveSum(int[] arr)
        {
            int res = 0;
            foreach (int i in arr)
            {
                if (i > 0)
                {
                    res += i;
                }
            }
            return res;
            //return arr.Where(x => x > 0).Sum();
        }
    
        //4
        public static Dictionary<string, int> Interpret(string[] program)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            string[] tempMas = new string[] { };
            for (int i = 0; i < program.Length; i++)
            {
                tempMas = program[i].Split(" ");
                if (tempMas[0] == "mov")
                {
                    int num;
                    if (tempMas[2].All(char.IsLetter))
                    {
                        num = res[tempMas[2]];
                    }
                    else
                    {
                        num = Convert.ToInt32(tempMas[2]);
                    }
                    if (res.ContainsKey(tempMas[1]))
                    {
                        res[tempMas[1]] = num;
                    }
                    else
                    {
                        res.Add(tempMas[1], num);
                    }
                }
                else if(tempMas[0]=="inc")
                {
                    res[tempMas[1]]++;
                }
                else if (tempMas[0] == "dec")
                {
                    res[tempMas[1]]--;
                }
                else
                {
                    if (res.ContainsKey(tempMas[1]))
                    {
                        if (res[tempMas[1]] != 0)
                        {
                            i += Convert.ToInt32(tempMas[2]) - 1;
                            continue;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(tempMas[1]) != 0)
                        {
                            i += Convert.ToInt32(tempMas[2]) - 1;
                            continue;
                        }
                    }
                }
            }
            return res;
        }

        //static void Main(string[] args)
        //{
        //    Dictionary<string, int> result;
        //    string Text = "";
        //    result = Interpret(new[] { "mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a" });
        //    foreach (KeyValuePair<string, int> kvp in result)
        //    {
        //        Text += string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        //    }
        //    Console.Write(Text);
        //    Console.Read();
        //}


        //5
        public static string Lcs(string a, string b)
        {
            int m = a.Length;
            int n = b.Length;
            int[,] arr = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        arr[i, j] = 0;
                    }
                    else if (a[i - 1] == b[j - 1])
                    {
                        arr[i, j] = arr[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        arr[i, j] = Math.Max(arr[i - 1, j], arr[i, j - 1]);
                    }
                }
            }

            int index = arr[m, n];
            int tempIndex = index;
            char[] mas = new char[index + 1];
            mas[index] = ' ';
            int tempM = m;
            int tempN = n;
            while (tempM > 0 && tempN > 0)
            {
                if (a[tempM - 1] == b[tempN - 1])
                {
                    mas[index - 1] = a[tempM - 1];
                    tempM--;
                    tempN--;
                    index--;
                }
                else if (arr[tempM - 1, tempN] > arr[tempM, tempN - 1])
                {
                    tempM--;
                }
                else
                {
                    tempN--;
                }
            }
            string res = "";
            for (int i = 0; i < tempIndex; i++)
            {
                res = res + mas[i];
            }
            return res;
        }
    }
}
