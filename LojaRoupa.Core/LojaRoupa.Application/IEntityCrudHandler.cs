using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.Application
{
    public interface IEntityCrudHandler<T>
    {
        Task<int> Inserir(T entity, string userID);
        Task<T[]> Listar(string userID);
        Task<T> ObterUm(int id, string userID);      
        Task<int> Alterar(int id, T entity, string userID);
        Task<int> Remover(int id, string userID);
    }
}
