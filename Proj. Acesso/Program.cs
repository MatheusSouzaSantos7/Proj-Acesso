using System;
using System.Linq;

namespace Proj._Acesso
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Download(); // Carrega os dados ao iniciar

            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Controle de Acessos ===");
                Console.WriteLine("1. Cadastrar Ambiente");
                Console.WriteLine("2. Consultar Ambiente");
                Console.WriteLine("3. Excluir Ambiente");
                Console.WriteLine("4. Cadastrar Usuário");
                Console.WriteLine("5. Consultar Usuário");
                Console.WriteLine("6. Excluir Usuário");
                Console.WriteLine("7. Conceder Permissão de Acesso");
                Console.WriteLine("8. Revogar Permissão de Acesso");
                Console.WriteLine("9. Registrar Acesso");
                Console.WriteLine("10. Consultar Logs de Acesso");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcao)) opcao = -1;

                switch (opcao)
                {
                    case 1:
                        CadastrarAmbiente(cadastro);
                        break;
                    case 2:
                        ConsultarAmbiente(cadastro);
                        break;
                    case 3:
                        ExcluirAmbiente(cadastro);
                        break;
                    case 4:
                        CadastrarUsuario(cadastro);
                        break;
                    case 5:
                        ConsultarUsuario(cadastro);
                        break;
                    case 6:
                        ExcluirUsuario(cadastro);
                        break;
                    case 7:
                        ConcederPermissao(cadastro);
                        break;
                    case 8:
                        RevogarPermissao(cadastro);
                        break;
                    case 9:
                        RegistrarAcesso(cadastro);
                        break;
                    case 10:
                        ConsultarLogs(cadastro);
                        break;
                    case 0:
                        cadastro.Upload(); // Salva os dados ao sair
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                
                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcao != 0);
        }

        static void CadastrarAmbiente(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro de Ambiente ===");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Ambiente ambiente = new Ambiente(id, nome);
            cadastro.AdicionarAmbiente(ambiente);
            Console.WriteLine("Ambiente cadastrado com sucesso!");
        }

        static void ConsultarAmbiente(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Consulta de Ambiente ===");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            var ambiente = cadastro.PesquisarAmbiente(id);
            if (ambiente != null)
            {
                Console.WriteLine($"Ambiente encontrado: ID={ambiente.GetId()}, Nome={ambiente.GetNome()}");
            }
            else
            {
                Console.WriteLine("Ambiente não encontrado.");
            }
        }

        static void ExcluirAmbiente(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Exclusão de Ambiente ===");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            if (cadastro.RemoverAmbiente(new Ambiente(id, "")))
            {
                Console.WriteLine("Ambiente excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao excluir o ambiente.");
            }
        }

        static void CadastrarUsuario(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro de Usuário ===");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Usuario usuario = new Usuario(id, nome);
            cadastro.AdicionarUsuario(usuario);
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        static void ConsultarUsuario(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Consulta de Usuário ===");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            var usuario = cadastro.PesquisarUsuario(id);
            if (usuario != null)
            {
                Console.WriteLine($"Usuário encontrado: ID={usuario.GetId()}, Nome={usuario.GetNome()}");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        static void ExcluirUsuario(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Exclusão de Usuário ===");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            if (cadastro.RemoverUsuario(new Usuario(id, "")))
            {
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao excluir o usuário.");
            }
        }

        static void ConcederPermissao(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Conceder Permissão ===");
            Console.Write("ID do Usuário: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("ID do Ambiente: ");
            int idAmbiente = int.Parse(Console.ReadLine());

            var usuario = cadastro.PesquisarUsuario(idUsuario);
            var ambiente = cadastro.PesquisarAmbiente(idAmbiente);

            if (usuario != null && ambiente != null)
            {
                if (usuario.ConcederPermissao(ambiente))
                {
                    Console.WriteLine("Permissão concedida com sucesso!");
                }
                else
                {
                    Console.WriteLine("Falha ao conceder permissão.");
                }
            }
            else
            {
                Console.WriteLine("Usuário ou Ambiente não encontrado.");
            }
        }

        static void RevogarPermissao(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Revogar Permissão ===");
            Console.Write("ID do Usuário: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("ID do Ambiente: ");
            int idAmbiente = int.Parse(Console.ReadLine());

            var usuario = cadastro.PesquisarUsuario(idUsuario);
            var ambiente = cadastro.PesquisarAmbiente(idAmbiente);

            if (usuario != null && ambiente != null)
            {
                if (usuario.RevogarPermissao(ambiente))
                {
                    Console.WriteLine("Permissão revogada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Falha ao revogar permissão.");
                }
            }
            else
            {
                Console.WriteLine("Usuário ou Ambiente não encontrado.");
            }
        }

        static void RegistrarAcesso(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Registrar Acesso ===");
            Console.Write("ID do Usuário: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("ID do Ambiente: ");
            int idAmbiente = int.Parse(Console.ReadLine());

            var usuario = cadastro.PesquisarUsuario(idUsuario);
            var ambiente = cadastro.PesquisarAmbiente(idAmbiente);

            if (usuario != null && ambiente != null)
            {
                // Verificação sem adicionar um método na classe Usuario
                bool autorizado = usuario.GetAmbientes().Any(a => a.GetId() == ambiente.GetId());

                ambiente.RegistrarLog(new Log(DateTime.Now, usuario, autorizado));
                Console.WriteLine($"Acesso {(autorizado ? "Autorizado" : "Negado")} registrado!");
            }
            else
            {
                Console.WriteLine("Usuário ou Ambiente não encontrado.");
            }
        }



        static void ConsultarLogs(Cadastro cadastro)
        {
            Console.Clear();
            Console.WriteLine("=== Consultar Logs ===");
            Console.Write("ID do Ambiente: ");
            int idAmbiente = int.Parse(Console.ReadLine());

            var ambiente = cadastro.PesquisarAmbiente(idAmbiente);
            if (ambiente != null)
            {
                Console.WriteLine("Escolha o tipo de logs para consultar:");
                Console.WriteLine("1. Autorizados");
                Console.WriteLine("2. Negados");
                Console.WriteLine("3. Todos");
                int opcaoLog = int.Parse(Console.ReadLine());

                var logs = ambiente.GetLogs();
                switch (opcaoLog)
                {
                    case 1:
                        logs = logs.Where(log => log.GetTipoAcesso()).ToList();
                        break;
                    case 2:
                        logs = logs.Where(log => !log.GetTipoAcesso()).ToList();
                        break;
                }

                Console.WriteLine("=== Logs de Acesso ===");
                foreach (var log in logs)
                {
                    Console.WriteLine($"Data: {log.GetDtAcesso()}, Usuário: {log.GetUsuario().GetNome()}, Tipo: {(log.GetTipoAcesso() ? "Autorizado" : "Negado")}");
                }
            }
            else
            {
                Console.WriteLine("Ambiente não encontrado.");
            }
        }
    }
}
