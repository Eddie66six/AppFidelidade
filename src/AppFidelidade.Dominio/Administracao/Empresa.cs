using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao
{
    public class Empresa
    {
        protected Empresa()
        {
            Filiais = new List<Filial>();
        }

        #region attr
        public int IdEmpresa { get; set; }
        public List<Filial> Filiais { get; set; }
        #endregion
    }
}
