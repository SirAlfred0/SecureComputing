using System;
using System.Collections.Generic;
using System.Text;
using SecureComputing.Services;
using SecureComputing.Entites;
using System.Numerics;
using SecureComputing.Enums;

namespace SecureComputing.Programs.DiffieHellMan
{
    class DiffieHellMan
    {
        private static int aliceSecretKey;
        private static int bobSecretKey;
        public static Keys GetPublicKeys()
        {
            UIManager.AddUI(PrintOption.GetDiffieKeys);

            var userInput = Console.ReadLine().Split(',');

            return new Keys() {
                KeyOne = BigInteger.Parse(userInput[0]),
                KeyTwo = BigInteger.Parse(userInput[1])
            };
        }

        public static BigInteger GetAlicePublicKey(Keys publicKeys)
        {
            var random = new Random();
            aliceSecretKey = random.Next(1, int.Parse(publicKeys.KeyOne.ToString()));

            return MathTools.FastPowering(publicKeys.KeyTwo, aliceSecretKey, publicKeys.KeyOne) + publicKeys.KeyOne;
        }


        public static BigInteger GetBobPublicKey(Keys publicKeys)
        {
            var random = new Random();
            bobSecretKey = random.Next(1,int.Parse(publicKeys.KeyOne.ToString()));

            return MathTools.FastPowering(publicKeys.KeyTwo, bobSecretKey, publicKeys.KeyOne) + publicKeys.KeyOne;
        }

        public static BigInteger CalculateSharedSecretKey(Keys publicKeys,BigInteger aliceKey,BigInteger bobKey)
        {
            BigInteger alice = MathTools.FastPowering(aliceKey, bobSecretKey, publicKeys.KeyOne);
            BigInteger bob = MathTools.FastPowering(bobKey, aliceSecretKey, publicKeys.KeyOne);

            return  alice == bob ? alice : 0;
        }
    }
}
