namespace AppFidelidade.Dominio.Administracao
{
    public class Regra
    {
        protected Regra()
        {

        }

        #region attr
        public int IdRegra { get; set; }
        public int IdFilial { get; set; }
        public virtual Filial Filial { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario.Funcionario FuncionarioCadastro { get; set; }
        #endregion
    }
}
