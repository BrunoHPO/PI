using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Dado
{
    public class Livro : ILivro
    {
        private int Numero { get; set; }
        private string Titulo { get; set; }
        private string Autor { get; set; }

        public Livro()
        { 
        //null
        }
        public Livro(int numero,string titulo, string autor)
        {
            Numero = numero;
            Titulo = titulo;
            Autor = autor;
        }

        public string ImprimirLivro()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"     Codigo: {Numero} / Livro: {Titulo} / Autor: {Autor}");
            return stringBuilder.ToString();
        }
        public ILivro BuscarLivro(int Numero, List<ILivro> listLivro)
        {
            return listLivro.Where(x => x.GetCod() == Numero).FirstOrDefault();
        }
        public int GetCod()
        {
            return Numero;
        }
    }
}
