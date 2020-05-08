using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class FormapagHandler : IEntityCrudHandler<FormaPagamento>
    {
        private readonly ILojaDbContext db;
        public FormapagHandler(ILojaDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Alterar(int id, FormaPagamento forma, string userID)
        {
            FormaPagamento FormaToAlt = await db.FormasPagamento.SingleOrDefaultAsync(t=>t.ID==id);

            if (FormaToAlt!=null)
            {
                FormaToAlt.Nome = forma.Nome ?? FormaToAlt.Nome;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(FormaPagamento forma, string userID)
        {
            db.FormasPagamento.Add(forma);
            return await db.SaveChangesAsync();
        }

        public async Task<FormaPagamento[]> Listar(string userID)
        {
            return await db.FormasPagamento.ToArrayAsync();
        }

        public async Task<FormaPagamento> ObterUm(int id, string userID)
        {
            return await db.FormasPagamento.SingleOrDefaultAsync(t=> t.ID==id);
        }

        public async Task<int> Remover(int id, string userID)
        {
            FormaPagamento formaToRemov = await db.FormasPagamento.SingleOrDefaultAsync(t=>t.ID==id);

            if (formaToRemov!=null)
            {
                db.FormasPagamento.Remove(formaToRemov);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
