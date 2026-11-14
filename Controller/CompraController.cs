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
        private readonly ICompraRepository<Compra> compraRepository;
        private readonly IProdutoView prodView;
        private readonly IItemView itemView;
        private readonly Compra compra = new Compra(1);

        public CompraController(IRepository<Produto> repository, ICompraRepository<Compra> compraRepository,
            IProdutoView prodView, IItemView itemView)
        {
            this.prodView = prodView;
            this.repository = repository;
            this.itemView = itemView;
            this.compraRepository = compraRepository;
        }

        public void AdicionarItem(Item item)
        {
            List<Item> itens = compra.ListarTodos();

            int id = 0;

            if (itens.Count == 0)
            {
                id = 1;
            }
            else
            {
                foreach (Item i in itens)
                {
                    if (id < i.Id)
                    {
                        id = i.Id;
                    }
                }
            }

            id += 1;

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

        public List<Item> ListaItens()
        {
            return compra.ListarTodos();
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

        public void SalvarCompra()
        {
            if(compra.ListarTodos().Count > 0)
            {
                compraRepository.Adicionar(compra);
            }
        }
    }
}
