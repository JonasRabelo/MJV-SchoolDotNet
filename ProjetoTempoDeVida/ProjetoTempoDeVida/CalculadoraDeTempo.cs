
namespace ProjetoTempoDeVida
{
    class CalculadoraDeTempo
    {
        /// <summary>
        /// Obtém o nome completo do mês em português a partir de uma data.
        /// </summary>
        /// <param name="data">A data da qual se deseja obter o nome do mês.</param>
        /// <returns>O nome do mês por extenso.</returns>
        public string ObterNomeDoMes(DateTime data)
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
        public int CalculaTotalDeMeses(DateTime DataPosterior, DateTime DataAnterior)
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
        public int CalculaTotalDeSemanas(DateTime DataPosterior, DateTime DataAnterior)
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
        public int CalculaTotalDeDias(DateTime DataPosterior, DateTime DataAnterior)
        {
            // Cálculo da idade em dias
            int idadeDias = (int)(DataPosterior - DataAnterior).TotalDays;
            return idadeDias;
        }

        public void ImprimirInformacoes(int horas, int dias, int semanas, int meses, int anos)
        {
            Console.WriteLine($"- {horas} horas");
            Console.WriteLine($"- {dias} dias");
            Console.WriteLine($"- {semanas} semanas");
            Console.WriteLine($"- {meses} meses");
            Console.WriteLine($"- {anos} anos");
        }
    }
}
