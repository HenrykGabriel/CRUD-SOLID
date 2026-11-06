using Projeto_SOLID.dados;
using Projeto_SOLID.Model;
using Projeto_SOLID.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.Controller
{
    internal class CompraController
    {
        private readonly IRepository<Produto> repository;
        private readonly IProdutoView prodView;
        private readonly IItemView itemView;
        private readonly Compra compra;

        public CompraController(IRepository<Produto> repository,
            IProdutoView prodView, IItemView itemView,Compra compra)
        {
            this.prodView = prodView;
            this.repository = repository;
            this.itemView = itemView;
            this.compra = compra;
        }

        public void AdicionarItem(Item item)
        {
            List<Item> itens = compra.ListarTodos();

            int id;

            int tam_lista = itens.Count;

            if (tam_lista == 0)
            {
                id = 1;
            }
            else
            {
                id = tam_lista + 1;
            }

            item.AtualizarId(id);

            compra.Adicionar(item);
        }

        public void ListarProdutos()
        {
            List<Produto> produtos = repository.ListarTodos();

            Console.WriteLine("=======| Produtos disponíveis |=======\n");

            foreach(Produto produto in produtos)
            {
                prodView.MostrarProduto(produto);
            }
        }

        public void ListarItens()
        {
            List<Item> itens = compra.ListarTodos();

            Console.WriteLine("=======| Itens no carrinho |=======\n");

            foreach (Item item in itens)
            {
                itemView.MostrarItem(item);
            }
        }

        public void Remover(Item i)
        {
            compra.Remover(i);
        }

        public void Remover(int id)
        {
            compra.Remover(id);
        }

        public decimal CalcularTotal()
        {
            return compra.CalcularTotal();
        }
    }
}
