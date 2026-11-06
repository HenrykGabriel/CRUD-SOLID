using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.dados
{
    internal interface IRepository<T>
    {
        void Adicionar(T novo);
        List<T> ListarTodos();
        T BuscarPorId(int id);
        void Atualizar(T entidade);
        void Remover(T entidade);
        void Remover(int id);

    }
}
