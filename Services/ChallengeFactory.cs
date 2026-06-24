using System;
using System.Collections.Generic;
using System.Text;

namespace FlareWall.Services;
using FlareWall.Models;

public static class ChallengeFactory
{
    private static readonly Random Random = new();

    public static Challenge Generate()
    {
        int a = Random.Next(10, 100);
        int b = Random.Next(1, 20);

        int choice = Random.Next(1, 4);

        return choice switch
        {
            1 => CreateRipple(a, b),
            2 => CreateVector(a, b),
            _ => CreateQuantum(a, b)
        };
    }

    private static Challenge CreateRipple(int a, int b)
    {
        return new Challenge
        {
            FunctionName = "Ripple",
            A = a,
            B = b,
            ExpectedAnswer = Ripple(a, b)
        };
    }

    private static Challenge CreateVector(int a, int b)
    {
        return new Challenge
        {
            FunctionName = "Vector",
            A = a,
            B = b,
            ExpectedAnswer = Vector(a, b)
        };
    }

    private static Challenge CreateQuantum(int a, int b)
    {
        return new Challenge
        {
            FunctionName = "Quantum",
            A = a,
            B = b,
            ExpectedAnswer = Quantum(a, b)
        };
    }

    // Replace these later with YOUR secret algorithms

    private static int Ripple(int a, int b)
        => a + b;

    private static int Vector(int a, int b)
        => a * b;

    private static int Quantum(int a, int b)
        => a - b;
}