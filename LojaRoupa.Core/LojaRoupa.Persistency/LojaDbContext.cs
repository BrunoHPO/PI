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
        public override async Task<int> SaveChangesAsync(CancellationToken token)
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
                new Tamanho(){Nome = "PPP"},
                new Tamanho(){Nome = "PP"},
                new Tamanho(){Nome = "P"},
                new Tamanho(){Nome = "M"},
                new Tamanho(){Nome = "G"},
                new Tamanho(){Nome = "GG"},
                new Tamanho(){Nome = "GGG"},
                new Tamanho(){Nome = "UNICO"}
            });
            #endregion

            #region TipoProduto
            modelBuilder.Entity<TipoProduto>().HasKey(t => t.ID);
            modelBuilder.Entity<TipoProduto>().Property(t => t.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<TipoProduto>().Property(t => t.Nome).IsRequired();
            modelBuilder.Entity<TipoProduto>().Property(t => t.Nome).HasMaxLength(200);

            modelBuilder.Entity<TipoProduto>().HasData(new TipoProduto[] {
                new TipoProduto(){Nome="Calca"},
                new TipoProduto(){Nome="Blusa"},
                new TipoProduto(){Nome="Camiseta"},
                new TipoProduto(){Nome="Bermuda"},
                new TipoProduto(){Nome="Meia"},
                new TipoProduto(){Nome="Cueca"},
                new TipoProduto(){Nome="Jaqueta"},
                new TipoProduto(){Nome="Conjunto"}
            });
            #endregion

            #region StatusPedido
            modelBuilder.Entity<StatusPedido>().HasKey(s => s.ID);
            modelBuilder.Entity<StatusPedido>().Property(s => s.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<StatusPedido>().Property(s => s.Descricao).IsRequired();
            modelBuilder.Entity<StatusPedido>().Property(s => s.Descricao).HasMaxLength(200);

            modelBuilder.Entity<StatusPedido>().HasData(new StatusPedido[] {
                new StatusPedido(){Descricao="PAGO"},
                new StatusPedido(){Descricao="CANCELADO"},
                new StatusPedido(){Descricao="PENDENTE"}
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
                .WithOne(d => d.estado)
                .HasForeignKey(d => d.IdEstado);

            modelBuilder.Entity<Estado>().HasData(new Estado[] {
                new Estado(){Nome="Acre",Sigla="AC" },
                new Estado(){Nome="Alagoas",Sigla="AL" },
                new Estado(){Nome="Amapa",Sigla="AP" },
                new Estado(){Nome="Amazonas",Sigla="AM" },
                new Estado(){Nome="Bahia",Sigla="BA" },
                new Estado(){Nome="Ceara",Sigla="CE" },
                new Estado(){Nome="Distrito Federal",Sigla="DF" },
                new Estado(){Nome="Espirito Santo",Sigla="ES" },
                new Estado(){Nome="Goias",Sigla="GO" },
                new Estado(){Nome="Maranhao",Sigla="MA" },
                new Estado(){Nome="Mato Grosso",Sigla="MT" },
                new Estado(){Nome="Mato GRosso do Sul",Sigla="MS" },
                new Estado(){Nome="Minas Gerais",Sigla="MG" },
                new Estado(){Nome="Para",Sigla="PA" },
                new Estado(){Nome="Paraiba",Sigla="PB" },
                new Estado(){Nome="Parana",Sigla="PR" },
                new Estado(){Nome="Pernanbuco",Sigla="PE" },
                new Estado(){Nome="Piaui",Sigla="PI" },
                new Estado(){Nome="Rio de Janeiro",Sigla="RJ" },
                new Estado(){Nome="Rio Grande do Norte",Sigla="RN" },
                new Estado(){Nome="Rio Grande do Sul",Sigla="RS" },
                new Estado(){Nome="Rondonia",Sigla="RO" },
                new Estado(){Nome="Roraima",Sigla="RR" },
                new Estado(){Nome="Santa Catarina",Sigla="SC" },
                new Estado(){Nome="Sao Paulo",Sigla="SP" },
                new Estado(){Nome="Sergipe",Sigla="SE" },
                new Estado(){Nome="Tocantins",Sigla="TO" }
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
                new FormaPagamento(){Nome="Boleto" },
                new FormaPagamento(){Nome="Cartao de Credito" },
                new FormaPagamento(){Nome="Cartao de Debito" }
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

            modelBuilder.Entity<Produto>().Property(p => p.Tipo).IsRequired();

            modelBuilder.Entity<Produto>().Property(p => p.IdTipoProduto).IsRequired();

            modelBuilder.Entity<Produto>().Property(p => p.Tamanho).IsRequired();

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

            modelBuilder.Entity<Endereco>().Property(e => e.estado).IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.IdEstado).IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.CEP).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.CEP).HasMaxLength(8);

            modelBuilder.Entity<Endereco>().Property(e => e.Complemento).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Complemento).HasMaxLength(200);

            modelBuilder.Entity<Endereco>().Property(e => e.cliente).IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.IdCliente).IsRequired();
            #endregion

            #region ItemPedido
            modelBuilder.Entity<ItemPedido>().HasKey(i => i.ID);
            modelBuilder.Entity<ItemPedido>().Property(i => i.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<ItemPedido>().Property(i => i.UserID).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.Produto).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.IdProduto).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.Quantidade).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.Subtotal).IsRequired();

            modelBuilder.Entity<ItemPedido>().Property(i => i.pedido).IsRequired();

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
                .WithOne(p => p.cliente)
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

            modelBuilder.Entity<Pedido>().Property(p => p.cliente).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.IdCliente).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.EnderecoEntrega).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.IdEnderecoEntrega).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.Status).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.IdStatusPedido).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.formaPagamento).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.IdFormaPagamento).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.PercDesconto).IsRequired();

            modelBuilder.Entity<Pedido>().Property(p => p.Total).IsRequired();
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
