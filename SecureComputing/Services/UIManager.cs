using System;
using System.Collections.Generic;
using System.Text;
using SecureComputing.Enums;
using SecureComputing.UI;

namespace SecureComputing.Services
{
    static class UIManager
    {
        public static void AddUI(PrintOption option)
        {
            switch(option)
            {
                case PrintOption.MainMenu: Print(Menu.mainMenu);
                    break;
                case PrintOption.GetElJemalPrime: Print(Menu.ElJemal.getPrime);
                    break;
                case PrintOption.GetElJemalText: Print(Menu.ElJemal.getText);
                    break;
                case PrintOption.ElJemalResult: Print(Menu.ElJemal.result);
                    break;
                case PrintOption.Separator: Print(Menu.Separator);
                    break;
                case PrintOption.GetRSAPrime: Print(Menu.RSA.getPrime);
                    break;
                case PrintOption.GetRSAText: Print(Menu.RSA.getText);
                    break;
                case PrintOption.RSAResult: Print(Menu.RSA.result);
                    break;
                case PrintOption.GetMillerKeys: Print(Menu.MillerRabin.getKeys);
                    break;
                case PrintOption.MillerFail: Print(Menu.MillerRabin.failed);
                    break;
                case PrintOption.MillerSuccess: Print(Menu.MillerRabin.success);
                    break;
                case PrintOption.GetDiffieKeys: Print(Menu.DiffeHellMan.getKeys);
                    break;
                case PrintOption.DiffieFail: Print(Menu.DiffeHellMan.failed);
                    break;
                case PrintOption.DiffieSuccess: Print(Menu.DiffeHellMan.success);
                    break;
                case PrintOption.GetGoldKeys: Print(Menu.GoldWasser.getKeys);
                    break;
                case PrintOption.GetGoldText: Print(Menu.GoldWasser.getText);
                    break;
                case PrintOption.GoldResult: Print(Menu.GoldWasser.result);
                    break;
                case PrintOption.GetRSASignPrime: Print(Menu.RSADigitalSignature.getPrime);
                    break;
                case PrintOption.GetRSASignDoc: Print(Menu.RSADigitalSignature.getDocument);
                    break;
                case PrintOption.RSASignSuccess: Print(Menu.RSADigitalSignature.Success);
                    break;
                case PrintOption.RSASignFailer: Print(Menu.RSADigitalSignature.Failer);
                    break;
                case PrintOption.GetElJemalSignPrime: Print(Menu.ElJemalDigitalSignature.getPrime);
                    break;
                case PrintOption.GetElJemalSignDoc: Print(Menu.ElJemalDigitalSignature.getDocument);
                    break;
                case PrintOption.ElJemalSignSuccess: Print(Menu.ElJemalDigitalSignature.Success);
                    break;
                case PrintOption.ElJemalSignFailer: Print(Menu.ElJemalDigitalSignature.Failer);
                    break;
            }
        }



        private static void Print(string option)
        {
            Console.WriteLine(option);
        }
    }
}
