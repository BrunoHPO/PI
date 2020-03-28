using System;
using System.Collections.Generic;
using Interfaces;
using System.Linq;

namespace Negocio
{
    public class Bibilioteca
    {
        public IEmprestimo Emprestar(IPessoa pessoa, ILivro livro, IEmprestimo emprestimo)
        {
            int id = 1;
            DateTime dataEmprestimo = DateTime.Now;

            emprestimo.RealizarEmprestimo(id, dataEmprestimo, pessoa, livro);

            return emprestimo;
        }

        public IPessoa BuscarPessoa(IPessoa pessoa, string cpf, List<IPessoa> listPessoa)
        {
            return pessoa.BuscarPessoa(cpf, listPessoa);
        }

        public ILivro BuscarLivro(ILivro livro, int tombo, List<ILivro> listLivro)
        {
            return livro.BuscarLivro(tombo, listLivro);
        }

        public IEmprestimo Devolver(IEmprestimo emprestimo, int id, List<IEmprestimo> listEmprestimo)
        {
            return emprestimo.BuscarEmprestimo(id, listEmprestimo);
        }

        public IEmprestimo DelLivro(IEmprestimo emprestimo,ILivro livro, List<IEmprestimo> listEmprestimo)
        {
            return emprestimo.BuscarLivroEmp(livro, listEmprestimo);
        }

        public IEmprestimo DelPessoa(IEmprestimo emprestimo, IPessoa pessoa, List<IEmprestimo> listEmprestimo)
        {
            return emprestimo.BuscarPessoaEmp(pessoa, listEmprestimo);
        }
    }
}
