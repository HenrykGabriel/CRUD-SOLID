using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class MenuCompraView : IMenuView
    {
        public int ExibirMenu()
        {
            Console.Clear();

            Console.WriteLine("=== MENU COMPRA ===");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar itens ao carrinho");
            Console.WriteLine("2 - Listar itens do carrinho");
            Console.WriteLine("3 - Remover item do carrinho");
            Console.WriteLine("4 - Listar produtos dísponiveis");
            Console.WriteLine("5 - Finalizar compra");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
                return opcao;

            return -1;
        }
    }
}
