using System;
using System.Text.RegularExpressions;

namespace AppFidelidade_App_Adm.Models.Funcionarios
{
    public class Funcionario
    {
        public Funcionario(int idFuncionarioLogado)
        {
            IdFuncionarioLogado = idFuncionarioLogado;
            Tipo = 2;
        }
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public int IdFilial { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int IdFuncionarioLogado { get; set; }
        public string Detalhes => $"Usuario: {Usuario} - Senha: { "******" }";
    }
}
