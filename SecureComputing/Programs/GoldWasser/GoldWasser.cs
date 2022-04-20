using System;
using System.Numerics;
using SecureComputing.Enums;
using SecureComputing.Services;
using SecureComputing.Entites;

namespace SecureComputing.Programs.GoldWasser
{
    static class GoldWasser
    {
        private static readonly Keys primes = new Keys();
       

        public static Keys GetKeys()
        {
            Random random = new Random();
            BigInteger a;
            var keys = new Keys();
            do
            {
                UIManager.AddUI(PrintOption.GetGoldKeys);

                var userInput = Console.ReadLine().Split(',');
                primes.KeyOne = BigInteger.Parse(userInput[0]);
                primes.KeyTwo = BigInteger.Parse(userInput[1]);


            } while (primes.KeyOne == primes.KeyTwo || primes.KeyOne < 100 || primes.KeyTwo < 100);

            BigInteger ap, aq;
            do
            {
                a = random.Next(int.Parse(primes.KeyOne.ToString()), int.Parse((primes.KeyOne * primes.KeyTwo).ToString()));

                ap = MathTools.FastPowering(a % primes.KeyOne, (primes.KeyOne - 1) / 2, primes.KeyOne);
                aq = MathTools.FastPowering(a % primes.KeyTwo, (primes.KeyTwo - 1) / 2, primes.KeyTwo);
            } while (ap + 1 != primes.KeyOne || aq + 1 != primes.KeyTwo);
            
            keys.KeyOne = primes.KeyOne * primes.KeyTwo;
            keys.KeyTwo = a;

            return keys;
        }

        public static string GetText()
        {
            string text;
            do
            {
                UIManager.AddUI(PrintOption.GetGoldText);
                text = Console.ReadLine();
            } while (text != "0" && text != "1");

            return text;
        }

        public static BigInteger GetAliceKey(string m,Keys keys)
        {
            var random = new Random();

            var r = random.Next(1, int.Parse(keys.KeyOne.ToString()));
            return m == "0" ? MathTools.FastPowering(r, 2, keys.KeyOne) : (keys.KeyTwo * MathTools.FastPowering(r, 2, keys.KeyOne)) % keys.KeyOne;
        }

        public static string Decryption(BigInteger c)
        {
            return MathTools.FastPowering(c % primes.KeyOne, (primes.KeyOne - 1) / 2, primes.KeyOne) + 1 == primes.KeyOne ? "1" : "0";
        }
    }
}
