using Projeto_SOLID.Controller;
using Projeto_SOLID.dados;
using Projeto_SOLID.Model;
using Projeto_SOLID.View;
using System;
using System.Collections.Generic;

namespace ProjetoSOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Produto> repository = new ListaProdutos();

            bool prodBases = false;

            int opcao;

            do
            {
                opcao = MenuPrincipal();

                switch(opcao)
                {
                    case 1:
                        MenuCompra(repository);
                        break;

                    case 2:
                        MenuProdutos(repository, prodBases);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }

        public static void CadastrarProdutosBases(ProdutoController c)
        {
            c.CadastrarProdBases(new Produto(0, "Coxinha", "Coxinha com recheio de frango e catupiry", 6.9m));
            c.CadastrarProdBases(new Produto(0, "Camisa", "Camisa branca com gola preta", 70m));
            c.CadastrarProdBases(new Produto(0, "Banco", "Banco de madeira", 60.99m));
        }

        public static void MenuProdutos(IRepository<Produto> repository, bool prodBases)
        {
            IProdutoView produtoView = new ProdutoView();
            IProdutoView produtoDetalhesView = new ProdutoDetalhesView();
            ICadastroView<Produto> cadastroView = new CadastroProduto();
            IMenuView menuView = new MenuProdutosView();

            ProdutoController controller = new
                ProdutoController(repository, produtoView,
                cadastroView);

            if(!prodBases)
            {
                CadastrarProdutosBases(controller);
                prodBases = true;
            }

            int opcao;

            do
            {
                opcao = menuView.ExibirMenu();

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        controller.Cadastrar();
                        break;

                    case 2:
                        controller.Listar();
                        break;

                    case 3:
                        Console.Write("Informe o ID: ");

                        if (int.TryParse(Console.ReadLine(), out int idBusca))
                        {
                            Produto produto = controller.Buscar(idBusca);

                            if (produto != null)
                                produtoDetalhesView.MostrarProduto(produto);
                            else
                                Console.WriteLine("Produto não encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;

                    case 4:
                        Console.Write("Informe o ID: ");

                        if (int.TryParse(Console.ReadLine(), out idBusca))
                        {
                            Produto produto = controller.Buscar(idBusca);

                            if (produto != null)
                            {
                                produtoDetalhesView.MostrarProduto(produto);

                                Console.WriteLine("\nNome :");
                                string nome = Console.ReadLine();

                                Console.WriteLine("Descrição :");
                                string desc = Console.ReadLine();

                                Console.WriteLine("Preço :");
                                decimal preco = decimal.Parse(Console.ReadLine());

                                produto.Atualizar(nome, desc, preco);
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;

                    case 5:
                        Console.Write("Informe o ID: ");

                        if (int.TryParse(Console.ReadLine(), out int idExcluir))
                        {
                            controller.Remover(idExcluir);
                            Console.WriteLine("\nOperação de exclusão concluída.");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        public static int MenuPrincipal()
        {
            IMenuView MenuPrincipal = new MenuPrincipalView();

            int opcao = MenuPrincipal.ExibirMenu();

            return opcao;
        }

        public static void MenuCompra(IRepository<Produto> repository)
        {
            IProdutoView produtoView = new ProdutoView();
            IMenuView menuView = new MenuCompraView();
            Compra compra = new Compra();
            IItemView itemView = new ItemView();

            CompraController controller = new CompraController(repository, produtoView, itemView, compra);

            int opcao;

            do
            {
                opcao = menuView.ExibirMenu();

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        int tam_lista = repository.ListarTodos().Count();

                        if (tam_lista == 0)
                        {
                            Console.WriteLine("Nenhum produto disponível no momento");
                        }
                        else
                        {
                            controller.ListarProdutos();

                            Console.Write("\nEscolha o id do produto: ");
                            int id = int.Parse(Console.ReadLine());

                            if(id > tam_lista)
                            {
                                Console.WriteLine("\nProduto não encontrado");
                            }
                            else
                            {
                                Console.Write("\nQual a quantidade do produto: ");
                                int quant = int.Parse(Console.ReadLine());

                                Produto p = repository.BuscarPorId(id);

                                Item item = new Item(0, p, quant);

                                controller.AdicionarItem(item);

                                Console.WriteLine("\nItem adicionando");
                            }
                        }
                        break;

                    case 2:
                        tam_lista = compra.ListarTodos().Count();

                        if(tam_lista > 0)
                        {
                            controller.ListarItens();
                        }
                        else
                        {
                            Console.WriteLine("Não há itens no carrinho");
                        }

                        break;

                    case 3:
                        tam_lista = compra.ListarTodos().Count();

                        if (tam_lista > 0)
                        {
                            controller.ListarItens();

                            Console.Write("\nQual o id do item: ");
                            int id = int.Parse(Console.ReadLine());

                            if (id > tam_lista)
                            {
                                Console.WriteLine("\n\nItem não encontrado");
                            }
                            else
                            {
                                controller.Remover(id);

                                Console.WriteLine("\n\nItem removido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNão há itens no carrinho");
                        }
                        break;

                    case 4:
                        tam_lista = repository.ListarTodos().Count();

                        if (tam_lista == 0)
                        {
                            Console.WriteLine("Nenhum produto disponível no momento");
                        }
                        else
                        {
                            controller.ListarProdutos();
                        }
                            break;

                    case 5:
                        tam_lista = compra.ListarTodos().Count();

                        if (tam_lista == 0)
                        {
                            Console.WriteLine("\nNão há itens no carrinho");
                        }
                        else
                        {
                            controller.ListarItens();

                            decimal total = controller.CalcularTotal();

                            Console.WriteLine($"\nO total da compra foi: {total:C2}");

                            Console.WriteLine("\nAperte enter para sair...");
                            Console.ReadKey();
                        }
                        break;

                    case 0:
                        Console.WriteLine("Cancelando compra...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0 && opcao != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }
    }
}
