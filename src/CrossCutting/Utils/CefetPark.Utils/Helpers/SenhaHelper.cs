using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Utils.Helpers
{
    public static class SenhaHelper
    {
        private const string CaracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+=<>?";

        public static string GerarSenha(int comprimento)
        {
            Random random = new Random();
            char[] senha = new char[comprimento];

            for (int i = 0; i < comprimento; i++)
            {
                senha[i] = CaracteresPermitidos[random.Next(CaracteresPermitidos.Length)];
            }

            return new string(senha);
        }
    }
}
