using System.Text;

namespace SegundaSemana
{
    class Jogador
    {
        private int id = 0;
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public Dictionary<string, List<int>> jogos = new Dictionary<string, List<int>>();


        public Jogador(string nome, double saldo)
        {
            Nome = nome;
            Saldo = saldo;
        }

        private void AtualizaSaldo(string nomeJogo)
        {
            if (nomeJogo == "Mega-Sena") Saldo -= 5.0;
            else if (nomeJogo == "Lotofácil") Saldo -= 3.0;
            else if (nomeJogo == "Quina") Saldo -= 2.5;
            else Saldo -= 3.0;//Lotomania



        }

        private bool VerificarSaldo(string nomeJogo)
        {
            if (nomeJogo == "Mega-Sena")
            {
                if (Saldo >= 5.0) return true;
                else return false;
            }
            else if (nomeJogo == "Lotofácil")
            {
                if (Saldo >= 3.0) return true;
                else return false;
            }
            else if (nomeJogo == "Quina")
            {
                if (Saldo >= 2.5) return true;
                else return false;
            }
            else  //(nomeJogo == "Lotomania")
            { 
                if (Saldo >= 3.0) return true;
                else return false;
            }
        }

        public void AdicionarJogo(string nomeJogo, List<int> jogo)
        {
            if (VerificarSaldo(nomeJogo))
            {
                jogos.Add($"{nomeJogo}{id.ToString("D2")}", jogo);
                id++;
                AtualizaSaldo(nomeJogo);
                Console.WriteLine($"Jogo adicionado com sucesso!\n" +
                    $"{nomeJogo}: {ImprimirJogo(jogo)}\n");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }

        }

        public void ListarJogos()
        {
            if (jogos.Count == 0) Console.WriteLine("Você ainda não realizou nenhum jogo.");
            else
            {
                Console.Clear();
                Console.WriteLine("Esses são seus jogos: ");
                foreach (var jogo in jogos)
                {
                    Console.WriteLine($"{jogo.Key} : {ImprimirJogo(jogo.Value)}");
                }
            }
        }

        public void RemoverJogo(string chaveParaRemover)
        {
            if (jogos.ContainsKey(chaveParaRemover))
            {
                jogos.Remove(chaveParaRemover);
                Console.WriteLine($"Jogo'{chaveParaRemover}' removido.");
            }
            else
            {
                Console.WriteLine($"Chave '{chaveParaRemover}' não encontrada no dicionário.");
            }

        }

        public string ImprimirJogo(List<int> jogo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            for (int i = 0; i < jogo.Count - 1; i++)
            {
                sb.Append(jogo[i] + ", ");
            }
            sb.Append(jogo[jogo.Count - 1] + " ]");
            return sb.ToString();
        }

    }
}
