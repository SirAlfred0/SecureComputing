using System;
using System.Numerics;
using SecureComputing.Enums;
using SecureComputing.Services;
using SecureComputing.Entites;
using SecureComputing.Programs;

namespace SecureComputing.Programs.ElJemal
{
    static class ElJemal
    {
        private static int alicePrivateKey;


        public static BigInteger GetPrime()
        {
            BigInteger primeNumber;

            do
            {
                UIManager.AddUI(PrintOption.GetElJemalPrime);
                primeNumber = Int32.Parse(Console.ReadLine());
            } while (primeNumber < 131);

            return primeNumber;
        }

        public static string GetText()
        {
            UIManager.AddUI(PrintOption.GetElJemalText);

            return Console.ReadLine();
        }

        public static PublicKeys GeneratePublicKey(BigInteger primeNumber)
        {
            var random = new Random();
            BigInteger g = random.Next(1, Int32.Parse(primeNumber.ToString())) % primeNumber;

            var Key = new PublicKeys() {
                Prime = primeNumber,
                SecondKey = g
            };

            return Key;
        } 

        

        public static BigInteger GenerateAlicePublicKey(BigInteger primeNumber, BigInteger g)
        {
            var random = new Random();

            alicePrivateKey = random.Next(1, int.Parse(primeNumber.ToString()));

            return MathTools.FastPowering(g, alicePrivateKey, primeNumber); ;
        }

        public static Keys CharacterEncryption(BigInteger primeNumber, char character, BigInteger g, BigInteger alicePublicKey)
        {
            var random = new Random();
            var characterCode = (int)character;


            BigInteger k = random.Next(1, 999999999) % primeNumber;

            
            return new Keys() {
                KeyOne = MathTools.FastPowering(g, k, primeNumber),
                KeyTwo = (characterCode * MathTools.FastPowering(alicePublicKey, k, primeNumber)) % primeNumber
            };
        }

        public static char CharacterDecryption(BigInteger primeNumber, Keys bobCipherKey)
        {
            var c1InverseModuloA = MathTools.FastPowering(bobCipherKey.KeyOne, primeNumber - 1 - alicePrivateKey, primeNumber);
            BigInteger value = (c1InverseModuloA * bobCipherKey.KeyTwo) % primeNumber;
            return (char)value;
        }

    }
}
