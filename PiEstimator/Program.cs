﻿namespace PiEstimator
{
    using System;
    using System.Numerics;

    class Program
    {
        private static void Main(string[] args)
        {
            // GregoryLeibnizSeries();
            // NilakanthaSeries();
            NilakanthaSeriesBigInt();
            Console.ReadKey();
        }

        private static void NilakanthaSeries()
        {
            // Nilakantha series
            // https://en.wikipedia.org/wiki/Nilakantha_Somayaji
            double pi = 3d;

            double sign = 1;

            for (double i = 2; i < int.MaxValue; i += 2)
            {
                double delta = sign * 4d / (i * (i + 1) * (i + 2));
                pi = pi + delta;

                if ((int) i % 10000000 == 0)
                {
                    Console.WriteLine("i: {0} pi: {1}", i, pi);
                }

                sign = sign * -1;
            }
        }

        private static void NilakanthaSeriesBigInt()
        {
            // Nilakantha series
            BigInteger sign = 1;
            BigInteger multiplier = BigInteger.Pow(10, 100);

            BigInteger pi = 3 * multiplier;
            for (BigInteger i = 2; i < int.MaxValue; i += 2)
            {
                BigInteger denominator = i * (i + 1) * (i + 2);
                BigInteger numerator = multiplier * 4;
                BigInteger quotient = BigInteger.DivRem(numerator, denominator, out BigInteger remainder);
                BigInteger delta = sign * quotient;
                if (remainder * 2 >= denominator)
                {
                    delta += sign;
                }
                pi = pi + delta;

                if ((int) i % 10000000 == 0)
                {
                    Console.WriteLine("i: {0} pi: {1}", i, pi);
                }

                sign = sign * -1;
            }
        }

        private static void GregoryLeibnizSeries()
        {
            // https://en.wikipedia.org/wiki/Leibniz_formula_for_%CF%80
            // Gregory–Leibniz series
            double pi = 0d;

            double sign = 1;

            for (double i = 1; i < int.MaxValue; i += 2)
            {
                double delta = sign * 4d / i;
                pi = pi + delta;

                if (((int) i - 1) % 10000000 == 0)
                {
                    Console.WriteLine("i: {0} pi: {1}", i, pi);
                }

                sign = sign * -1;
            }
        }
    }
}