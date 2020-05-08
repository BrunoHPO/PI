using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class TipoProdHandler : IEntityCrudHandler<TipoProduto>
    {
        private readonly ILojaDbContext db;
        public TipoProdHandler(ILojaDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Alterar(int id, TipoProduto Tipo, string userID)
        {
            TipoProduto tipoToAlt = await db.TiposProduto.SingleOrDefaultAsync(t=>t.ID==id);

            if (tipoToAlt!=null)
            {
                tipoToAlt.Nome = Tipo.Nome ?? tipoToAlt.Nome;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(TipoProduto Tipo, string userID)
        {
            db.TiposProduto.Add(Tipo);
            return await db.SaveChangesAsync();
        }

        public async Task<TipoProduto[]> Listar(string userID)
        {
            return await db.TiposProduto.ToArrayAsync();
        }

        public async Task<TipoProduto> ObterUm(int id, string userID)
        {
            return await db.TiposProduto.SingleOrDefaultAsync(t=> t.ID==id);
        }

        public async Task<int> Remover(int id, string userID)
        {
            TipoProduto tipoToRemov = await db.TiposProduto.SingleOrDefaultAsync(t=>t.ID==id);

            if (tipoToRemov!=null)
            {
                db.TiposProduto.Remove(tipoToRemov);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
