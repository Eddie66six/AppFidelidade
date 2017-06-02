using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Entidade
{
    public class Empresa
    {
        protected Empresa()
        {
            Filiais = new List<Filial>();
        }

        #region attr
        public int IdEmpresa { get; private set; }
        public List<Filial> Filiais { get; private set; }
        #endregion
    }
}
