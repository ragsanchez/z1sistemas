using Microsoft.EntityFrameworkCore;
using TesteCliente.Dominio;

namespace TesteCliente.Repositorio.FonteDeDados
{
    public class PersisteContext : DbContext
    {
        public PersisteContext()
        { }

        public PersisteContext(DbContextOptions<PersisteContext> opcoes)
            : base(opcoes)
        { }

        public DbSet<Cliente> Clientes { get; set; }

        private void ConfiguraCliente(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Cliente>(etd =>
            {
                etd.ToTable("tbCliente");
                etd.HasKey(c => c.Id).HasName("id");
                etd.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
                etd.Property(c => c.Nome).HasColumnName("nome").HasMaxLength(100);
                etd.Property(c => c.Idade).HasColumnName("idade");
            });
        }

        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Cliente>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });


            construtorDeModelos.HasDefaultSchema("TesteCliente");

            ConfiguraCliente(construtorDeModelos);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=LAPTOP-PB484ON1\SQLEXPRESS;Initial Catalog=TesteCliente;Integrated Security=True");
    }
}
