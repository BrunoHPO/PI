using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class ItempedidoHandler:IEntityCrudHandler<ItemPedido>
    {
        private readonly ILojaDbContext db;
        public ItempedidoHandler(ILojaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Alterar(int id, ItemPedido itempedido, string userID)
        {
            ItemPedido itemToAlt = await db.ItemPedidos.SingleOrDefaultAsync(i => i.ID == id && i.UserID == userID);

            if (itempedido!=null)
            {                
                itemToAlt.Quantidade = itempedido.Quantidade;
                itemToAlt.Subtotal = itemToAlt.Produto.Valor * itemToAlt.Quantidade;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(ItemPedido itempedido, string userID)
        {
            itempedido.Subtotal = itempedido.Produto.Valor * itempedido.Quantidade;
            db.ItemPedidos.Add(itempedido);
            return await db.SaveChangesAsync();
        }

        public async Task<ItemPedido[]> Listar(string userID)
        {
            return await db.ItemPedidos
                .Where(i=>i.UserID==userID)
                .Include(i=>i.Produto)
                .Include(i=>i.pedido)
                .ToArrayAsync();
        }

        public async Task<ItemPedido> ObterUm(int id, string userID)
        {
            return await db.ItemPedidos
                .Include(i => i.Produto)
                .Include(i => i.pedido)
                .SingleOrDefaultAsync(i=>i.ID==id && i.UserID==userID);
        }

        public async Task<int> Remover(int id, string userID)
        {
            ItemPedido itemToRemov = await db.ItemPedidos.SingleOrDefaultAsync(i => i.ID == id && i.UserID == userID);

            if (itemToRemov!=null)
            {
                db.ItemPedidos.Remove(itemToRemov);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
