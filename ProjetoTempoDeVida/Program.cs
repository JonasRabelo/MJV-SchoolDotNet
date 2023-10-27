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

            int idadeAtual = dt.Year - dataNasc.Year;

            // Adicione 100 anos à data de nascimento
            DateTime dataFalecimento = dataNasc.AddYears(100);

            Console.WriteLine("======================================================================");

            Console.WriteLine($"Olá {nome}. Você está programado(a) para viver até o dia {dataFalecimento.Day} de {ObterNomeDoMes(dataFalecimento)} de {dataFalecimento.Year}.");
            Console.WriteLine();
            Console.WriteLine($"Idade atual: {idadeAtual} anos.");
            Console.WriteLine($"Você já viveu:");
            Console.WriteLine($"- {CalculaTotalDeDias(dt, dataNasc) * 24} horas.");
            Console.WriteLine($"- {CalculaTotalDeDias(dt, dataNasc)} dias.");
            Console.WriteLine($"- {CalculaTotalDeSemanas(dt, dataNasc)} semanas.");
            Console.WriteLine($"- {CalculaTotalDeMeses(dt, dataNasc)} meses."); // Aproximadamente meses
            Console.WriteLine($"- {idadeAtual} anos.");
            Console.WriteLine("======================================================================");
            Console.WriteLine($"Você ainda viverá por:");
            Console.WriteLine($"- {CalculaTotalDeDias(dataFalecimento, dt) * 24} horas");
            Console.WriteLine($"- {CalculaTotalDeDias(dataFalecimento, dt)} dias");
            Console.WriteLine($"- {CalculaTotalDeSemanas(dataFalecimento, dt)} semanas");
            Console.WriteLine($"- {CalculaTotalDeMeses(dataFalecimento, dt)} meses");
            Console.WriteLine($"- {(int)((dataFalecimento - dt).TotalDays / 365.25)} anos");

        }
        else
        {
            Console.WriteLine("Data de nascimento inválida. Use o formato dd/mm/yyyy.");
        }
    }

    static string ObterNomeDoMes(DateTime data)
    {
        // Use o formato "MMMM" para obter o nome completo do mês em português
        return data.ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
    }

    static int CalculaTotalDeMeses(DateTime DataPosterior, DateTime DataAnterior)
    {
        // Cálculo da idade em meses (aproximado)
        int idadeMeses = (DataPosterior.Year - DataAnterior.Year) * 12 + DataPosterior.Month - DataAnterior.Month;
        return idadeMeses;
    }

    static int CalculaTotalDeSemanas(DateTime DataPosterior, DateTime DataAnterior)
    {
        // Cálculo da idade em semanas (aproximado)
        int idadeSemanas = (int)CalculaTotalDeDias(DataPosterior, DataAnterior) / 7;
        return idadeSemanas;
    }

    static int CalculaTotalDeDias(DateTime DataPosterior, DateTime DataAnterior)
    {
        // Cálculo da idade em dias
        int idadeDias = (int)(DataPosterior - DataAnterior).TotalDays;
        return idadeDias;
    }
}

