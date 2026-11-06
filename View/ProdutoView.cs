using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    public class ProdutoView : IProdutoView
    {
        public void MostrarProduto(Produto produto)
        {
            Console.WriteLine($"\nId: {produto.Id} | Nome: {produto.Nome} | Preço: {produto.Preco:C2}");
        }
    }
}
