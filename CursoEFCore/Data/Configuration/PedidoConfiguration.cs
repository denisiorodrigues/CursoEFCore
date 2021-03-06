using CursoEFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.Status);
            builder.Property(p => p.TipoFrete);
            builder.Property(p => p.Observacao);
            
            builder.HasMany(p => p.Itens)
                .WithOne(p => p.Pedido)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}