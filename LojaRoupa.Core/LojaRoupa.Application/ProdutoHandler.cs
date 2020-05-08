using LojaRoupa.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public class ProdutoHandler:IEntityCrudHandler<Produto>
    {
        private readonly ILojaDbContext db;
        public ProdutoHandler(ILojaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Alterar(int id, Produto produto, string userID)
        {
            Produto produtoToAlt = await db.Produtos.SingleOrDefaultAsync(p => p.ID == id);

            if (produtoToAlt!=null)
            {
                produtoToAlt.Tipo = produto.Tipo??produtoToAlt.Tipo;
                produtoToAlt.Cor = produto.Cor ?? produtoToAlt.Cor;
                produtoToAlt.Tamanho = produto.Tamanho ?? produtoToAlt.Tamanho;
                produtoToAlt.Fabricante = produto.Fabricante ?? produtoToAlt.Fabricante;
                produtoToAlt.Valor = produto.Valor;
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0); ;
        }

        public async Task<int> Inserir(Produto produto, string userID)
        {
            db.Produtos.Add(produto);
            return await db.SaveChangesAsync();
        }

        public async Task<Produto[]> Listar(string userID)
        {
            return await db.Produtos
                .Include(p=>p.Tipo)
                .Include(p=>p.Tamanho)
                .ToArrayAsync();
        }

        public async Task<Produto> ObterUm(int id, string userID)
        {
            return await db.Produtos
                .Include(p => p.Tipo)
                .Include(p => p.Tamanho)
                .SingleOrDefaultAsync(p=>p.ID==id) ;
        }

        public async Task<int> Remover(int id, string userID)
        {
            Produto produtoToRemov = await db.Produtos.SingleOrDefaultAsync(p=>p.ID==id);

            if (produtoToRemov!=null)
            {
                db.Produtos.Remove(produtoToRemov);
                return await db.SaveChangesAsync();
            }

            return await Task.FromResult(0);
        }
    }
}
