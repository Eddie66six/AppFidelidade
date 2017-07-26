using AppFidelidade.Dominio.Funcionario.Enum;

namespace AppFidelidade.Dominio.Funcionario.ViewModel
{
    public class FuncionarioBasicoViewModel
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public ETipoFuncionario Tipo { get; set; }
        public int IdFilial { get; set; }
    }
}
