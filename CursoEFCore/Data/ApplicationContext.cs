using Microsoft.EntityFrameworkCore;
using CursoEFCore.Model;

namespace CursoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        DbSet<Produto> Produtos { get; set; }
        DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=172.27.224.1;Database=CursoEFCore;User Id=SA;Password=8uhb*UHB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}