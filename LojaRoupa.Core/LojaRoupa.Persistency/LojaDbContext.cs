using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LojaRoupa.Application;
using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;

namespace LojaRoupa.Persistency
{
    public class LojaDbContext : DbContext, ILojaDbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> options)
            : base(options)
        {
        }
        #region DBSets
        public DbSet<Cliente> Clientes { get ; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TiposProduto { get; set; }
        public DbSet<Tamanho> TamanhosProduto { get; set; }
        #endregion
        public override async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return await base.SaveChangesAsync(token);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tamanho
            modelBuilder.Entity<Tamanho>().HasKey(t=> t.ID);
            modelBuilder.Entity<Tamanho>().Property(t => t.ID).ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Tamanho>().Property(t => t.Nome).IsRequired();
            modelBuilder.Entity<Tamanho>().Property(t => t.Nome).HasMaxLength(200);

            modelBuilder.Entity<Tamanho>().HasData(new Tamanho[] {
                new Tamanho(){ID=1, Nome = "PPP"},
                new Tamanho(){ID=2, Nome = "PP"},
                new Tamanho(){ID=3, Nome = "P"},
                new Tamanho(){ID=4, Nome = "M"},
                new Tamanho(){ID=5, Nome = "G"},
                new Tamanho(){ID=6, Nome = "GG"},
                new Tamanho(){ID=7, Nome = "GGG"},
                new Tamanho(){ID=8, Nome = "UNICO"}
            });
            #endregion

            #region TipoProduto
            modelBuilder.Entity<TipoProduto>().HasKey(t => t.ID);
            modelBuilder.Entity<TipoProduto>().Property(t => t.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<TipoProduto>().Property(t => t.Nome).IsRequired();
            modelBuilder.Entity<TipoProduto>().Property(t => t.Nome).HasMaxLength(200);

            modelBuilder.Entity<TipoProduto>().HasData(new TipoProduto[] {
                new TipoProduto(){ID=1, Nome="Calca"},
                new TipoProduto(){ID=2, Nome="Blusa"},
                new TipoProduto(){ID=3, Nome="Camiseta"},
                new TipoProduto(){ID=4, Nome="Bermuda"},
                new TipoProduto(){ID=5, Nome="Meia"},
                new TipoProduto(){ID=6, Nome="Cueca"},
                new TipoProduto(){ID=7, Nome="Jaqueta"},
                new TipoProduto(){ID=8, Nome="Conjunto"}
            });
            #endregion

            #region StatusPedido
            modelBuilder.Entity<StatusPedido>().HasKey(s => s.ID);
            modelBuilder.Entity<StatusPedido>().Property(s => s.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<StatusPedido>().Property(s => s.Descricao).IsRequired();
            modelBuilder.Entity<StatusPedido>().Property(s => s.Descricao).HasMaxLength(200);

            modelBuilder.Entity<StatusPedido>().HasData(new StatusPedido[] {
                new StatusPedido(){ID=1, Descricao="PAGO"},
                new StatusPedido(){ID=2, Descricao="CANCELADO"},
                new StatusPedido(){ID=3, Descricao="PENDENTE"}
            });
            #endregion

            #region Estado
            modelBuilder.Entity<Estado>().HasKey(e => e.ID);
            modelBuilder.Entity<Estado>().Property(e => e.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Estado>().Property(e => e.Nome).IsRequired();
            modelBuilder.Entity<Estado>().Property(e => e.Nome).HasMaxLength(200);

            modelBuilder.Entity<Estado>().Property(e => e.Sigla).IsRequired();
            modelBuilder.Entity<Estado>().Property(e => e.Sigla).HasMaxLength(2);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Enderecos)
                .WithOne(d => d.Estado)
                .HasForeignKey(d => d.IdEstado);

            modelBuilder.Entity<Estado>().HasData(new Estado[] {
                new Estado(){ID=1, Nome="Acre",Sigla="AC" },
                new Estado(){ID=2, Nome="Alagoas",Sigla="AL" },
                new Estado(){ID=3, Nome="Amapa",Sigla="AP" },
                new Estado(){ID=4, Nome="Amazonas",Sigla="AM" },
                new Estado(){ID=5, Nome="Bahia",Sigla="BA" },
                new Estado(){ID=6, Nome="Ceara",Sigla="CE" },
                new Estado(){ID=7, Nome="Distrito Federal",Sigla="DF" },
                new Estado(){ID=8, Nome="Espirito Santo",Sigla="ES" },
                new Estado(){ID=9, Nome="Goias",Sigla="GO" },
                new Estado(){ID=10, Nome="Maranhao",Sigla="MA" },
                new Estado(){ID=11, Nome="Mato Grosso",Sigla="MT" },
                new Estado(){ID=12, Nome="Mato GRosso do Sul",Sigla="MS" },
                new Estado(){ID=13, Nome="Minas Gerais",Sigla="MG" },
                new Estado(){ID=14, Nome="Para",Sigla="PA" },
                new Estado(){ID=15, Nome="Paraiba",Sigla="PB" },
                new Estado(){ID=16, Nome="Parana",Sigla="PR" },
                new Estado(){ID=17, Nome="Pernanbuco",Sigla="PE" },
                new Estado(){ID=18, Nome="Piaui",Sigla="PI" },
                new Estado(){ID=19, Nome="Rio de Janeiro",Sigla="RJ" },
                new Estado(){ID=20, Nome="Rio Grande do Norte",Sigla="RN" },
                new Estado(){ID=21, Nome="Rio Grande do Sul",Sigla="RS" },
                new Estado(){ID=22, Nome="Rondonia",Sigla="RO" },
                new Estado(){ID=23, Nome="Roraima",Sigla="RR" },
                new Estado(){ID=24, Nome="Santa Catarina",Sigla="SC" },
                new Estado(){ID=25, Nome="Sao Paulo",Sigla="SP" },
                new Estado(){ID=26, Nome="Sergipe",Sigla="SE" },
                new Estado(){ID=27, Nome="Tocantins",Sigla="TO" }
            });
            #endregion

            #region FormaPagamento
            modelBuilder.Entity<FormaPagamento>().HasKey(f => f.ID);
            modelBuilder.Entity<FormaPagamento>().Property(f => f.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<FormaPagamento>().Property(f => f.Nome).IsRequired();
            modelBuilder.Entity<FormaPagamento>().Property(f => f.Nome).HasMaxLength(200);

            modelBuilder.Entity<FormaPagamento>()
                .HasMany(p => p.pedidos)
                .WithOne(f => f.formaPagamento)
                .HasForeignKey(f => f.IdFormaPagamento);

            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento[] { 
                new FormaPagamento(){ID=1, Nome="Boleto" },
                new FormaPagamento(){ID=2, Nome="Cartao de Credito" },
                new FormaPagamento(){ID=3, Nome="Cartao de Debito" }
            });
            #endregion

            #region Produto
            modelBuilder.Entity<Produto>().HasKey(p => p.ID);
            modelBuilder.Entity<Produto>().Property(p => p.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Produto>().Property(p => p.Cor).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Cor).HasMaxLength(200);

            modelBuilder.Entity<Produto>().Property(p => p.Fabricante).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Fabricante).HasMaxLength(200);

            modelBuilder.Entity<Produto>().Property(p => p.Valor).IsRequired();

            modelBuilder.Entity<Produto>().Property(p => p.IdTipoProduto).IsRequired();

            modelBuilder.Entity<Produto>().Property(p => p.IdTamanho).IsRequired();
            #endregion

            #region Endereco
            modelBuilder.Entity<Endereco>().HasKey(e => e.ID);
            modelBuilder.Entity<Endereco>().Property(e => e.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Endereco>().Property(e => e.Rua).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Rua).HasMaxLength(200);

            modelBuilder.Entity<Endereco>().Property(e => e.Numero).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Numero).HasMaxLength(6);

            modelBuilder.Entity<Endereco>().Property(e => e.Bairro).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Bairro).HasMaxLength(100);

            modelBuilder.Entity<Endereco>().Property(e => e.Cidade).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Cidade).HasMaxLength(200);

            modelBuilder.Entity<Endereco>().Property(e => e.IdEstado).IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.CEP).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.CEP).HasMaxLength(8);

            modelBuilder.Entity<Endereco>().Property(e => e.Complemento).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Complemento).HasMaxLength(200);

            modelBuilder.Entity<Endereco>().Property(e => e.IdCliente).IsRequired();
            #endregion

            #region ItemPedido
            modelBuilder.Entity<ItemPedido>().HasKey(i => i.ID);
            modelBuilder.Entity<ItemPedido>().Property(i => i.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<ItemPedido>().Property(i => i.UserID).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.IdProduto).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.Quantidade).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.Subtotal).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.IdPedido).IsRequired();
            #endregion

            #region Cliente
            modelBuilder.Entity<Cliente>().HasKey(c => c.ID);
            modelBuilder.Entity<Cliente>().Property(c => c.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Cliente>().Property(c => c.UserID).IsRequired();

            modelBuilder.Entity<Cliente>().Property(c => c.Nome).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Nome).HasMaxLength(250);

            modelBuilder.Entity<Cliente>().Property(c => c.Email).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Email).HasMaxLength(120);

            modelBuilder.Entity<Cliente>().Property(c => c.Telefone).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Telefone).HasMaxLength(11);

            modelBuilder.Entity<Cliente>().Property(c => c.CPF).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.CPF).HasMaxLength(11);

            modelBuilder.Entity<Cliente>().Property(c => c.IsAtivo).IsRequired();

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Enderecos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.IdCliente);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Pedidos)
                .WithOne(p => p.cliente)
                .HasForeignKey(p => p.IdCliente);
            #endregion

            #region Pedido
            modelBuilder.Entity<Pedido>().HasKey(p => p.ID);
            modelBuilder.Entity<Pedido>().Property(p => p.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Pedido>().Property(p => p.DataPedido).IsRequired();

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Items)
                .WithOne(o => o.pedido)
                .HasForeignKey(o => o.IdPedido);


            modelBuilder.Entity<Pedido>().Property(p => p.IdCliente).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.IdEnderecoEntrega).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.IdStatusPedido).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.IdFormaPagamento).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.PercDesconto).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.Total).IsRequired();
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
