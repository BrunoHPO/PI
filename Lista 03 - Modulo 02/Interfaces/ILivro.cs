using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ILivro
    {
        ILivro BuscarLivro(int tombo, List<ILivro> listLivro);

        string ImprimirLivro();

        int GetCod();

    }
}
