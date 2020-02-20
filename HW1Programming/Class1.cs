using System;

public static class Kata
{
    public static int ToBinary(int n)
    {
        string bin = Convert.ToString(n, 2);
        return Int32.Parse(bin);
    }
}