namespace SegundaSemana
{
    class SorteadorDeJogo
    {
        public int[] NumerosLoteria = new int[60];


        public SorteadorDeJogo()
        {
            PreencherLista();
        }

        private void PreencherLista()
        {
            for (int i = 0; i < NumerosLoteria.Length; i++)
            {
                NumerosLoteria[i] = i + 1;
            }
        }

        public string SortearJogo()
        {
            Random random = new Random();
            int[] jogo = new int[6];

            for (int i = 0; i < 6; i++)
            {
                while (true)
                {
                    int numeroEscolhido = NumerosLoteria[random.Next(0, NumerosLoteria.Length)];

                    if (jogo.Length > 0)
                    {
                        if (!jogo.Contains(numeroEscolhido))
                        {
                            jogo[i] = numeroEscolhido;
                            break;
                        }
                    }
                    else
                    {
                        jogo[i] = numeroEscolhido;
                    }
                }
                
            }
            Array.Sort(jogo);
            return string.Join(", ", jogo);
        }
    }
}
