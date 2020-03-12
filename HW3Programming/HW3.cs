using System;
using System.Text.RegularExpressions;

public static class Kata
{
    //1
    public static string Solution(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    //2
    public static string SayHello(string[] name, string city, string state)
    {
        string res = "";
        for (int i = 0; i < name.Length; i++)
        {
            if (i != name.Length - 1)
            {
                res = res + name[i] + " ";
            }
            else
            {
                res = res + name[i];
            }
        }
        return ($"Hello, {res}! Welcome to {city}, {state}!");
    }

    //2 better
    public static string SayHello1(string[] name, string city, string state)
    {
        return $"Hello, {String.Join(" ", name)}! Welcome to {city}, {state}!";
    }

    //3
    public static string ReplaceDots(string str)
    {
        return str.Replace(".", "-");
    }

    //4
    public static int StrCount(string str, string letter)
    {
        return Regex.Matches(str, letter).Count;        
    }

    //5
    public static string Correct(string text)
    {
        return text.Replace("5", "S").Replace("0", "O").Replace("1", "I");
    }

    //6
    public static string ToAlternatingCase(this string s)
    {
        string res = "";
        foreach (char c in s)
        {
            if(Char.IsUpper(c))
            {
                res += Char.ToLower(c);
            }
            else
            {
                res += Char.ToUpper(c);
            }
        }
        return res;
    }

    //7
    public static int[] Maps(int[] x)
    {
        for (int i = 0; i < x.Length; i++)
        {
            x[i] *= 2;
        }
        return x;
    }

    //8
    public static int CountSheeps(bool[] sheeps)
    {
        int res = 0;
        foreach(bool s in sheeps)
        {
            if (s == true)
            {
                res++;
            }
        }
        return res;
    }

    //9
    public static int[] ReverseSeq(int n)
    {
        int[] res = new int[n];
        int counter = 0;
        for (int i = n; i > 0; i--)
        {
            res[counter] = i;
            counter++;
        }
        return res;
    }

    //10
    public static string TwoSort(string[] s)
    {
        Array.Sort(s, StringComparer.Ordinal);
        string res = "";
        for (int i = 0; i < s[0].Length; i++)
        {
            if (i!=s[0].Length - 1)
            {
                res = res + s[0][i] + "***";
            }
            else
            {
                res = res + s[0][i];
            }
        }
        return res;
    }

}

