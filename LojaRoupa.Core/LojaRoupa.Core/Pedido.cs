using System;
using System.Collections.Generic;
using System.Text;

namespace LojaRoupa.Core
{
    public class Pedido
    {
        public int ID { get; set; }
        public DateTime DataPedido { get; set; }
        public ICollection<ItemPedido> Items { get; set; }
        public Cliente cliente { get; set; }
        public string IdCliente { get; set; }
        public Endereco EnderecoEntrega { get; set; }
        public int IdEnderecoEntrega { get; set; }
        public StatusPedido Status { get; set; }
        public int IdStatusPedido { get; set; }
        public FormaPagamento formaPagamento { get; set; }
        public int IdFormaPagamento { get; set; }
        public int PercDesconto { get; set; }
        public decimal Total { get; set; }
    }   
}
