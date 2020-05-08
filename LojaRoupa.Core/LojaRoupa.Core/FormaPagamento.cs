using System;
using System.Collections.Generic;
using System.Text;

namespace LojaRoupa.Core
{
    public class FormaPagamento
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public ICollection<Pedido> pedidos { get; set; }
    }
}
