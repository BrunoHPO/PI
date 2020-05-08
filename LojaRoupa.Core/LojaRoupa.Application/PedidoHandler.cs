using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class PedidoHandler:IEntityCrudHandler<Pedido>
    {
        private readonly ILojaDbContext db;
        public PedidoHandler(ILojaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Alterar(int id, Pedido pedido, string userID)
        {
            Pedido pedidoToAlt = await db.Pedidos.SingleOrDefaultAsync((p => p.ID == id && p.IdCliente == userID));

            if (pedidoToAlt != null)
            {
                var NovosItens = pedido.Items;
                var itens = pedidoToAlt.Items;

                ItempedidoHandler itemHandler = new ItempedidoHandler(db);

                foreach (var velho in itens)
                {
                    if (NovosItens.SingleOrDefault(i => i.IdProduto == velho.IdProduto) == null)
                    {
                        await itemHandler.Remover(velho.IdProduto, userID);
                    }
                }
                foreach (var novo in NovosItens)
                {
                    if (itens.SingleOrDefault(i=>i.IdProduto==novo.IdProduto)!=null)
                    {
                        await itemHandler.Alterar(novo.IdProduto, novo, userID);
                    }
                    else
                    {
                        await itemHandler.Inserir(novo,userID);
                    }
                }

                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(Pedido pedido, string userID)
        {
            pedido.Total = pedido.Items.Sum(i => i.Subtotal);
            db.Pedidos.Add(pedido);
            return await db.SaveChangesAsync();
        }

        public async Task<Pedido[]> Listar(string userID)
        {
            return await db.Pedidos
                .Where(p=>p.IdCliente==userID)
                .Include(p=>p.Items)
                .Include(p=>p.EnderecoEntrega)
                .Include(p=>p.Status)
                .Include(p=>p.formaPagamento)
                .ToArrayAsync();
        }

        public async Task<Pedido> ObterUm(int id, string userID)
        {
            return await db.Pedidos                
                .Include(p => p.Items)
                .Include(p => p.EnderecoEntrega)
                .Include(p => p.Status)
                .Include(p => p.formaPagamento)
                .SingleOrDefaultAsync(p =>p.ID==id && p.IdCliente==userID) ;
        }

        public async Task<int> Remover(int id, string userID)
        {
            Pedido pedidoToRemov = await db.Pedidos.SingleOrDefaultAsync(p => p.ID == id && p.IdCliente == userID);

            if (pedidoToRemov!=null)
            {
                db.Pedidos.Remove(pedidoToRemov);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
