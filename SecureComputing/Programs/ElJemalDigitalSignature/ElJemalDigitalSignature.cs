using System;
using System.Numerics;
using SecureComputing.Services;
using SecureComputing.Enums;
using SecureComputing.Entites;

namespace SecureComputing.Programs.ElJemalDigitalSignature
{
    class ElJemalDigitalSignature
    {
        private static int alicePrivateKey;
        private static PublicKeys publicKeys;
        public static PublicKeys GetKeys()
        {
            BigInteger primeNumber;
            var random = new Random();

            do
            {
                UIManager.AddUI(PrintOption.GetElJemalPrime);
                primeNumber = Int32.Parse(Console.ReadLine());
            } while (primeNumber < 131);

            BigInteger g = random.Next(1, Int32.Parse(primeNumber.ToString())) % primeNumber;

            publicKeys = new PublicKeys()
            {
                Prime = primeNumber,
                SecondKey = g
            };

            return publicKeys;
        }

        public static BigInteger GenerateAlicePublicKey()
        {
            var random = new Random();

            alicePrivateKey = random.Next(1, int.Parse(publicKeys.Prime.ToString()));

            return MathTools.FastPowering(publicKeys.SecondKey, alicePrivateKey, publicKeys.Prime); ;
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

        public static Keys SignDocument(int document)
        {
            var random = new Random();
            var keys = new Keys();
            BigInteger k;

            do
            {
                k = random.Next(1, int.Parse(publicKeys.Prime.ToString()));
            } while (MathTools.GCD(k,publicKeys.Prime - 1) != 1);

            


            var kInvers = MathTools.ModlueInverse(k, publicKeys.Prime - 1);
            keys.KeyOne = MathTools.FastPowering(publicKeys.SecondKey, k, publicKeys.Prime);
            keys.KeyTwo = (((document - alicePrivateKey * keys.KeyOne) * kInvers) % (publicKeys.Prime - 1)) + (publicKeys.Prime - 1);

            return keys;
        }

        public static bool ValidateDocument(int document, Keys signedDocument,BigInteger alicePublicKey)
        {
            var partOne = MathTools.FastPowering(alicePublicKey, signedDocument.KeyOne, publicKeys.Prime);
            var partTwo = MathTools.FastPowering(signedDocument.KeyOne, signedDocument.KeyTwo, publicKeys.Prime);
            return (partOne * partTwo) % publicKeys.Prime == MathTools.FastPowering(publicKeys.SecondKey, document, publicKeys.Prime);
        }
    }
}
