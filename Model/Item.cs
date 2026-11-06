using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.Model
{
    internal class Item
    {
        public int Id { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Subtotal { get; private set; }

        public Item(int id, Produto produto, int quantidade)
        {
            Id = id;
            Produto = produto;
            Quantidade = quantidade;
            Subtotal = Quantidade * produto.Preco;
        }

        public void AtualizarId(int id)
        {
            Id = id;
        }
    }
}
