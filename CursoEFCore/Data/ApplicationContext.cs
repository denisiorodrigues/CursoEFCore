using Microsoft.EntityFrameworkCore;
using CursoEFCore.Model;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;

namespace CursoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        //Adicionando log na aplicação
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<Chamado> Chamados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(_logger)
            .EnableSensitiveDataLogging()
            .UseSqlServer("Server=localhost;Database=CursoEFCore;User Id=SA;Password=8uhb*UHB", 
            p => p.EnableRetryOnFailure(
                maxRetryCount: 2, // Configuração máxima de tentativa de reconexão
                maxRetryDelay: TimeSpan.FromSeconds(5), // enquanto tempo deve esperar para tentar novamente
                errorNumbersToAdd: null // Códigos de erros adicionais para o entity framework pode interpretar
            ));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        protected void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if(string.IsNullOrEmpty(property.GetColumnType())
                        && !property.GetMaxLength().HasValue)
                        {
                            property.SetColumnType("VARCHAR(100)");
                        }
                }
            }
        }
    }
}