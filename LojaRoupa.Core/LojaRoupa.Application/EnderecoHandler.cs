using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class EnderecoHandler : IEntityCrudHandler<Endereco>
    {
        private readonly ILojaDbContext db;
        public EnderecoHandler(ILojaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Inserir(Endereco endereco, string userID)
        {
            db.Enderecos.Add(endereco);
            return await db.SaveChangesAsync();
        }

        public async Task<Endereco[]> Listar(string userID)
        {
            return await db.Enderecos
                .Where(e=>e.IdCliente==userID)
                .Include(e=>e.estado)
                .ToArrayAsync();
        }

        public async Task<Endereco> ObterUm(int id, string userID)
        {
            return await db.Enderecos
                .Include(e=>e.estado)
                .SingleOrDefaultAsync(e=>e.ID==id && e.IdCliente==userID);
        }

        public async Task<int> Alterar(int id, Endereco endereco, string userID)
        {
            Endereco EnderecoToAlt = await db.Enderecos.SingleOrDefaultAsync(
                e=>e.ID ==id && e.IdCliente==userID
                );

            if (EnderecoToAlt!=null)
            {
                EnderecoToAlt.Rua = endereco.Rua ?? EnderecoToAlt.Rua;
                EnderecoToAlt.Numero = endereco.Numero ?? EnderecoToAlt.Numero;
                EnderecoToAlt.Bairro = endereco.Bairro ?? EnderecoToAlt.Bairro;                
                EnderecoToAlt.Cidade = endereco.Cidade ?? EnderecoToAlt.Cidade;
                EnderecoToAlt.estado = endereco.estado ?? EnderecoToAlt.estado;               
                EnderecoToAlt.CEP = endereco.CEP ?? EnderecoToAlt.CEP;
                EnderecoToAlt.Complemento = endereco.Complemento ?? EnderecoToAlt.Complemento;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
        
        public async Task<int> Remover(int id, string userID)
        {
            Endereco EnderecoToRemov = await db.Enderecos.SingleOrDefaultAsync(
                e=>e.ID ==id && e.IdCliente==userID
                );

            if (EnderecoToRemov != null)
            {
                db.Enderecos.Remove(EnderecoToRemov);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
