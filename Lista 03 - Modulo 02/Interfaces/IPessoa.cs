using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IPessoa
    {
        string GetCpf();

        IPessoa BuscarPessoa(string cpf, List<IPessoa> listPessoa);

        string ImprimirPessoa();        

    }
}
