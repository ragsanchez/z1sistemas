using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TesteLab.Models
{
    public partial class TesteLabContext : DbContext
    {
        public TesteLabContext()
        {
        }

        public TesteLabContext(DbContextOptions<TesteLabContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemPedido> ItemPedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-PB484ON1\\SQLEXPRESS;Database=TesteLab;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedido>(entity =>
            {
                entity.ToTable("ItemPedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataEntrega)
                    .HasColumnType("date")
                    .HasColumnName("dataEntrega");

                entity.Property(e => e.Idpedido).HasColumnName("idpedido");

                entity.Property(e => e.NomeProduto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomeProduto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorUnitario");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.ItemPedidos)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemPedid__idped__164452B1");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DtPedido)
                    .HasColumnType("datetime")
                    .HasColumnName("dtPedido")
                    .HasComputedColumnSql("(getdate())", false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .HasColumnName("usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
