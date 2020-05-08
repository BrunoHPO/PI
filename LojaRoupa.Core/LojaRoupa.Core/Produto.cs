using System;
using System.Collections.Generic;
using System.Text;

namespace LojaRoupa.Core
{
    public class Produto
    {
        public int ID { get; set; }
        public TipoProduto Tipo { get; set; }
        public int IdTipoProduto { get; set; }
        public string Cor { get; set; }
        public Tamanho Tamanho { get; set; }
        public int IdTamanho { get; set; }
        public string Fabricante { get; set; }
        public decimal Valor { get; set; }
    }        
}
