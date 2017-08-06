using AppFidelidade_App_Client.Models;
using System;

namespace AppFidelidade_App_Client
{
    public static class Data
    {
        public static DateTime DataUltimoLogin;
        private static ClienteBasico Cliente { get; set; }
        public static void SalvarCliente(ClienteBasico cliente)
        {
            Cliente = cliente;
            DataUltimoLogin = DateTime.Now;
        }

        public static string ObterQrCode()
        {
            return Cliente.TokenId;
        }
        public static bool ExisteCliente()
        {
            return Cliente != null;
        }

        public static ClienteBasico ObterDadosCliente()
        {
            return Cliente;
        }
    }
}
