using System.Collections.Generic;

namespace AppFidelidade.Dominio.Funcionario.ViewModel
{
    public class FuncionarioListaViewModel
    {
        public int Total { get; set; }
        public List<Entidade.Funcionario> Funcionarios { get; set; }
    }
}
