using System.Collections.Generic;

namespace AppFidelidade.Dominio.Funcionario.ViewModel
{
    public class FuncionarioListaViewModel
    {
        public int Total { get; set; }
        public List<FuncionarioBasicoViewModel> Funcionarios { get; set; }
    }
}
