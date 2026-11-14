using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.dados
{
    internal interface ICompraRepository<T>
    {
        void Adicionar(T novo);
        List<T> ListarTodos();
        T BuscarPorId(int id);
    }
}
