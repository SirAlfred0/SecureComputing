using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace SecureComputing.Programs
{
    class MathTools
    {
        public static BigInteger FastPowering(BigInteger baseNumber, BigInteger powerNumber, BigInteger p)
        {
            BigInteger finalNumber = 1;

            var binary = Convert.ToString(Int64.Parse(powerNumber.ToString()), 2);
            var basePower = new BigInteger[binary.Length];

            basePower[0] = baseNumber % p;

            for (var j = 1; j < binary.Length; j++)
            {
                basePower[j] = basePower[j - 1] * basePower[j - 1] % p;
            }

            for (var t = 0; t < binary.Length; t++)
            {
                if (binary[(binary.Length - 1) - t] != '0')
                {
                    finalNumber = (finalNumber * (basePower[t] * (binary[(binary.Length - 1) - t] - '0'))) % p;
                }

            }
            return finalNumber;
        }


        public static BigInteger ModlueInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                BigInteger q = a / m;
                BigInteger t = m;


                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }

        public static BigInteger GCD(BigInteger a, BigInteger b)
        {
            BigInteger max, min, t;
            if (a > b)
            {
                max = a;
                min = b;
            }
            else
            {
                max = b;
                min = a;
            }

            while (min != 0)
            {
                t = min;
                min = max % min;
                max = t;
            }

            return max;
        }
    }
}
