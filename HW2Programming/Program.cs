using System.Linq;
using System.Collections.Generic;
using System;

public class Kata
{
    //1
    public static int[] humanYearsCatYearsDogYears(int humanYears)
    {
        int catYears = 0;
        int dogYears = 0;
        if (humanYears == 1)
        {
            catYears = 15;
            dogYears = 15;
        }
        else if(humanYears == 2)
        {
            catYears = 24;
            dogYears = 24;
        }
        else
        {
            catYears = 24 + (humanYears - 2) * 4;
            dogYears = 24 + (humanYears - 2) * 5;
        }
        return new int[] { humanYears, catYears, dogYears };
    }

    //2
    public static int GetAverage(int[] marks)
    {
        int sum = 0;
        for (int i = 0; i < marks.Length; i++)
        {
            sum += marks[i];
        }
        return sum / marks.Length;
    }

    //3
    public static int TwiceAsOld(int dadYears, int sonYears)
    {
        if(sonYears * 2 > dadYears)
            return sonYears * 2 - dadYears;
        else
            return dadYears - sonYears * 2;
    }

    //4
    public static int summation(int num)
    {
        int sum = 0;
        for (int i = 1; i <= num; i++)
        {
            sum += i;
        }
        return sum;
    }

    //5
    private static bool IsPrime(long n)
    {
        if (n <= 1) return false;
        if (n <= 3) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i * i <= n; i += 6)
            if (n % i == 0 || n % (i + 2) == 0)
                return false;
        return true;
    }

    public static long[] Gap(int g, long m, long n)
    {
        long[] s = { 0, 0 };
        for (long i = m; i < n; i++)
        {
            if (IsPrime(i))
            {
                s[0] = s[1];
                s[1] = i;
                if (s[1] - s[0] == g) return s;
            }
        }
        return null;
    }    

    //6
    public static string NumberToString(int num)
    {
        return num.ToString();
    }

    //7 
    public static string Remove(string s, int n)
    {
        int i = 0;
        while (i < n)
        {
            if (s.IndexOf("!") == -1)
            {
                break;
            }
            int x = s.IndexOf("!");
            s = s.Remove(x, 1);
            i += 1;
        }
        return s;
    }    

    //8 
    public static string TripleTrouble(string one, string two, string three)
    {
        string result = "";
        int i = 0;
        while (i != one.Length)
        {
            result += one[i];
            result += two[i];
            result += three[i];
            i++;
        }
        return result;
    }

    //9 
    public static string FakeBin(string x)
    {
        int i = 0;
        string res = "";
        while (i != x.Length)
        {
            if(x[i]<'5') res += "0";
            else res += "1";
            i++;
        }
        return res;
    }

    //10
    public static string AbbrevName(string name)
    {
        return $"{name[0]}.{name[name.IndexOf(' ') + 1]}".ToUpper();
    }


   


}