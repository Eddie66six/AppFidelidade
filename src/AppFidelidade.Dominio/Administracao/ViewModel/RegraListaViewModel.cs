using AppFidelidade.Dominio.Administracao.Entidade;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.ViewModel
{
    public class RegraListaViewModel
    {
        public int Total { get; set; }
        public List<RegraBasicoViewModel> Regras { get; set; }
    }
}
