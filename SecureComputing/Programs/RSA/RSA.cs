using System;
using System.Numerics;
using SecureComputing.Entites;
using SecureComputing.Services;
using SecureComputing.Enums;


namespace SecureComputing.Programs.RSA
{
    static class RSA
    {
        private static readonly Keys primes = new Keys();
        private static readonly Keys keys = new Keys();
        public static Keys GetKeys()
        {
            BigInteger randomNumber, remainder;
            Random random = new Random();

            do
            {
                UIManager.AddUI(PrintOption.GetRSAPrime);

                var userInput = Console.ReadLine().Split(',');
                primes.KeyOne = BigInteger.Parse(userInput[0]);
                primes.KeyTwo = BigInteger.Parse(userInput[1]);
            } while (primes.KeyOne == primes.KeyTwo || primes.KeyOne < 100 || primes.KeyTwo < 100);

            

            do
            {
                randomNumber = random.Next(2, 10);
                remainder = random.Next(2, 9);
            } while (((primes.KeyOne - 1) * (primes.KeyTwo - 1)) % remainder == 0 || (randomNumber * remainder) % 2 == 0);

            keys.KeyOne = primes.KeyOne * primes.KeyTwo;
            keys.KeyTwo = ((primes.KeyOne - 1) * (primes.KeyTwo - 1) * randomNumber) + remainder;

            if (primes.KeyTwo < 0)
            {
                primes.KeyTwo *= -1;
            }


            return keys;
        }

        public static string GetText()
        {
            UIManager.AddUI(PrintOption.GetRSAText);

            return Console.ReadLine();
        }


        private static BigInteger ConvertStringToInt(string text)
        {
            string integerCodeString = string.Empty;

            foreach (var character in text)
            {
                integerCodeString += ((int)character + 68);
            }

            return BigInteger.Parse(integerCodeString);
        }

        public static BigInteger GenerateAliceKey(string text, BigInteger n, BigInteger e)
        {
            return MathTools.FastPowering(ConvertStringToInt(text), e, n) + n;
        }

        public static string DecrypteAliceKey(BigInteger aliceKey)
        {
            var v = (primes.KeyOne - 1) * (primes.KeyTwo - 1);
            var d = MathTools.ModlueInverse(keys.KeyTwo, v);
            
            var codedText = MathTools.FastPowering(aliceKey, d, keys.KeyOne);

            return Decode(codedText.ToString());
        }

        private static string Decode(string code)
        {
            var decodedPart = string.Empty;

            for (int i = 0; i < (code.Length / 3); i++)
            {
                decodedPart += (char)(Int32.Parse(code.Substring(i * 3, 3)) - 68);
            }

            return decodedPart;
        }
    }
}
