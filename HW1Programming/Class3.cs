using System;

public static class Kata
{
    public static int СenturyFromYear(int year)
    {
        int y, x;
        x = year % 100;
        y = year / 100;
        if (x > 0)
        {
            y++;
        }
        return y;
    }
}