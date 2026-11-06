using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class ItemView : IItemView
    {
        public void MostrarItem(Item item)
        {
            Console.WriteLine($"\nId: {item.Id} | Nome: {item.Produto.Nome} | Quantidade: {item.Quantidade} | Preço(uni): {item.Produto.Preco:C2} | Subtotal: {item.Subtotal:C2}");
        }
    }
}
