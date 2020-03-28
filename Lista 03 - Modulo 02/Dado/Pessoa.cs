using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Dado
{
    public class Pessoa : IPessoa
    {
        private string CPF { get; set; }
        private string Nome { get; set; }
        private string Email { get; set; }

        public Pessoa()
        { 
        //null
        }
        public Pessoa(string cpf, string nome, string email)
        {
            CPF = cpf;
            Nome = nome;
            Email = email;
        }

        public IPessoa BuscarPessoa(string cpf, List<IPessoa> listPessoa)
        {
            return listPessoa.Where(x => x.GetCpf() == cpf).FirstOrDefault();
        }

        public string GetCpf()
        {
            return CPF;
        }

        public string ImprimirPessoa()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"     CPF: {CPF} / Nome: {Nome} / E-mail: {Email}");
            return stringBuilder.ToString();
        }
    }
}
