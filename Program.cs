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
                Console.WriteLine("2 - Cadastrar Técnico");
                Console.WriteLine("3 - Cadastrar Categoria");
                Console.WriteLine("4 - Listar Solicitantes, Técnicos e Categorias");
                Console.WriteLine("5 - Abrir Chamado");
                Console.WriteLine("6 - Atribuir Técnico a um Chamado");
                Console.WriteLine("7 - Alterar Situação de um Chamado");
                Console.WriteLine("8 - Consultar Histórico e Chamados Vencidos");
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
                        Console.WriteLine("Opção inválida. Escolha um número de 0 a 8.");
                    }
                }
                catch (ValidacaoException ex)
                {
                    Console.WriteLine("Erro de validação: " + ex.Message);
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
                string? entrada = Console.ReadLine();       //o interrrogacao e so para nao ficar sublinhado de amarelo
                int valor;

                if (int.TryParse(entrada, out valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite um número inteiro.");
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
                    Console.WriteLine("Entrada inválida. O texto não pode estar vazio.");
                }
            }
        }
    }
}
