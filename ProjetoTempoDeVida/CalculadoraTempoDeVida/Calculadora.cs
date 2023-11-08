using System.Security.Cryptography;
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
                Convert.ToInt32(diferenca.Days % 365.25) % 30,
                Convert.ToInt32(diferenca.Days % 365.25) / 30,
                Convert.ToInt32(diferenca.Days % 365.25)
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

        public string ConcatenandoInformaces(DateTime dataNascimento, DateTime dataAlvo)
        {
            TimeSpan diferenca = dataAlvo - dataNascimento;
            DateTime dataAtual = dataAlvo;

            DateTime dataAux = new DateTime(dataAtual.Year, dataAtual.Month - 1, dataNascimento.Day, 0, 0, 0);
            int dias = 0;
            int meses = (int)((diferenca.Days % 365.25) / 30.44);
            if (!(dataAlvo.Day == 14))
            {
                dias = Convert.ToInt32((dataAtual - dataAux).TotalDays);
                if (dias > 30)
                {
                    dias = dataAlvo.Day - dataNascimento.Day;
                }
                else if (dias == 30)
                {
                    meses += 1;
                    dias = 0;
                }
            }
            if (dias <= 1)
            {
                return ($"{(int)(diferenca.Days / 365.25)} anos, {meses} meses, {dias} dia e {diferenca.Hours} horas.");
            }
            else if (meses <= 1)
            {
                return ($"{(int)(diferenca.Days / 365.25)} anos, {meses} mês, {dias} dias e {diferenca.Hours} horas.");
            }
            else
            {
                return ($"{(int)(diferenca.Days / 365.25)} anos, {meses} meses, {dias} dias e {diferenca.Hours} horas.");
            }
        }

        public string ImprimeInformacoes(DateTime dataNascimento)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("======================================================================");
            sb.AppendLine($"Hoje, dia {DateTime.Now.Day} de {ObterNomeDoMes(DateTime.Now)}" +
                          $"de {DateTime.Now.Year}\n" + $"Sua Idade atual é de {IdadeAtual(dataNascimento, DateTime.Now)} anos.\nVocê já viveu: ");
            sb.AppendLine(ConcatenandoInformaces(dataNascimento, DateTime.Now) + "\n");
            return sb.ToString();
        }

        public string VerificaDataAtual(DateTime hoje, DateTime dataAux, DateTime dataNascimento)
        {
            if (hoje.Day == dataAux.Day && hoje.Month == dataAux.Month && hoje.Year == dataAux.Year)
            {
                return $"Hoje, dia {DateTime.Now.Day} de {ObterNomeDoMes(DateTime.Now)} de {DateTime.Now.Year}\n" +
                    $"Sua idade atual é de {IdadeAtual(dataNascimento, DateTime.Now)} anos.\nVocê já viveu: ";
            }
            else
            {
                return $"No dia {dataAux.Day} de {ObterNomeDoMes(dataAux)} de {dataAux.Year}\n" +
                    $"Você terá {IdadeAtual(dataNascimento, dataAux)} anos de idade.\nVocê já terá vivido: ";
            }
        }

        public int IdadeAtual(DateTime dataNascimento, DateTime DataAux)
        {
            return DataAux.Year - dataNascimento.Year;
        }

        public string InfoEmDataAleatoria(DateTime dataNascimento, DateTime dataFutura)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("======================================================================");
            sb.AppendLine(VerificaDataAtual(DateTime.Now, dataFutura, dataNascimento));
            sb.AppendLine(ConcatenandoInformaces(dataNascimento, dataFutura) + "\n");
            return sb.ToString();
        }
    }
}