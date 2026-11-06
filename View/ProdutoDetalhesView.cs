using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class ProdutoDetalhesView : IProdutoView
    {
        public void MostrarProduto(Produto produto)
        {
            Console.WriteLine("\n==========| PRODUTO |==========");
            Console.WriteLine($"\nId: {produto.Id}");
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Preço: {produto.Preco:C2}");
            Console.WriteLine($"Descrição: {produto.Descricao}");
        }
    }
}
