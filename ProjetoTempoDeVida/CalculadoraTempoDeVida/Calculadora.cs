using System.Text;

namespace CalculadoraTempoDeVida
{
    public class Calculadora
    {
        public TempoDeVida CalculaTempoDeVida(DateTime dataNascimento)
        {
            TimeSpan diferenca = DateTime.Now - dataNascimento;
            return new TempoDeVida
            (
                (int)diferenca.TotalHours % 24,
                ((diferenca.Days % 365) % 30) % 7,
                (diferenca.Days % 365) / 7,
                (diferenca.Days % 365) / 30,
                diferenca.Days % 365
            );
        }

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

        public string ConcatenandoInformaces(TempoDeVida tempoDeVida)
        {
            return $"- {tempoDeVida.Anos} anos\n- {tempoDeVida.Meses} meses\n" +
                $"- {tempoDeVida.Semanas} semanas\n- {tempoDeVida.Dias} dias\n- {tempoDeVida.Horas} horas";
        }

        public string ImprimeInformacoes (string nome, DateTime dataNascimento)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("======================================================================");
            sb.AppendLine($"Olá {nome}. Você está programado(a) para viver até o dia {(dataNascimento.AddYears(100)).Day}" +
                $"de {ObterNomeDoMes(dataNascimento.AddYears(100))} de {dataNascimento.AddYears(100).Year}.");
            sb.AppendLine("----------------------------------------------------------------------");
            sb.AppendLine($"Idade atual: {IdadeAtual(dataNascimento)} anos.");
            sb.AppendLine($"Você já viveu:");
            sb.AppendLine(ConcatenandoInformaces(CalculaTempoDeVida(dataNascimento)));
            sb.AppendLine("");
            return sb.ToString();
        }

        public int IdadeAtual(DateTime dataNascimento)
        {
            return DateTime.Now.Year - dataNascimento.Year;
        }
    }
}