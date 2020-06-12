using System;
using System.Threading.Tasks;

namespace WhattaMovie.Application
{
    public interface IEntityCrudHandler<T>
    {
        Task<int> Inserir(T entity);

        Task<int> Alterar(int id, T entity, int userID);

        Task<int> Remover(int id, int userID);

        Task<T[]> Listar(int userID);

        Task<T> ObterUm(int id, int userID);
    }
}
