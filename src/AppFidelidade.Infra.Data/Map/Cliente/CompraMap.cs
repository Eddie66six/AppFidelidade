using System.Data.Entity.ModelConfiguration;

namespace AppFidelidade.Infra.Data.Map.Cliente
{
    class CompraMap : EntityTypeConfiguration<Dominio.Cliente.Compra>
    {
        public CompraMap()
        {
            HasRequired(p => p.Filial)
                .WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdFilial);
            HasRequired(p => p.Funcionario)
                .WithMany(p => p.Vendas)
                .HasForeignKey(p => p.IdFuncionario);
            HasRequired(p => p.Cliente)
                .WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdCliente);
            HasRequired(p => p.Carteira)
                .WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdCarteira);
        }
    }
}
