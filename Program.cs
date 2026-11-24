using System;
using Helpdesk.Classes;

namespace Helpdesk
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("Central de chamados HelpDesk");
                Console.WriteLine("1 - Cadastrar Solicitante");
                Console.WriteLine("2 - Cadastrar Tecnico");
                Console.WriteLine("3 - Cadastrar Categoria");
                Console.WriteLine("4 - Listar Solicitantes, Tecnicos e Categorias");
                Console.WriteLine("5 - Abrir Chamado");
                Console.WriteLine("6 - Atribuir Tecnico a um Chamado");
                Console.WriteLine("7 - Alterar Situacao de um Chamado");
                Console.WriteLine("8 - Consultar Historico e Chamados Vencidos");
                Console.WriteLine("0 - Sair");

                try
                {
                    int opcao = LerInteiro("Escolha uma opção: ");
                    Console.WriteLine();

                    if (opcao == 1)
                    {
                        Console.WriteLine("Funcionalidade em desenvolvimento");
                    }
                    else if (opcao == 2)
                    {
                        Console.WriteLine("Funcionalidade em desenvolvimento");
                    }
                    else if (opcao == 3)
                    {
                        Console.WriteLine("Funcionalidade em desenvolvimento");
                    }
                    else if (opcao == 4)
                    {
                        Console.WriteLine("Funcionalidade em desenvolvimento");
                    }
                    else if (opcao == 5)
                    {
                        Console.WriteLine("Funcionalidade em desenvolvimento");
                    }
                    else if (opcao == 6)
                    {
                        Console.WriteLine("Funcionalidade em desenvolvimento");
                    }
                    else if (opcao == 7)
                    {
                        Console.WriteLine("Funcionalidade em desenvolvimento");
                    }
                    else if (opcao == 8)
                    {
                        Console.WriteLine("Funcionalidade em desenvolvimento");
                    }
                    else if (opcao == 0)
                    {
                        Console.WriteLine("Encerrando o sistema...");
                        executando = false;
                    }
                    else
                    {
                        Console.WriteLine("Opcao invalida. Escolha um numero de 0 a 8.");
                    }
                }
                catch (ValidacaoException ex)
                {
                    Console.WriteLine("Erro de validacao: " + ex.Message);
                }
                catch (LimiteDeChamadosExcedidoException ex)
                {
                    Console.WriteLine("Limite de chamados excedido: " + ex.Message);
                }
                catch (HelpdeskException ex)
                {
                    Console.WriteLine("Erro no Helpdesk: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro inesperado: " + ex.Message);
                }

                if (executando)
                {
                    Console.WriteLine();
                }
            }
        }

        public static int LerInteiro(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? entrada = Console.ReadLine();
                int valor;

                if (int.TryParse(entrada, out valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Entrada invalida. Digite um numero inteiro.");
                }
            }
        }

        public static string LerTextoObrigatorio(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    return entrada.Trim();
                }
                else
                {
                    Console.WriteLine("Entrada invalida. O texto nao pode estar vazio.");
                }
            }
        }
    }
}
