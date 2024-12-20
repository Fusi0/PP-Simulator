﻿namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        return Math.Clamp(value, min, max);
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();
        if (value.Length > max)
        {
            value = value.Substring(0, max);
            value = value.Trim();
        }
        if (value.Length < min)
        {
            value = value.PadRight(min, placeholder);
        }
        value = value[0].ToString().ToUpper() + value.Substring((1));
        return value;
    }
}


