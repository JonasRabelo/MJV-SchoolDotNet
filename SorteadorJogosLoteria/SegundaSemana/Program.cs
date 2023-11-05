using Microsoft.VisualBasic;
using SegundaSemana;



SorteadorDeJogo s = new SorteadorDeJogo();
Dictionary<string, Jogador> jogadores = new Dictionary<string, Jogador>();



LerDados(jogadores);
while (true)
{
    Console.Clear();
    Console.WriteLine("============= Bem-vindo (a) a LotecaJSR =============");
    Console.Write("Informe seu nome (Para sair digite '0'): ");
    string nome = Console.ReadLine()!;


    if (jogadores.ContainsKey(nome)) MenuPessal(jogadores[nome], jogadores);
    else if (nome == '0'.ToString())
    {
        GuardarDados(jogadores);
        break;
    }
    else
    {
        Console.Write("Informe quantos reais você tem para jogar: R$ ");
        double saldo = double.Parse(Console.ReadLine()!);
        MenuPessal(new Jogador(nome, saldo), jogadores);
    }

}

static void LerDados(Dictionary<string, Jogador> jogadores)
{
    string filePath = @"G:\\MJV SCHOOL\\MJV SCHOOL\\SorteadorJogosLoteria\\exemplo.txt";

    // Cria um objeto StreamWriter para o arquivo especificado
    if (File.Exists(filePath))
    {
        try
        {
            using (StreamReader leitor = new StreamReader(filePath))
            {
                if (int.TryParse(leitor.ReadLine(), out int totalClasses))
                {
                    for (int i = 0; i < totalClasses; i++)
                    {
                        string nomeJogador = leitor.ReadLine()!;
                        double saldo = double.Parse(leitor.ReadLine()!);
                        
                        Jogador jog = new Jogador(nomeJogador, saldo);
                        int totalJogosJogador = int.Parse(leitor.ReadLine()!);
                        for (int j = 0; j < totalJogosJogador; j++)
                        {
                            (string, List<int>) jogoFormatado = FormataJogo(leitor.ReadLine()!);
                            jog.jogos.Add(jogoFormatado.Item1, jogoFormatado.Item2);
                        }
                        jogadores.Add(jog.Nome, jog);
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {e.Message}");
        }
    }
    else
    {
        Console.WriteLine("O arquivo não existe.");
    }
}

static (string, List<int>) FormataJogo(string jogo)
{
    List<int> jogoFormatado = new List<int>();

    string[] dadosJogo = jogo.Split(":");
    string[] numerosJogo = dadosJogo[1].Replace(" [ ","").Replace(" ]", "").Split(", ");

    foreach (var dado in numerosJogo)
    {
        jogoFormatado.Add(int.Parse(dado));
    }

    return (dadosJogo[0], jogoFormatado);
}


static void GuardarDados(Dictionary<string, Jogador> jogadores)
{
    string filePath = @"G:\\MJV SCHOOL\\MJV SCHOOL\\SorteadorJogosLoteria\\exemplo.txt";

    // Cria um objeto StreamWriter para o arquivo especificado
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        if (jogadores != null){
            writer.WriteLine(jogadores.Count());

            foreach (Jogador jogador in jogadores.Values)
            {
                writer.WriteLine(jogador.Nome);
                writer.WriteLine(jogador.Saldo);
                writer.WriteLine(jogador.jogos.Count());
                if (jogador.jogos.Count() > 0)
                {
                    foreach (var jogo in jogador.jogos)
                    {
                        writer.WriteLine($"{jogo.Key}: {jogador.ImprimirJogo(jogo.Value)}");
                    }
                }

            }
        }
    }
}


static void MenuPessal(Jogador jogador, Dictionary<string, Jogador> jogadores)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Olá, {jogador.Nome}. Seja Bem-vindo.");
        Console.WriteLine($"O seu saldo atual é de R$ {jogador.Saldo.ToString("C2")}");
        Console.WriteLine($"Atualmente você tem {jogador.jogos.Count()} jogos feitos.");

        Console.WriteLine("O que deseja fazer: ");
        Console.WriteLine("1. Fazer um jogo");
        Console.WriteLine("2. Listar todos os jogos");
        Console.WriteLine("3. Deletar um jogo");
        Console.WriteLine("4. Sair desse perfil");

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


static Jogador EscolhaDoJogo(Jogador jogador)
{

    while (true)
    {
        SorteadorDeJogo s = new SorteadorDeJogo();
        Console.Clear();
        Console.WriteLine("Escolha um jogo da loteria:");
        Console.WriteLine("1. Mega-Sena");
        Console.WriteLine("2. Lotofácil");
        Console.WriteLine("3. Quina");
        Console.WriteLine("4. Lotomania");
        Console.WriteLine("5. Voltar");

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