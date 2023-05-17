using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoClientes
{
    class Program
    {
        static List<Cliente> listaClientes = new List<Cliente>();
        static List<Produto> listaProdutos = new List<Produto>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("3 - Cadastrar produto");
                Console.WriteLine("4 - Listar produtos");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("Escolha uma opção: ");
                int opcao;

                if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 5)
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        CadastrarProduto();
                        break;
                    case 4:
                        ListarProdutos();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("Cadastro de Cliente");
            Console.WriteLine("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o email do cliente: ");
            string email = Console.ReadLine();
            Console.WriteLine("Digite o telefone do cliente: ");
            string telefone = Console.ReadLine();

            Cliente cliente = new Cliente(nome, email, telefone);
            listaClientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        static void ListarClientes()
        {
            Console.WriteLine("Lista de Clientes");

            if (listaClientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
            else
            {
                foreach (Cliente cliente in listaClientes)
                {
                    Console.WriteLine(cliente);
                    Console.WriteLine("----------------------------");
                }
            }
        }

        static void CadastrarProduto()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o preço do produto: ");
            decimal preco;

            if (!decimal.TryParse(Console.ReadLine(), out preco) || preco <= 0)
            {
                Console.WriteLine("Preço inválido. Tente novamente.");
                return;
            }

            Produto produto = new Produto(nome, preco);
            listaProdutos.Add(produto);

            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void ListarProdutos()
        {
            Console.WriteLine("Lista de Produtos");

            if (listaProdutos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
            else
            {
                foreach (Produto produto in listaProdutos)
                {
                    Console.WriteLine(produto);
                    Console.WriteLine("----------------------------");
                }
            }
        }
    }

    class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Cliente(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nEmail: {Email}\nTelefone: {Telefone}";
        }
    }

    class Produto
    {
        public string Nome { get; set; }
    public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nPreço: {Preco:C}";
        }
    }
}


