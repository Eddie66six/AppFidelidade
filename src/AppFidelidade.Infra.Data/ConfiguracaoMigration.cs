using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Cliente.Entidade;
using AppFidelidade.Dominio.Funcionario.Entidade;
using System.Data.Entity.Migrations;

namespace AppFidelidade.Infra.Data
{
    public class ConfiguracaoMigration : DbMigrationsConfiguration<Contexto>
    {
        public ConfiguracaoMigration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto contexto)
        {
            var empresa = new Empresa("G2x");
            var filial = empresa.CriarFilial(new Filial("12123", "G2x unidade1", "eddie G2x",0));
            var funcionario = filial.AdicionarFuncionario(new Funcionario("Guilherme funcionario"));
            var regra = filial.AdicionarRegra(new Regra(Dominio.Administracao.Enum.ETipoDesconto.Dinheiro, 0, 10, 5, filial, funcionario));
            var cliente = new Cliente("Guilherme cliente", "Rodrigues",
                new System.DateTime(1991,05,23), new Dominio._Comum.Entidade.Endereco("18052601","Emiliano Ramos","399","Quintais do imperadro","Sorocaba"));
            //compra que pode ganhar credito
            var compra = filial.InserirCompra(new Compra(10, filial, funcionario, cliente, null));
            //compartilhou
            compra.Creditar(cliente);
            //compra utilizando credito
            if(cliente.ObterCreditoNaFilial(filial) >= 5)
                filial.InserirCompra(new Compra(30, filial, funcionario, cliente, 5));
            contexto.Empresa.Add(empresa);
            contexto.SaveChanges();
        }
    }
}
