﻿namespace Kontur.BigLibrary.Tests.Core.Helpers;

public static class IntGenerator
{
    private static readonly Random rnd = new(100);

    public static int Get()
    {
        return rnd.Next();
    }
}