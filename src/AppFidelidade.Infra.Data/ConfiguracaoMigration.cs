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
            var filial = empresa.CriarFilial(new Filial("12123", "G2x unidade1", "eddie G2x"));
            var funcionario = filial.AdicionarFuncionario(new Funcionario("Guilherme funcionario"));
            var regra = filial.AdicionarRegra(new Regra(Dominio.Administracao.Enum.ETipoDesconto.Dinheiro, 0, 10, 1, filial, funcionario));
            var cliente = new Cliente("Guilherme cliente");
            var compra = filial.InserirCompra(new Compra(10, filial, funcionario, cliente));
            contexto.Empresa.Add(empresa);
            contexto.SaveChanges();
        }
    }
}
