using System;
public static class Clock
{
    public static int Past(int h, int m, int s)
    {
        int result = 0;
        result += (h * 3600000);
        result += (m * 60000);
        result += (s * 1000);
        return result;
    }
}
