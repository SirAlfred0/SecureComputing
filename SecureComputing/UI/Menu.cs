using System;
using System.Collections.Generic;
using System.Text;

namespace SecureComputing.UI
{
    static class Menu
    {
        public const string mainMenu = "select one of the options below\n\n1.El Jemal\n2.RSA\n3.MillerRabin\n4.Diffie-Hellman Key Exchange\n5.GoldWasser\n6.RSA Digital Signature\n7.ElJemal Digital Signature\n0.Exit\n\n";
        public const string Separator = "____________________________________________________________________________\npress any key to continue...\n";

        public static class ElJemal
        {
            public const string getPrime = "\nas a third party you need to enter a prime number which is greater than 131";
            public const string getText = "\nas bob you should enter text for alice";
            public const string result = "\nhey alice you have a new message from bob:";
        }

        public static class RSA
        {
            public const string getPrime = "\nas bob you need to enter two primes use , between them like 131,229\n(primes should not be equal and must be bigger than 100)";
            public const string getText = "\nas alice you should enter text for bob";
            public const string result = "\nhey bob you have a new message from alice:";
        }
        
        public static class MillerRabin
        {
            public const string getKeys = "\nfor miller rabin test you need to enter first number as n and second number as a with ',' like 17,5";
            public const string failed = "\ntest failed its means n may be a prime";
            public const string success = "\nn is composite";
        }

        public static class DiffeHellMan
        {
            public const string getKeys = "\nas a third party you need to enter a prime p and integer g that having large prime order in p primitive roots group like p,g";
            public const string failed = "\nkey exchange failed";
            public const string success = "\nkey exchange done successfully\nsecret key is: ";
        }

        public static class GoldWasser
        {
            public const string getKeys = "\nas bob you need to enter two primes use , between them like 131,229\n(primes should not be equal and must be bigger than 100)";
            public const string getText = "\nAlice\nGold Wasser algorithm designed to send only one bit to a friend so choose one from {0,1} to send";
            public const string result = "\nhey bob you have a new big message from alice:";
        }

        public static class RSADigitalSignature
        {
            public const string getPrime = "\nas bob you need to enter two primes use , between them like 131,229\n(primes should not be equal and must be bigger than 100)";
            public const string getDocument = "\nselect one of below documents to sign\n1.Document1.txt\n2.Document2.txt\n3.Document3.txt\n4.Document4.txt\n5.Document5.txt";
            public const string Success = "\nDecrypted Key From Public Key is equal to Document\nDocument Is: ";
            public const string Failer = "\nDecrypted Key From Public Key is not equal to Document";
        }

        public static class ElJemalDigitalSignature
        {
            public const string getPrime = "\nas a third party you need to enter a prime number which is greater than 131";
            public const string getDocument = "\nselect one of below documents to sign\n1.Document1.txt\n2.Document2.txt\n3.Document3.txt\n4.Document4.txt\n5.Document5.txt";
            public const string Success = "\nDecrypted Key From Public Key is equal to Document\nDocument Is: ";
            public const string Failer = "\nDecrypted Key From Public Key is not equal to Document";
        }
    }
}
