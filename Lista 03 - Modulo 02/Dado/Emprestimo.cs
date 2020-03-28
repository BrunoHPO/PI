using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Dado
{
    public class Emprestimo : IEmprestimo
    {
        private int Id { get; set; }

        private DateTime DataEmprestimo { get; set; }

        private IPessoa Pessoa { get; set; }

        private ILivro Livro { get; set; }

        public void RealizarEmprestimo(int id, DateTime data, IPessoa pessoa, ILivro livro)
        {
            Id = id;
            DataEmprestimo = data;
            Pessoa = pessoa;
            Livro = livro;
        }

        public IEmprestimo BuscarEmprestimo(int id, List<IEmprestimo> listEmprestimo)
        {
            return listEmprestimo.Where(x => x.GetId() == id).FirstOrDefault();
        }

        public IEmprestimo BuscarLivroEmp(ILivro livro, List<IEmprestimo> listEmprestimo)
        {
            return listEmprestimo.Where(x => x.GetLivroEMP() == livro).FirstOrDefault();
        }

        public IEmprestimo BuscarPessoaEmp(IPessoa pessoa, List<IEmprestimo> listEmprestimo)
        {
            return listEmprestimo.Where(x => x.GetPessoaEMP() == pessoa).FirstOrDefault();
        }
        
        public int GetId()
        {
            return Id;
        }

        public ILivro GetLivroEMP()
        {
            return Livro;
        }
        public IPessoa GetPessoaEMP()
        {
            return Pessoa;
        }
    }
}
