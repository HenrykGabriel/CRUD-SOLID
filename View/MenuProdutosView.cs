using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class MenuProdutosView : IMenuView
    {
        public int ExibirMenu()
        {
            Console.Clear();

            Console.WriteLine("=== GERENCIAMENTO DE PRODUTOS ===");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Buscar produto");
            Console.WriteLine("4 - Atualizar produto");
            Console.WriteLine("5 - Excluir produto");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
                return opcao;

            return -1;
        }
    }
}
