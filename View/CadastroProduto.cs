using Projeto_SOLID.dados;
using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class CadastroProduto : ICadastroView<Produto>
    {
        public void ExibirMensagem(string m)
        {
            Console.Write(m);
            Console.ReadLine();
        }

        public Produto ObterDados()
        {
            Console.WriteLine("Nome :");
            string nome = Console.ReadLine();

            Console.WriteLine("Descrição :");
            string desc = Console.ReadLine();

            Console.WriteLine("Preço :");
            decimal preco = decimal.Parse(Console.ReadLine());

            int id = 0;

            return new Produto(id, nome, desc, preco);
        }
    }
}
