using System;

class Program
{
    static void Main()
    {
        Console.Write("Informe seu nome: ");
        string nome = Console.ReadLine();

        Console.Write("Informe sua data de nascimento (no formato dd/mm/yyyy): ");
        string dataNascimento = Console.ReadLine();

        if (DateTime.TryParse(dataNascimento, out DateTime dataNasc))
        {
            DateTime dt = DateTime.Now;

            // Calcula a idade atual do usuário.
            int idadeAtual = dt.Year - dataNasc.Year;

            // Adicione 100 anos à data de nascimento
            DateTime dataFalecimento = dataNasc.AddYears(100);

            Console.WriteLine("======================================================================");
            // Imprime informações sobre a data de falecimento.
            Console.WriteLine($"Olá {nome}. Você está programado(a) para viver até o dia {dataFalecimento.Day} de {ObterNomeDoMes(dataFalecimento)} de {dataFalecimento.Year}.");
            Console.WriteLine();
            // Imprime informações sobre a idade atual.
            Console.WriteLine($"Idade atual: {idadeAtual} anos.");
            Console.WriteLine($"Você já viveu:");
            Console.WriteLine($"- {CalculaTotalDeDias(dt, dataNasc) * 24} horas.");
            Console.WriteLine($"- {CalculaTotalDeDias(dt, dataNasc)} dias.");
            Console.WriteLine($"- {CalculaTotalDeSemanas(dt, dataNasc)} semanas.");
            Console.WriteLine($"- {CalculaTotalDeMeses(dt, dataNasc)} meses."); // Aproximadamente meses
            Console.WriteLine($"- {idadeAtual} anos.");
            Console.WriteLine("======================================================================");
            // Imprime informações sobre o tempo restante de vida.
            Console.WriteLine($"Você ainda viverá por:");
            Console.WriteLine($"- {CalculaTotalDeDias(dataFalecimento, dt) * 24} horas");
            Console.WriteLine($"- {CalculaTotalDeDias(dataFalecimento, dt)} dias");
            Console.WriteLine($"- {CalculaTotalDeSemanas(dataFalecimento, dt)} semanas");
            Console.WriteLine($"- {CalculaTotalDeMeses(dataFalecimento, dt)} meses");
            Console.WriteLine($"- {(int)((dataFalecimento - dt).TotalDays / 365.25)} anos");

        }
        else
        {
            // Mensagem de erro se a data de nascimento for inválida.
            Console.WriteLine("Data de nascimento inválida. Use o formato dd/mm/yyyy.");
        }
    }

    /// <summary>
    /// Obtém o nome completo do mês em português a partir de uma data.
    /// </summary>
    /// <param name="data">A data da qual se deseja obter o nome do mês.</param>
    /// <returns>O nome do mês por extenso.</returns>
    static string ObterNomeDoMes(DateTime data)
    {
        // Use o formato "MMMM" para obter o nome completo do mês em português
        return data.ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
    }

    /// <summary>
    /// Calcula o total de meses entre duas datas.
    /// </summary>
    /// <param name="DataPosterior">A data mais recente.</param>
    /// <param name="DataAnterior">A data mais antiga.</param>
    /// <returns>O total de meses entre as duas datas (aproximado).</returns>
    static int CalculaTotalDeMeses(DateTime DataPosterior, DateTime DataAnterior)
    {
        // Cálculo da idade em meses (aproximado)
        int idadeMeses = (DataPosterior.Year - DataAnterior.Year) * 12 + DataPosterior.Month - DataAnterior.Month;
        return idadeMeses;
    }

    /// <summary>
    /// Calcula o total de semanas entre duas datas.
    /// </summary>
    /// <param name="DataPosterior">A data mais recente.</param>
    /// <param name="DataAnterior">A data mais antiga.</param>
    /// <returns>O total de semanas entre as duas datas (aproximado).</returns>
    static int CalculaTotalDeSemanas(DateTime DataPosterior, DateTime DataAnterior)
    {
        // Cálculo da idade em semanas (aproximado)
        int idadeSemanas = (int)CalculaTotalDeDias(DataPosterior, DataAnterior) / 7;
        return idadeSemanas;
    }

    /// <summary>
    /// Calcula o total de dias entre duas datas.
    /// </summary>
    /// <param name="DataPosterior">A data mais recente.</param>
    /// <param name="DataAnterior">A data mais antiga</param>
    /// <returns>O total de dias entre as duas datas.</returns>
    static int CalculaTotalDeDias(DateTime DataPosterior, DateTime DataAnterior)
    {
        // Cálculo da idade em dias
        int idadeDias = (int)(DataPosterior - DataAnterior).TotalDays;
        return idadeDias;
    }
}

