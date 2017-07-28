using AppFidelidade.Dominio.Administracao.Entidade;

namespace AppFidelidade.Dominio.Administracao.ViewModel
{
    public class RegraBasicoViewModel
    {
        public RegraBasicoViewModel()
        {

        }
        public RegraBasicoViewModel(Regra obj)
        {
            IdRegra = obj.IdRegra;
            Nome = obj.Nome;
            TipoDesconto = obj.TipoDesconto;
            ValorDaRegra = obj.ValorDaRegra;
            ValorAcimaDe = obj.ValorAcimaDe;
            Inativo = obj.Inativo;
        }
        public int IdRegra { get; set; }
        public string Nome { get; set; }
        public Enum.ETipoDesconto TipoDesconto { get; set; }
        public decimal ValorDaRegra { get; set; }
        public decimal ValorAcimaDe { get; set; }
        public bool Inativo { get; set; }
        public int IdFuncionarioLogado { get; set; }
    }
}
