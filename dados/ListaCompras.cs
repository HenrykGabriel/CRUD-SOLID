using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.dados
{
    internal class ListaCompras : ICompraRepository<Compra>
    {
        private readonly List<Compra> compras;

        public ListaCompras()
        {
            compras = new List<Compra>();
        }

        public void Adicionar(Compra compra)
        {

            int id = 0;

            if (compras.Count == 0)
            {
                id = 1;
            }
            else
            {
                foreach (Compra c in compras)
                {
                    if (id < c.Id)
                    {
                        id = c.Id;
                    }
                }

                id += 1;
            }

            compra.AtualizarId(id);

            compras.Add(compra);
        }

        public List<Compra> ListarTodos()
        {
            return compras.ToList();
        }

        public Compra BuscarPorId(int id)
        {
            return compras.FirstOrDefault(c => c.Id == id);
        }
    }
}
