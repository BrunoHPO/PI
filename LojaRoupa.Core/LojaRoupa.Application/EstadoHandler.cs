using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class EstadoHandler : IEntityCrudHandler<Estado>
    {
        private readonly ILojaDbContext db;
        public EstadoHandler(ILojaDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Alterar(int id, Estado estado, string userID)
        {
            Estado estadoToAlt = await db.Estados.SingleOrDefaultAsync(
                 i => i.ID == id
            );

            if (estadoToAlt!=null)
            {
                estadoToAlt.Nome = estado.Nome ?? estadoToAlt.Nome;
                estadoToAlt.Sigla = estado.Sigla ?? estadoToAlt.Sigla;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(Estado estado, string userID)
        {
            db.Estados.Add(estado);
            return await db.SaveChangesAsync();
        }

        public async Task<Estado[]> Listar(string userID)
        {
            return await db.Estados.ToArrayAsync();
        }

        public async Task<Estado> ObterUm(int id, string userID)
        {
            return await db.Estados.SingleOrDefaultAsync(e=>e.ID == id);
        }

        public async Task<int> Remover(int id, string userID)
        {
            Estado estadoToRemov = await db.Estados.SingleOrDefaultAsync(
                 i => i.ID == id
            );

            if (estadoToRemov != null)
            {
                db.Estados.Remove(estadoToRemov);
                return await db.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }
    }
}
