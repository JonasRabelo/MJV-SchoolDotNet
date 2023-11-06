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




    }
}
