using LotericaSorteador;
using System.Text.Json;

namespace SegundaSemana
{
    class Program
    {
        static Loterica lot = new Loterica();
        static Dictionary<string, Jogador> jogadores = new Dictionary<string, Jogador>();
        private static void Main(string[] args)
        {
            try
            {
                CarregarDados();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("============= Bem-vindo (a) a LotecaJSR =============");
                    Console.Write("Informe seu nome (Para sair digite '0'): ");
                    string nome = Console.ReadLine()!;

                    if (jogadores.ContainsKey(nome)) MenuPessoal(jogadores[nome]);
                    else if (nome == "0")
                    {
                        SalvarDados();
                        break;
                    }
                    else
                    {
                        Console.Write("Informe quantos reais você tem para jogar: R$ ");
                        double saldo = double.Parse(Console.ReadLine()!);
                        MenuPessoal(new Jogador(nome, saldo));
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            /// <summary>
            /// Salva os dados dos jogadores em um arquivo JSON.
            /// </summary>
            static void SalvarDados()
            {
                // Serializa os dados dos jogadores e salva em um arquivo JSON
                string dadosParaSerializar = string.Empty;
                foreach (var jog in jogadores.Values)
                {
                    dadosParaSerializar += JsonSerializer.Serialize(jog) + " | ";
                }
                lot.SerializarDados(dadosParaSerializar);
            }

            /// <summary>
            /// Carrega os dados dos jogadores a partir de um arquivo JSON.
            /// </summary>
            static void CarregarDados()
            {
                // Lê os dados dos jogadores salvos e desserializa em Objetos.
                string[] dados = lot.LerDados();
                if (dados != null)
                {
                    Array.Resize(ref dados, dados.Length - 1);
                    foreach (string dado in dados)
                    {
                        Jogador j = JsonSerializer.Deserialize<Jogador>(dado)!;
                        jogadores.Add(j.Nome, j);
                    }
                }
            }

            /// <summary>
            /// Controla o menu pessoal de um jogador, permitindo a realização de diversas ações.
            /// </summary>
            static void MenuPessoal(Jogador jogador)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Olá, {jogador.Nome}. Seja Bem-vindo.");
                    Console.WriteLine($"O seu saldo atual é de R$ {jogador.Saldo.ToString("C2")}");
                    Console.WriteLine($"Atualmente você tem {jogador.jogos.Count()} jogos feitos.\n");
                    Console.WriteLine("O que deseja fazer: \n1. Fazer um jogo\n2. Listar todos os jogos");
                    Console.WriteLine("3. Deletar um jogo\n4. Adicionar Saldo\n5. Sair desse perfil");

                    int escolha;
                    if (int.TryParse(Console.ReadLine(), out escolha))
                    {
                        switch (escolha)
                        {
                            case 1:
                                jogador = EscolhaDoJogo(jogador);
                                break;
                            case 2:
                                jogador.ListarJogos();
                                break;
                            case 3:
                                jogador.ListarJogos();
                                Console.WriteLine("Selecione o nome do jogo a ser removido: ");
                                jogador.RemoverJogo(Console.ReadLine()!);
                                break;
                            case 4:
                                Console.Clear();
                                Console.Write("Informe o valor a ser adicionado: ");
                                if (double.TryParse(Console.ReadLine(), out double valorParaAdicionar))
                                    jogador.AdicionarSaldo(valorParaAdicionar);
                                else 
                                    Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                            case 5:
                                if (!jogadores.ContainsKey(jogador.Nome)) jogadores.Add(jogador.Nome, jogador);
                                return;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }

            /// <summary>
            /// Permite ao jogador escolher um jogo da loteria e adicioná-lo à sua lista de jogos.
            /// </summary>
            static Jogador EscolhaDoJogo(Jogador jogador)
            {

                while (true)
                {
                    Loterica s = new Loterica();
                    Console.Clear();
                    Console.WriteLine($"O seu saldo atual é de R$ {jogador.Saldo.ToString("C2")}\n");
                    Console.WriteLine("Escolha um jogo da loteria:");
                    Console.WriteLine("1. Mega-Sena\n2. Lotofácil\n3. Quina\n4. Lotomania\n5. Voltar");

                    int escolha;
                    List<int> jogoSorteado;
                    if (int.TryParse(Console.ReadLine(), out escolha))
                    {
                        switch (escolha)
                        {
                            case 1:
                                jogoSorteado = s.JogarMegaSena();
                                jogador.AdicionarJogo("Mega-Sena", jogoSorteado);
                                break;
                            case 2:
                                jogoSorteado = s.JogarLotofacil();
                                jogador.AdicionarJogo("Lotofacil", jogoSorteado);
                                break;
                            case 3:
                                jogoSorteado = s.JogarQuina();
                                jogador.AdicionarJogo("Quina", jogoSorteado);
                                break;
                            case 4:
                                jogoSorteado = s.JogarLotomania();
                                jogador.AdicionarJogo("Lotomania", jogoSorteado);
                                break;
                            case 5:
                                return jogador;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }

}