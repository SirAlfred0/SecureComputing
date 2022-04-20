using System;
using System.Numerics;
using SecureComputing.Entites;
using SecureComputing.Enums;
using SecureComputing.Services;

namespace SecureComputing.Programs.RSADigitalSignature
{
    class RSADigitalSignature
    {
        private static readonly Keys primes = new Keys();
        private static readonly Keys keys = new Keys();

        public static Keys GetKeys()
        {
            BigInteger randomNumber, remainder;
            Random random = new Random();

            do
            {
                UIManager.AddUI(PrintOption.GetRSASignPrime);

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

        public static int GetDocumet()
        {
            int userInput;
            do
            {
                UIManager.AddUI(PrintOption.GetRSASignDoc);
                userInput = int.Parse(Console.ReadLine());
            } while (userInput <= 0 && userInput >= 6);

            return userInput * 10;
        }

        public static BigInteger SignDocument(int document)
        {
            var v = (primes.KeyOne - 1) * (primes.KeyTwo - 1);
            var d = MathTools.ModlueInverse(keys.KeyTwo, v);

            return MathTools.FastPowering(document, d, keys.KeyOne);
        }

        public static bool ValidateDocument(int document,BigInteger signedDocument)
        {
            return MathTools.FastPowering(signedDocument, keys.KeyTwo, keys.KeyOne) == document;
        }
    }
}
