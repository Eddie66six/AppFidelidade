using AppFidelidade.Dominio.Funcionario.Enum;

namespace AppFidelidade.Dominio.Funcionario.ViewModel
{
    public class FuncionarioBasicoViewModel
    {
        public FuncionarioBasicoViewModel()
        {

        }
        public FuncionarioBasicoViewModel(Entidade.Funcionario obj)
        {
            IdFuncionario = obj.IdFuncionario;
            Nome = obj.Nome;
            Tipo = obj.Tipo;
            IdFilial = obj.IdFilial;
        }
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public ETipoFuncionario Tipo { get; set; }
        public int IdFilial { get; set; }
        public int IdFuncionarioLogado { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
