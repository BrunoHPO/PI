using System;
using System.Collections.Generic;
using System.Text;

namespace LojaRoupa.Core
{
    public class ItemPedido
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
        public Pedido pedido { get; set; }
        public int IdPedido { get; set; }
    }
}
