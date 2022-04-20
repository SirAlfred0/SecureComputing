using System;
using System.Collections.Generic;
using System.Text;
using SecureComputing.Entites;
using SecureComputing.Programs;
using System.Numerics;
using SecureComputing.Services;
using SecureComputing.Enums;

namespace SecureComputing.Programs.MillerRabin
{
    static class MillerRabin
    {
        public static Keys GetKeys()
        {
            UIManager.AddUI(PrintOption.GetMillerKeys);

            var keys = new Keys();
            var userInput = Console.ReadLine().Split(',');
            keys.KeyOne = BigInteger.Parse(userInput[0]);
            keys.KeyTwo = BigInteger.Parse(userInput[1]);

            return keys;
        }


        public static int RunTest(BigInteger n,BigInteger a)
        {
            BigInteger gcd = MathTools.GCD(a, n);

            if ((gcd > 1 && gcd < n) || n % 2 == 0)
                return 1;

            BigInteger m = n - 1;

            BigInteger k = -1;
            BigInteger q = 0;

            do
            {
                k++;
                var power = MathTools.FastPowering(2, k, 9999999999999999999);
                if (m % power == 0)
                {
                    q = m / power;
                }
            } while (q % 2 == 0);

            a = MathTools.FastPowering(a, q, n);

            if ((a - 1) % n == 0) return 0;

            for (var i = 0; i < k; i++)
            {
                if ((a + 1) % n == 0)
                {
                    return 0;
                }
                a = MathTools.FastPowering(a, 2, n);
            }
            return 1;
        }
    }
}
