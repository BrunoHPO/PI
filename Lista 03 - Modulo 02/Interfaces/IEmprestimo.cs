using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEmprestimo
    {
        void RealizarEmprestimo(int id, DateTime dataEmprestimo, IPessoa p, ILivro l);

        public int GetId();

        IEmprestimo BuscarEmprestimo(int id, List<IEmprestimo> listEmprestimo);

        public IEmprestimo BuscarLivroEmp(ILivro livro, List<IEmprestimo> listEmprestimo);

        public IEmprestimo BuscarPessoaEmp(IPessoa pessoa, List<IEmprestimo> listEmprestimo);

        public ILivro GetLivroEMP();

        public IPessoa GetPessoaEMP();
    }
}
