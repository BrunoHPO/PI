using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class TamanhoHandler : IEntityCrudHandler<Tamanho>
    {
        private readonly ILojaDbContext db;
        public TamanhoHandler(ILojaDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Alterar(int id, Tamanho tamanho, string userID)
        {
            Tamanho tamanhoToAlt = await db.TamanhosProduto.SingleOrDefaultAsync(t=>t.ID==id);

            if (tamanhoToAlt!=null)
            {
                tamanhoToAlt.Nome = tamanho.Nome ?? tamanhoToAlt.Nome;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(Tamanho tamanho, string userID)
        {
            db.TamanhosProduto.Add(tamanho);
            return await db.SaveChangesAsync();
        }

        public async Task<Tamanho[]> Listar(string userID)
        {
            return await db.TamanhosProduto.ToArrayAsync();
        }

        public async Task<Tamanho> ObterUm(int id, string userID)
        {
            return await db.TamanhosProduto.SingleOrDefaultAsync(t=> t.ID==id);
        }

        public async Task<int> Remover(int id, string userID)
        {
            Tamanho tamanhoToRemov = await db.TamanhosProduto.SingleOrDefaultAsync(t=>t.ID==id);

            if (tamanhoToRemov!=null)
            {
                db.TamanhosProduto.Remove(tamanhoToRemov);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
