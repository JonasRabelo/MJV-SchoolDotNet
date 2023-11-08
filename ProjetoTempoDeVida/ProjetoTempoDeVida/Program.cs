using ProjetoTempoDeVida;
using CalculadoraTempoDeVida;

internal class Program
{
    static Calculadora calc = new Calculadora();
    static Dictionary<string, Pessoa> pessoas = new Dictionary<string, Pessoa>();

    private static void Main(string[] args)
    {
        try
        {


            while (true)
            {
                Console.Write("Informe seu nome ('0' para sair): ");
                string nome = Console.ReadLine()!;

                if (pessoas.ContainsKey(nome))
                {
                    Menu(pessoas[nome]);
                }
                else if (nome == "0")
                {
                    break;
                }
                else
                {
                    Console.Write("\nInforme sua data de nascimento (no formato dd/mm/yyyy): ");

                    if (DateTime.TryParse(Console.ReadLine()!, out DateTime dataNasc))
                    {
                        Menu(new Pessoa(nome, dataNasc));
                    }

                    else
                    {
                        // Mensagem de erro se a data de nascimento for inválida.
                        Console.WriteLine("Formato de Data Inválida!");
                    }
                }

            }
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Ocorreu um erro.");
        }
        finally
        {
            Console.WriteLine("Programa Finalizado!");
        }

        static void Menu(Pessoa pessoa)
        {
            Console.Clear();
            Console.WriteLine($"Olá {pessoa.Nome}, seja bem-vindo (a)!");
            Console.WriteLine($"Hoje é dia {DateTime.Now.Day}" +
                $"de {calc.ObterNomeDoMes(DateTime.Now)} de {DateTime.Now.Year}.\n");
            Console.WriteLine("O que deseja realizar: ");
            Console.WriteLine("1 - Data de Falecimento com 100 anos de idade.\n" +
                              "2 - Idade atual completa\n3 - Inserir um ano para verificar a idade\n" +
                              "4 - Sair");
            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"{pessoa.Nome}, atualmente você tem {calc.IdadeAtual(pessoa.DataNascimento)} anos.");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(calc.ImprimeInformacoes(pessoa.Nome, pessoa.DataNascimento));
                        break;
                    case 3:
                        break;
                    case 4:
                        if (!pessoas.ContainsKey(pessoa.Nome)) pessoas.Add(pessoa.Nome, pessoa);
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


            

            Console.WriteLine("======================================================================");
            // Imprime informações sobre o tempo restante de vida.
            /*calc.ImprimirInformacoes(
                calc.CalculaTotalDeDias(dataFalecimento, dt) * 24,
                calc.CalculaTotalDeDias(dataFalecimento, dt),
                calc.CalculaTotalDeSemanas(dataFalecimento, dt),
                calc.CalculaTotalDeMeses(dataFalecimento, dt),
                (int)((dataFalecimento - dt).TotalDays / 365.25)
                );*/
        }
    }
}