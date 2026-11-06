using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal interface ICadastroView<T>
    {
        T ObterDados();
        void ExibirMensagem(string m);
    }
}
