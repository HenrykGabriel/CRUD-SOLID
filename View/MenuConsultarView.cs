using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class MenuConsultarView : IMenuView
    {
        public int ExibirMenu()
        {
            Console.Clear();

            Console.WriteLine("=== CONSULTA DE COMPRAS ===");
            Console.WriteLine();
            Console.WriteLine("1 - Listar compras");
            Console.WriteLine("2 - Ver detalhes da compra");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
                return opcao;

            return -1;
        }
    }
}
