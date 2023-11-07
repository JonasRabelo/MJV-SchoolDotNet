namespace LotericaSorteador
{
    public class Loterica
    {
        public int[] NumerosLoteria;

        private void PreencherLista(int limite)
        {
            NumerosLoteria = new int[limite];
            for (int i = 0; i < NumerosLoteria.Length; i++)
            {
                NumerosLoteria[i] = i + 1;
            }
        }

        public List<int> JogarMegaSena()
        {
            PreencherLista(60);
            return SortearJogo(6);
        }

        public List<int> JogarLotofacil()
        {
            PreencherLista(25);
            return SortearJogo(15);
        }

        public List<int> JogarQuina()
        {
            PreencherLista(80);
            return SortearJogo(5);
        }

        public List<int> JogarLotomania()
        {
            PreencherLista(100);
            return SortearJogo(50);
        }

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
            jogo.Sort();
            return jogo;
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


    }
}
