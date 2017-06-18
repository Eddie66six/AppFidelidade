namespace AppFidelidade.Dominio._Comum.Entidade
{
    public class Endereco
    {
        protected Endereco()
        {

        }
        public Endereco(string cep, string rua, string numero, string bairro, string cidade)
        {
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
        }

        #region Attr
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        #endregion
    }
}
