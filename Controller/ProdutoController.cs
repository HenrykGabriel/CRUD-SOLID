using Projeto_SOLID.dados;
using Projeto_SOLID.View;
using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.Controller
{
    internal class ProdutoController
    {
        private readonly IRepository<Produto> repository;
        private readonly IProdutoView view;
        private readonly ICadastroView<Produto> cadastroView;

        public ProdutoController(IRepository<Produto> repository,
            IProdutoView view, ICadastroView<Produto> cadastroView)
        {
            this.view = view;
            this.repository = repository;
            this.cadastroView = cadastroView;
        }

        public void Cadastrar()
        {
            Produto produto = cadastroView.ObterDados();

            List<Produto> produtos = repository.ListarTodos();
         
            int id = 0;

            if (produtos.Count == 0)
            {
                id = 1;
            }
            else
            {
                foreach (Produto prod in produtos)
                {
                    if (id < prod.Id)
                    {
                        id = prod.Id;
                    }
                }

                id += 1;
            }

            produto.Atualizar_id(id);

            repository.Adicionar(produto);

            cadastroView.ExibirMensagem(
                "Produto cadastrado com sucesso!");
        }

        public void Listar()
        {
            List<Produto> produtos = 
                repository.ListarTodos();
            Console.WriteLine("==========| PRODUTO |==========");
            foreach (Produto produto in produtos)
            {
                view.MostrarProduto(produto);
            }
        }

        public Produto Buscar(int id)
        {
            return repository.BuscarPorId(id);
        }

        public void Atualizar(Produto produto)
        {
            repository.Atualizar(produto);
        }

        public void Atualizar(int id)
        {
            repository.Atualizar(Buscar(id));
        }

        public void Remover(Produto p)
        {
            repository.Remover(p);
        }

        public void Remover(int id)
        { 
            repository.Remover(id);
        }

        public void CadastrarProdBases(Produto p)
        {
            List<Produto> produtos = repository.ListarTodos();

            int id = 0;

            if (produtos.Count == 0)
            {
                id = 1;
            }
            else
            {
                foreach (Produto prod in produtos)
                {
                    if (id < prod.Id)
                    {
                        id = prod.Id;
                    }
                }

                id += 1;
            }

            p.Atualizar_id(id);

            repository.Adicionar(p);
        }

        public bool ProcurarProduto(int id)
        {
            foreach (Produto produto in repository.ListarTodos())
            {
                if (produto.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

