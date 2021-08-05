using CursoEFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Data.Configuration
{
    public class ChamadoConfiguration : IEntityTypeConfiguration<Chamado>
    {
        void IEntityTypeConfiguration<Chamado>.Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder.ToTable("Chamados");

            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Horario).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        }
    }
}