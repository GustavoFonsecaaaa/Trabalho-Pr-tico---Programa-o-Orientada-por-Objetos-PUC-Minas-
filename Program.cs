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
                        AbrirChamado();
                    }
                    else if (opcao == 6)
                    {
                        AtribuirTecnico();
                    }
                    else if (opcao == 7)
                    {
                        AlterarSituacaoChamado();
                    }
                    else if (opcao == 8)
                    {
                        ConsultarChamados();
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

        private static void AbrirChamado()
        {
            Console.WriteLine("Abrir Chamado");

            if (solicitantes.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar pelo menos um solicitante antes de abrir um chamado.");
                return;
            }

            if (categorias.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar pelo menos uma categoria antes de abrir um chamado.");
                return;
            }

            Console.WriteLine("Solicitantes disponíveis:");
            for (int i = 0; i < solicitantes.Count; i++)
            {
                Console.WriteLine(solicitantes[i].ToString());
            }

            int idSolicitante = LerInteiro("Informe o ID do solicitante: ");
            Solicitante? solicitanteSelecionado = BuscarSolicitantePorId(idSolicitante);
            if (solicitanteSelecionado == null)
            {
                Console.WriteLine("Solicitante não encontrado.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Categorias disponíveis:");
            for (int i = 0; i < categorias.Count; i++)
            {
                Console.WriteLine(categorias[i].ToString());
            }

            int idCategoria = LerInteiro("Informe o ID da categoria: ");
            Categoria? categoriaSelecionada = BuscarCategoriaPorId(idCategoria);
            if (categoriaSelecionada == null)
            {
                Console.WriteLine("Categoria não encontrada.");
                return;
            }

            categoriaSelecionada.VerificarSeEstaAtiva();

            Console.WriteLine();
            Console.WriteLine("Tipo de chamado:");
            Console.WriteLine("1 - Incidente");
            Console.WriteLine("2 - Requisição");
            Console.WriteLine("3 - Dúvida");
            int tipo = LerInteiro("Escolha o tipo do chamado (1 a 3): ");

            if (tipo < 1 || tipo > 3)
            {
                Console.WriteLine("Tipo de chamado inválido.");
                return;
            }

            string titulo = LerTextoObrigatorio("Título: ");
            string descricao = LerTextoObrigatorio("Descrição: ");

            string nomeTipo = "";
            string detalhesEspecificos = "";

            if (tipo == 1)
            {
                nomeTipo = "Incidente";
                string servicoAfetado = LerTextoObrigatorio("Serviço afetado: ");
                bool sistemaParado = LerSimOuNao("O sistema está parado? (1 - Sim, 2 - Não): ");
                string textoSistemaParado = "Não";
                if (sistemaParado)
                {
                    textoSistemaParado = "Sim";
                }
                detalhesEspecificos = "Serviço afetado: " + servicoAfetado + " | Sistema parado: " + textoSistemaParado;
            }
            else if (tipo == 2)
            {
                nomeTipo = "Requisição";
                string recursoSolicitado = LerTextoObrigatorio("Recurso solicitado: ");
                bool aprovadoGestor = LerSimOuNao("Aprovado pelo gestor? (1 - Sim, 2 - Não): ");
                string textoAprovado = "Não";
                if (aprovadoGestor)
                {
                    textoAprovado = "Sim";
                }
                detalhesEspecificos = "Recurso solicitado: " + recursoSolicitado + " | Aprovado pelo gestor: " + textoAprovado;
            }
            else
            {
                nomeTipo = "Dúvida";
                string topicoAssunto = LerTextoObrigatorio("Tópico do assunto: ");
                detalhesEspecificos = "Tópico do assunto: " + topicoAssunto;
            }

            Console.WriteLine();
            Console.WriteLine("Resumo dos dados do chamado:");
            Console.WriteLine("Solicitante: " + solicitanteSelecionado.Nome + " (ID " + solicitanteSelecionado.Id + ")");
            Console.WriteLine("Categoria: " + categoriaSelecionada.Nome + " (ID " + categoriaSelecionada.Id + ")");
            Console.WriteLine("Tipo: " + nomeTipo);
            Console.WriteLine("Título: " + titulo);
            Console.WriteLine("Descrição: " + descricao);
            Console.WriteLine(detalhesEspecificos);
            Console.WriteLine("Aviso: a abertura do chamado será concluída após a integração com a classe CentralDeChamados.");
        }

        private static void AtribuirTecnico()
        {
            Console.WriteLine("Atribuir Técnico a um Chamado");

            if (tecnicos.Count == 0)
            {
                Console.WriteLine("Não há técnicos cadastrados. Cadastre um técnico primeiro.");
                return;
            }

            int codigoChamado = LerInteiro("Informe o código do chamado: ");
            if (codigoChamado <= 0)
            {
                Console.WriteLine("Código do chamado inválido. Deve ser maior que zero.");
                return;
            }

            Console.WriteLine("Técnicos disponíveis:");
            for (int i = 0; i < tecnicos.Count; i++)
            {
                Console.WriteLine(tecnicos[i].ToString());
            }

            int idTecnico = LerInteiro("Informe o ID do técnico: ");
            Tecnico? tecnicoSelecionado = BuscarTecnicoPorId(idTecnico);
            if (tecnicoSelecionado == null)
            {
                Console.WriteLine("Técnico não encontrado.");
                return;
            }

            if (!tecnicoSelecionado.PodeAtender())
            {
                throw new LimiteDeChamadosExcedidoException(tecnicoSelecionado.Nome, tecnicoSelecionado.LimiteDeChamados);
            }

            Console.WriteLine("Técnico " + tecnicoSelecionado.Nome + " disponível para assumir o chamado #" + codigoChamado + ".");
            Console.WriteLine("Aviso: a atribuição efetiva aguarda integração com a classe CentralDeChamados.");
        }

        private static void AlterarSituacaoChamado()
        {
            Console.WriteLine("Alterar Situação de um Chamado");

            int codigoChamado = LerInteiro("Informe o código do chamado: ");
            if (codigoChamado <= 0)
            {
                Console.WriteLine("Código do chamado inválido. Deve ser maior que zero.");
                return;
            }

            Console.WriteLine("Nova situação:");
            Console.WriteLine("1 - Aberto");
            Console.WriteLine("2 - Em Atendimento");
            Console.WriteLine("3 - Resolvido");
            Console.WriteLine("4 - Fechado");
            int opcaoSituacao = LerInteiro("Escolha a nova situação (1 a 4): ");

            string nomeSituacao = "";
            if (opcaoSituacao == 1)
            {
                nomeSituacao = "Aberto";
            }
            else if (opcaoSituacao == 2)
            {
                nomeSituacao = "Em Atendimento";
            }
            else if (opcaoSituacao == 3)
            {
                nomeSituacao = "Resolvido";
            }
            else if (opcaoSituacao == 4)
            {
                nomeSituacao = "Fechado";
            }
            else
            {
                Console.WriteLine("Situação inválida. Escolha um número de 1 a 4.");
                return;
            }

            string observacao = LerTextoObrigatorio("Observação do registro de atendimento: ");

            Console.WriteLine();
            Console.WriteLine("Chamado #" + codigoChamado + " -> Nova situação: " + nomeSituacao);
            Console.WriteLine("Observação: " + observacao);
            Console.WriteLine("Aviso: a alteração de situação aguarda integração com a classe CentralDeChamados.");
        }

        private static void ConsultarChamados()
        {
            Console.WriteLine("Consultar Histórico e Chamados Vencidos");
            Console.WriteLine("1 - Consultar histórico de um chamado por código");
            Console.WriteLine("2 - Listar chamados vencidos");
            int opcaoConsulta = LerInteiro("Escolha uma opção (1 ou 2): ");

            if (opcaoConsulta == 1)
            {
                int codigoChamado = LerInteiro("Informe o código do chamado: ");
                if (codigoChamado <= 0)
                {
                    Console.WriteLine("Código do chamado inválido. Deve ser maior que zero.");
                    return;
                }

                Console.WriteLine("Consulta de histórico preparada para o chamado #" + codigoChamado + ".");
                Console.WriteLine("Aviso: a consulta de histórico aguarda integração com a classe CentralDeChamados.");
            }
            else if (opcaoConsulta == 2)
            {
                Console.WriteLine("Consulta de chamados vencidos preparada.");
                Console.WriteLine("Aviso: a listagem de chamados vencidos aguarda integração com a classe CentralDeChamados.");
            }
            else
            {
                Console.WriteLine("Opção inválida. Escolha 1 ou 2.");
            }
        }

        private static Solicitante? BuscarSolicitantePorId(int id)
        {
            for (int i = 0; i < solicitantes.Count; i++)
            {
                if (solicitantes[i].Id == id)
                {
                    return solicitantes[i];
                }
            }
            return null;
        }

        private static Tecnico? BuscarTecnicoPorId(int id)
        {
            for (int i = 0; i < tecnicos.Count; i++)
            {
                if (tecnicos[i].Id == id)
                {
                    return tecnicos[i];
                }
            }
            return null;
        }

        private static Categoria? BuscarCategoriaPorId(int id)
        {
            for (int i = 0; i < categorias.Count; i++)
            {
                if (categorias[i].Id == id)
                {
                    return categorias[i];
                }
            }
            return null;
        }

        private static bool LerSimOuNao(string mensagem)
        {
            while (true)
            {
                int resposta = LerInteiro(mensagem);
                if (resposta == 1)
                {
                    return true;
                }
                else if (resposta == 2)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite 1 para Sim ou 2 para Não.");
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
