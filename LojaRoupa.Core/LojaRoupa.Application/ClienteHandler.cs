using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class ClienteHandler:IEntityCrudHandler<Cliente>
    {
        private readonly ILojaDbContext db;
        public ClienteHandler(ILojaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Alterar(int id, Cliente cliente, string userID)
        {
            Cliente clienteToAlt = await db.Clientes.SingleOrDefaultAsync(c=>c.ID==id && c.UserID==userID);

            if (clienteToAlt!=null)
            {
                clienteToAlt.Nome = cliente.Nome ?? clienteToAlt.Nome;
                clienteToAlt.Email = cliente.Email ?? clienteToAlt.Email;
                clienteToAlt.Telefone = cliente.Telefone ?? clienteToAlt.Telefone;
                clienteToAlt.CPF = cliente.CPF ?? clienteToAlt.CPF;
                return await db.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }

        public async Task<int> Inserir(Cliente cliente, string userID)
        {
            cliente.IsAtivo = true;
            db.Clientes.Add(cliente);
            return await db.SaveChangesAsync();
        }

        public async Task<Cliente[]> Listar(string userID)
        {
            return await db.Clientes
                .Where(c=>c.IsAtivo==true)
                .Include(c=>c.Enderecos)
                .Include(c=>c.Pedidos)
                .ToArrayAsync();
        }

        public async Task<Cliente> ObterUm(int id, string userID)
        {
            return await db.Clientes                
                .Include(c=>c.Enderecos)
                .Include(c=>c.Pedidos)
                .SingleOrDefaultAsync(c=>c.ID==id && c.IsAtivo == true);
        }

        public async Task<int> Remover(int id, string userID)
        {
            Cliente ClienteToRemov = await db.Clientes.SingleOrDefaultAsync(c=>c.ID==id && c.IsAtivo == true);

            if (ClienteToRemov!= null)
            {
                ClienteToRemov.IsAtivo = false;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
