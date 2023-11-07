namespace LotericaSorteador
{
    public class Loterica
    {
        public int[] NumerosLoteria;

        /// <summary>
        /// Preenche a lista de números da loteria com números sequenciais até um limite.
        /// </summary>
        /// <param name="limite">O tamanho para preencher a lista.</param>
        private void PreencherLista(int limite)
        {
            NumerosLoteria = new int[limite];
            for (int i = 0; i < NumerosLoteria.Length; i++)
            {
                NumerosLoteria[i] = i + 1;
            }
        }

        /// <summary>
        /// Gera um jogo da Mega-Sena.
        /// </summary>
        /// <returns>Uma lista de 6 números sorteados.</returns>
        public List<int> JogarMegaSena()
        {
            PreencherLista(60);
            return SortearJogo(6);
        }

        /// <summary>
        /// Gera um jogo da Lotofácil.
        /// </summary>
        /// <returns>Uma lista de 15 números sorteados.</returns>
        public List<int> JogarLotofacil()
        {
            PreencherLista(25);
            return SortearJogo(15);
        }

        /// <summary>
        /// Gera um jogo da Quina.
        /// </summary>
        /// <returns>Uma lista de 5 números sorteados.</returns>
        public List<int> JogarQuina()
        {
            PreencherLista(80);
            return SortearJogo(5);
        }

        /// <summary>
        /// Gera um jogo da Lotomania.
        /// </summary>
        /// <returns>Uma lista de 50 números sorteados.</returns>
        public List<int> JogarLotomania()
        {
            PreencherLista(100);
            return SortearJogo(50);
        }

        /// <summary>
        /// Sorteia um jogo com a quantidade especificada de números.
        /// </summary>
        /// <param name="qtdNumeros">A quantidade de números a serem sorteados.</param>
        /// <returns>Uma lista de números sorteados.</returns>
        public List<int> SortearJogo(int qtdNumeros)
        {
            Random random = new Random();
            List<int> jogo = new List<int>();
            for (int i = 0; i < qtdNumeros; i++)
            {
                while (true)
                {
                    int numeroEscolhido = NumerosLoteria[random.Next(0, NumerosLoteria.Length)];

                    if (jogo.Count() > 0)
                    {
                        if (!jogo.Contains(numeroEscolhido))
                        {
                            jogo.Add(numeroEscolhido);
                            break;
                        }
                    }
                    else
                    {
                        jogo.Add(numeroEscolhido);
                    }
                }
            }
            jogo.Sort(); // Ordena os números em ordem crescente
            return jogo;
        }

        /// <summary>
        /// Serializa os dados para um arquivo.
        /// </summary>
        /// <param name="dados">Os dados a serem serializados.</param>
        public void SerializarDados(string dados)
        {
            try
            {
                // Salva os dados em um arquivo chamado "db.txt" no diretório do programa
                File.WriteAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.FullName, "db.txt"), dados);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }

        /// <summary>
        /// Lê os dados de um arquivo e os divide em um array de strings.
        /// </summary>
        /// <returns>Um array de strings contendo os dados lidos.</returns>
        public string[] LerDados()
        {
            try
            {
                // Lê os dados do arquivo "db.txt" no diretório do programa e os divide usando " | " como separador
                return File.ReadAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.FullName, "db.txt")).Split(" | ");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado.");
                return new string[] { };
            }
        }
    }
}
