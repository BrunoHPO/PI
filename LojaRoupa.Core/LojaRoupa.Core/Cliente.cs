using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaRoupa.Core
{
    public class Cliente
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [MaxLength(11)]
        public string Telefone { get; set; }

        [MaxLength(11)]
        public string CPF { get; set; }        
        public bool IsAtivo { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
