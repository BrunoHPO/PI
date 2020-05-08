using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaRoupa.Core
{    
    public class Estado
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        [MaxLength(2)]
        public string Sigla { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
