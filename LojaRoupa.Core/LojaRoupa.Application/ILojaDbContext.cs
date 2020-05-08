using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public interface ILojaDbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }            
        public DbSet<TipoProduto> TiposProduto { get; set; }
        public DbSet<Tamanho> TamanhosProduto { get; set; }
        
        public Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
