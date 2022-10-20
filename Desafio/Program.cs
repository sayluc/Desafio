using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class Program
    {
        static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("**********************");
            Console.WriteLine("*** FuteSharp 2022 ***");
            Console.WriteLine("**********************");
            Console.WriteLine("1 - Listar Jogadores ");
            Console.WriteLine("2 - Cadastrar Jogadores ");
            Console.WriteLine("3 - Encerrar Contrato ");
            Console.WriteLine("4 - Buscar Jogadores ");
            Console.WriteLine("5 - Sair ");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
        }
        
        // Menu para cadastrar de jogadores:
        static void MenuCadastrarJogadores()
        {
            Classe.Jogador l = new Classe.Jogador();

            Console.Write("name: ");
            l.name = Console.ReadLine();
            Console.Write("birth: ");
            l.birth = Console.ReadLine();
            Console.Write("email: ");
            l.email = Console.ReadLine();
            Console.WriteLine();

            // Selecionando a função do jogado:
            Console.WriteLine("**********************");
            Console.WriteLine("*** Functions FutS ***");
            Console.WriteLine("**********************");

            Console.WriteLine("1 - goalkeeper");
            Console.WriteLine("2 - defender");
            Console.WriteLine("3 - sides");
            Console.WriteLine("4 - flyheels");
            Console.WriteLine("5 - socks");
            Console.WriteLine("6 - attackers");
            Console.WriteLine();

            Console.Write("function: ");
            l.function = Console.ReadLine();
            Console.Write("s_number: ");
            l.s_number = int.Parse(Console.ReadLine());
            Console.Clear();

            // Enviar as infos pro BD e verificar se deu certo:
            if (Banco.FutDAO.Cadastrar(l) == true)
            {
                Console.WriteLine("Jogador cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Houve um erro no cadastro.");
            }
        }
        
        // Menu para listar os jogadores:
        static void ListarJogadores()
        {
            // Tabela para receber o resultado do SELECT:
            DataTable tabela = new DataTable();

            tabela = Banco.FutDAO.ListarTudo();

            // Verificar se a tabela tem mais de 0 linhas:
            if (tabela.Rows.Count > 0)
            {
                // Mostrar os dados:
                foreach (DataRow linha in tabela.Rows)
                {
                    Console.WriteLine("id: \t\t" + linha["id"].ToString());
                    Console.WriteLine("name: \t\t" + linha["name"].ToString());
                    Console.WriteLine("birth: \t\t" + linha["birth"].ToString());
                    Console.WriteLine("email: \t\t" + linha["email"].ToString());
                    Console.WriteLine("function: \t\t" + linha["function"].ToString());
                    Console.WriteLine("s_number: \t" + linha["s_number"].ToString());
                    Console.WriteLine("=============================");
                }
            }
            else
            {
                // Mostrar mensagem de erro:
                Console.WriteLine("Jogador não encontrado.");
            }
        }

        //Menu de apagar:
        static void MenuApagar()
        {
            Console.WriteLine("************************");
            Console.WriteLine("*** FIM DE CONTRATO ****");
            Console.WriteLine("************************");
            Console.Write("Digite o ID do jogador: ");
            int id = int.Parse(Console.ReadLine());

            Console.Clear();
            if (Banco.FutDAO.Apagar(id) == true)
            {
                Console.WriteLine("Contrato encerrado!");
            }
            else
            {
                Console.WriteLine("Erro ao apagar o id informado!");
            }
        }
       
        // Menu de busca:
        static void MenuBuscar()
        {
            Console.WriteLine("************************");
            Console.WriteLine("**** BUSCAR JOGADOR ****");
            Console.WriteLine("************************");

            Console.Write("Jogador a buscar: ");
            int busca = int.Parse(Console.ReadLine());

            DataTable resultado = Banco.FutDAO.ProcurarPorId(busca);

            // Verificar se a tabela tem mais de 0 linhas (copia do listar):
            if (resultado.Rows.Count > 0)
            {
                // Mostrar os dados:
                foreach (DataRow linha in resultado.Rows)
                {
                    Console.WriteLine("id: \t\t" + linha["id"].ToString());
                    Console.WriteLine("name: \t\t" + linha["name"].ToString());
                    Console.WriteLine("birth: \t\t" + linha["birth"].ToString());
                    Console.WriteLine("email: \t\t" + linha["email"].ToString());
                    Console.WriteLine("function: \t\t" + linha["function"].ToString());
                    Console.WriteLine("s_number: \t" + linha["s_number"].ToString());
                    Console.WriteLine("=============================");
                }
            }
            else
            {
                // Mostrar mensagem de erro:
                Console.WriteLine("Sua busca não retornou resultados.");
            }
        }

        // Sumário:
        static void Main(string[] args)
        {
            string opc = "";
            while (opc != "5")
            {
                MostrarMenu();
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        Console.Clear();
                        ListarJogadores();
                        break;

                    case "2":
                        Console.Clear();
                        MenuCadastrarJogadores();
                        break;

                    case "3":
                        Console.Clear();
                        MenuApagar();
                        break;

                    case "4":
                        Console.Clear();
                        MenuBuscar();
                        break;

                    case "5":
                        Console.WriteLine("Adios!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}