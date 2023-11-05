using ProjetoTempoDeVida;
try
{
    CalculadoraDeTempo calc = new CalculadoraDeTempo();
    Console.Write("Informe seu nome: ");
    string nome = Console.ReadLine()!;

    Console.Write("Informe sua data de nascimento (no formato dd/mm/yyyy): ");

    if (DateTime.TryParse(Console.ReadLine()!, out DateTime dataNasc))
    {
        DateTime dt = DateTime.Now;

        // Calcula a idade atual do usuário.
        int idadeAtual = dt.Year - dataNasc.Year;

        // Adicione 100 anos à data de nascimento
        DateTime dataFalecimento = dataNasc.AddYears(100);

        Console.WriteLine("======================================================================");
        // Imprime informações sobre a data de falecimento.
        Console.WriteLine($"Olá {nome}. Você está programado(a) para viver até o dia {dataFalecimento.Day} de {calc.ObterNomeDoMes(dataFalecimento)} de {dataFalecimento.Year}.");
        Console.WriteLine();
        // Imprime informações sobre a idade atual.
        Console.WriteLine($"Idade atual: {idadeAtual} anos.");
        Console.WriteLine($"Você já viveu:");
        calc.ImprimirInformacoes(
            calc.CalculaTotalDeDias(dt, dataNasc) * 24,
            calc.CalculaTotalDeDias(dt, dataNasc),
            calc.CalculaTotalDeSemanas(dt, dataNasc),
            calc.CalculaTotalDeMeses(dt, dataNasc),
            idadeAtual
            );
        Console.WriteLine("======================================================================");
        // Imprime informações sobre o tempo restante de vida.
        calc.ImprimirInformacoes(
            calc.CalculaTotalDeDias(dataFalecimento, dt) * 24,
            calc.CalculaTotalDeDias(dataFalecimento, dt),
            calc.CalculaTotalDeSemanas(dataFalecimento, dt),
            calc.CalculaTotalDeMeses(dataFalecimento, dt),
            (int)((dataFalecimento - dt).TotalDays / 365.25)
            );
    }
    else
    {
        // Mensagem de erro se a data de nascimento for inválida.
        throw new FormatException("Formato de Data Inválida!");
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