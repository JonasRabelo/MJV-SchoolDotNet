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
            while (true) { 
            Console.Clear();
            Console.WriteLine($"Olá {pessoa.Nome}, seja bem-vindo (a)!");
            Console.WriteLine($"Hoje é dia {DateTime.Now.Day} " +
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
                        Console.WriteLine($"Olá {pessoa.Nome}. Você está programado(a) para viver até o dia {(pessoa.DataNascimento.AddYears(100)).Day} " +
                $"de {calc.ObterNomeDoMes(pessoa.DataNascimento.AddYears(100))} de {pessoa.DataNascimento.AddYears(100).Year}.");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(calc.ImprimeInformacoes(pessoa.DataNascimento));
                        break;
                    case 3:
                            Console.Clear();
                            Console.WriteLine("Insira a data: (dd/mm/yyyy): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime dt))
                            {
                                Console.WriteLine(calc.InfoEmDataAleatoria(pessoa.DataNascimento, dt));
                            } 
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
            }
        }
    }
}