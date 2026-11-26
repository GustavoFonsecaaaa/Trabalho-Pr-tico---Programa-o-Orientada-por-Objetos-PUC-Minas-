using System;
using System.Collections.Generic;
using Helpdesk.Classes;

namespace Helpdesk
{
    internal class Program
    {
        private static List<Solicitante> solicitantes = new List<Solicitante>();
        private static List<Tecnico> tecnicos = new List<Tecnico>();
        private static List<Categoria> categorias = new List<Categoria>();

        private static int proximoIdSolicitante = 1;
        private static int proximoIdTecnico = 1;
        private static int proximoIdCategoria = 1;

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
                        CadastrarSolicitante();
                    }
                    else if (opcao == 2)
                    {
                        CadastrarTecnico();
                    }
                    else if (opcao == 3)
                    {
                        CadastrarCategoria();
                    }
                    else if (opcao == 4)
                    {
                        ListarCadastros();
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

        private static void CadastrarSolicitante()
        {
            Console.WriteLine("Cadastrar Solicitante");
            string nome = LerTextoObrigatorio("Nome: ");
            string email = LerTextoObrigatorio("E-mail: ");
            string setor = LerTextoObrigatorio("Setor: ");
            Console.Write("Ramal (opcional, 3 a 5 dígitos): ");
            string? ramalEntrada = Console.ReadLine();
            string ramal = "";
            if (ramalEntrada != null)
            {
                ramal = ramalEntrada.Trim();
            }

            Solicitante solicitante = new Solicitante(proximoIdSolicitante, nome, email, setor, ramal);
            solicitantes.Add(solicitante);
            proximoIdSolicitante = proximoIdSolicitante + 1;

            Console.WriteLine("Solicitante cadastrado com sucesso!");
            Console.WriteLine(solicitante.ToString());
        }

        private static void CadastrarTecnico()
        {
            Console.WriteLine("Cadastrar Técnico");
            string nome = LerTextoObrigatorio("Nome: ");
            string email = LerTextoObrigatorio("E-mail: ");
            string especialidade = LerTextoObrigatorio("Especialidade: ");
            int limiteDeChamados = LerInteiro("Limite de chamados simultâneos (1 a 10): ");

            Tecnico tecnico = new Tecnico(proximoIdTecnico, nome, email, especialidade, limiteDeChamados);
            tecnicos.Add(tecnico);
            proximoIdTecnico = proximoIdTecnico + 1;

            Console.WriteLine("Técnico cadastrado com sucesso!");
            Console.WriteLine(tecnico.ToString());
        }

        private static void CadastrarCategoria()
        {
            Console.WriteLine("Cadastrar Categoria");
            string nome = LerTextoObrigatorio("Nome da categoria: ");
            Console.Write("Descrição (opcional): ");
            string? descricaoEntrada = Console.ReadLine();
            string descricao = "";
            if (descricaoEntrada != null)
            {
                descricao = descricaoEntrada.Trim();
            }

            Categoria categoria = new Categoria(proximoIdCategoria, nome, descricao);
            categorias.Add(categoria);
            proximoIdCategoria = proximoIdCategoria + 1;

            Console.WriteLine("Categoria cadastrada com sucesso!");
            Console.WriteLine(categoria.ToString());
        }

        private static void ListarCadastros()
        {
            Console.WriteLine("Solicitantes Cadastrados");
            if (solicitantes.Count == 0)
            {
                Console.WriteLine("Nenhum solicitante cadastrado.");
            }
            else
            {
                for (int i = 0; i < solicitantes.Count; i++)
                {
                    Console.WriteLine(solicitantes[i].ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Técnicos Cadastrados");
            if (tecnicos.Count == 0)
            {
                Console.WriteLine("Nenhum técnico cadastrado.");
            }
            else
            {
                for (int i = 0; i < tecnicos.Count; i++)
                {
                    Console.WriteLine(tecnicos[i].ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Categorias Cadastradas");
            if (categorias.Count == 0)
            {
                Console.WriteLine("Nenhuma categoria cadastrada.");
            }
            else
            {
                for (int i = 0; i < categorias.Count; i++)
                {
                    Console.WriteLine(categorias[i].ToString());
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
