using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class StatusPHandler : IEntityCrudHandler<StatusPedido>
    {
        private readonly ILojaDbContext db;
        public StatusPHandler(ILojaDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Alterar(int id, StatusPedido status, string userID)
        {
            StatusPedido statusPedidoToAlt = await db.StatusPedidos.SingleOrDefaultAsync(s=>s.ID==id);

            if (statusPedidoToAlt!=null)
            {
                statusPedidoToAlt.Descricao = status.Descricao ?? statusPedidoToAlt.Descricao;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(StatusPedido status, string userID)
        {
            db.StatusPedidos.Add(status);
            return await db.SaveChangesAsync();
        }

        public async Task<StatusPedido[]> Listar(string userID)
        {
            return await db.StatusPedidos.ToArrayAsync();
        }

        public async Task<StatusPedido> ObterUm(int id, string userID)
        {
            return await db.StatusPedidos.SingleOrDefaultAsync(s=>s.ID==id);
        }

        public async Task<int> Remover(int id, string userID)
        {
            StatusPedido statusPedidoToRemov = await db.StatusPedidos.SingleOrDefaultAsync(s=>s.ID==id);

            if (statusPedidoToRemov!= null)
            {
                db.StatusPedidos.Remove(statusPedidoToRemov);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
