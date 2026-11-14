using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.dados
{
    internal class ListaProdutos : IRepository<Produto>
    {
        private readonly List<Produto> produtos;

        public ListaProdutos()
        {
            produtos = new List<Produto>();
        }

        public void Adicionar(Produto produto)
        {
            produtos.Add(produto);
        }

        public void Atualizar(Produto entidade)
        {
            Produto p = BuscarPorId(entidade.Id);
            if (p == null )
            {
                throw new InvalidOperationException($"Nenhum produto com id {entidade.Id} encontrado!");
            }
            p.Atualizar(entidade.Nome, entidade.Descricao, entidade.Preco);
        }

        public Produto BuscarPorId(int id)
        {
            return produtos.FirstOrDefault(p => p.Id == id);
        }

        public List<Produto> ListarTodos()
        {
            return produtos.ToList();
        }

        public void Remover(Produto produto)
        {
            produtos.Remove(produto);
        }

        public void Remover(int id)
        {
            Produto p = BuscarPorId(id);

            if (p == null)
            {
                throw new InvalidOperationException($"Nenhum produto com o id {id} foi encontrado");
            }

            Remover(p);
        }

    }
}
