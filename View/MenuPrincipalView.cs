using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class MenuPrincipalView : IMenuView
    {
        public int ExibirMenu()
        {
            Console.Clear();

            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine();
            Console.WriteLine("1 - Comprar");
            Console.WriteLine("2 - Gerenciar produtos");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
                return opcao;

            return -1;
        }
    }
}
