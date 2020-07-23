using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaRoupa.Core
{
    public class Endereco
    {
        public int ID { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Estado Estado { get; set; }
        public int IdEstado { get; set; }

        [MaxLength(8)]
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
    }   
}
