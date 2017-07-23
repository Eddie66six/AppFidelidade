using AppFidelidade.Dominio.Funcionario.Enum;

namespace AppFidelidade.Dominio._Comum.ViewModel
{
    public class FuncionarioLoginViewModel
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public ETipoFuncionario Tipo { get; set; }
    }
}
