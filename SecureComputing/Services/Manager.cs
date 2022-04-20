using System;
using SecureComputing.Enums;
using SecureComputing.Programs.ElJemal;
using SecureComputing.Programs.RSA;
using SecureComputing.Programs.MillerRabin;
using SecureComputing.Programs.DiffieHellMan;
using SecureComputing.Programs.GoldWasser;
using SecureComputing.Programs.RSADigitalSignature;
using SecureComputing.Programs.ElJemalDigitalSignature;

namespace SecureComputing.Services
{
    static class Manager
    {
        public static void Manage()
        {
            programs userInput;
            do {
                UIManager.AddUI(PrintOption.MainMenu);
                Enum.TryParse(Console.ReadLine(), ignoreCase: true,out userInput);

                switch (userInput)
                {
                    case programs.Exit:
                        break;
                    case programs.ElJemal: RunElJemal();
                        break;
                    case programs.RSA: RunRSA();
                        break;
                    case programs.MillerRabin: RunMiller();
                        break;
                    case programs.DiffieHellMan: RunDiffieHellman();
                        break;
                    case programs.GoldWasser: RunGoldWasser();
                        break;
                    case programs.RSADigitalSignature: RunRSADigitalSign();
                        break;
                    case programs.ElJemalDigitalSignature: RunElJemalDigitalSign();
                        break;
                    default: throw new ApplicationException("Invalid Input");
                }
            } while (userInput != programs.Exit);

        }



        private static void RunElJemal()
        {
            string result = string.Empty;
            var primeNumber = ElJemal.GetPrime();
            var text = ElJemal.GetText();

            foreach(var character in text)
            {
                var publicKey = ElJemal.GeneratePublicKey(primeNumber);
                var aliceKey = ElJemal.GenerateAlicePublicKey(publicKey.Prime, publicKey.SecondKey);
                var bobKey = ElJemal.CharacterEncryption(publicKey.Prime, character, publicKey.SecondKey, aliceKey);
                var encryptedCharacter = ElJemal.CharacterDecryption(publicKey.Prime, bobKey);

                result += encryptedCharacter;
            }

            UIManager.AddUI(PrintOption.ElJemalResult);
            Console.WriteLine(result);
            UIManager.AddUI(PrintOption.Separator);
            Console.ReadKey();
        }
        private static void RunRSA()
        {
            var keys = RSA.GetKeys();
            var text = RSA.GetText();

            var charLengthReader = (keys.KeyOne.ToString().Length - 1) / 3;
            var i = charLengthReader * -1;
            var message = string.Empty;

            do
            {
                i += charLengthReader;
                if ((i + charLengthReader) > text.Length - 1)
                {
                    charLengthReader = (text.Length - i);
                }

                var subText = new string(text.Substring(i, charLengthReader));
                var aliceKey = RSA.GenerateAliceKey(subText, keys.KeyOne, keys.KeyTwo);

                message += RSA.DecrypteAliceKey(aliceKey);

            } while ((i + charLengthReader) <= text.Length - 1);

            UIManager.AddUI(PrintOption.RSAResult);
            Console.WriteLine(message);
            UIManager.AddUI(PrintOption.Separator);
            Console.ReadKey();
        }
        private static void RunMiller()
        {
            var keys = MillerRabin.GetKeys();

            var result = MillerRabin.RunTest(keys.KeyOne, keys.KeyTwo);

            if (result == 0)
            {
                UIManager.AddUI(PrintOption.MillerFail);
            }
            else
            {
                UIManager.AddUI(PrintOption.MillerSuccess);
            }

            UIManager.AddUI(PrintOption.Separator);
            Console.ReadKey();
        }
        private static void RunDiffieHellman()
        {
            var keys = DiffieHellMan.GetPublicKeys();
            var aliceKey = DiffieHellMan.GetAlicePublicKey(keys);
            var bobKey = DiffieHellMan.GetBobPublicKey(keys);

            var result = DiffieHellMan.CalculateSharedSecretKey(keys, aliceKey, bobKey);

            if(result != 0)
            {
                UIManager.AddUI(PrintOption.DiffieSuccess);
                Console.WriteLine(result);
            }else{
                UIManager.AddUI(PrintOption.DiffieFail);
            }

            UIManager.AddUI(PrintOption.Separator);
            Console.ReadKey();
        }

        private static void RunGoldWasser()
        {
            var keys = GoldWasser.GetKeys();
            var text = GoldWasser.GetText();
            var aliceKey = GoldWasser.GetAliceKey(text, keys);
            var result = GoldWasser.Decryption(aliceKey);

            UIManager.AddUI(PrintOption.GoldResult);
            Console.WriteLine(result);
            UIManager.AddUI(PrintOption.Separator);
            Console.ReadKey();
        }

        private static void RunRSADigitalSign()
        {
            var keys = RSADigitalSignature.GetKeys();
            var document = RSADigitalSignature.GetDocumet();
            var signedDocument = RSADigitalSignature.SignDocument(document);
            var result = RSADigitalSignature.ValidateDocument(document, signedDocument);

            if(result)
            {
                UIManager.AddUI(PrintOption.RSASignSuccess);
                Console.WriteLine(Enum.GetName(typeof(Documents), document));
            }
            else
            {
                UIManager.AddUI(PrintOption.RSASignFailer);
            }

            UIManager.AddUI(PrintOption.Separator);
            Console.ReadKey();
        }

        private static void RunElJemalDigitalSign()
        {
            ElJemalDigitalSignature.GetKeys();
            var alicePublicKey = ElJemalDigitalSignature.GenerateAlicePublicKey();
            var document = ElJemalDigitalSignature.GetDocumet();
            var signedDocument = ElJemalDigitalSignature.SignDocument(document);
            var result = ElJemalDigitalSignature.ValidateDocument(document, signedDocument, alicePublicKey);
            if(result)
            {
                UIManager.AddUI(PrintOption.ElJemalSignSuccess);
                Console.WriteLine(Enum.GetName(typeof(Documents), document));
            }
            else
            {
                UIManager.AddUI(PrintOption.ElJemalSignFailer);
            }

            UIManager.AddUI(PrintOption.Separator);
            Console.ReadKey();
        }
    }
}
