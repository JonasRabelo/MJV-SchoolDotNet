using System;
using System.Collections.Generic;
using System.Text;
using LotericaSorteador;
namespace SegundaSemana
{
    public class Jogador
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        // Dicionário que armazena os jogos do jogador, com o nome do jogo como chave e os números selecionados como valor.
        public Dictionary<string, List<int>> jogos { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe Jogador com o nome e saldo iniciais.
        /// </summary>
        /// <param name="nome">Nome do jogador.</param>
        /// <param name="saldo">Saldo inicial do jogador.</param>
        public Jogador(string nome, double saldo)
        {
            id = 0;
            Nome = nome;
            Saldo = saldo;
            jogos = new Dictionary<string, List<int>>();
        }

        /// <summary>
        /// Atualiza o saldo do jogador com base no nome do jogo.
        /// </summary>
        /// <param name="nomeJogo">Nome do jogo.</param>
        private void AtualizaSaldo(string nomeJogo)
        {
            if (nomeJogo == "Mega-Sena") Saldo -= 5.0;
            else if (nomeJogo == "Lotofácil") Saldo -= 3.0;
            else if (nomeJogo == "Quina") Saldo -= 2.5;
            else Saldo -= 3.0; // Lotomania
        }

        /// <summary>
        /// Verifica se o jogador tem saldo suficiente para jogar um determinado jogo.
        /// </summary>
        /// <param name="nomeJogo">Nome do jogo.</param>
        /// <returns>Verdadeiro se o saldo for suficiente; caso contrário, falso.</returns>
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
            else
            {
                if (Saldo >= 3.0) return true;
                else return false;
            }
        }

        /// <summary>
        /// Adiciona um jogo ao dicionário de jogos do jogador, se o saldo for suficiente.
        /// </summary>
        /// <param name="nomeJogo">Nome do jogo.</param>
        /// <param name="jogo">Lista de números do jogo.</param>
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

        /// <summary>
        /// Lista os jogos do jogador no console.
        /// </summary>
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

        /// <summary>
        /// Remove um jogo do dicionário de jogos do jogador com base na chave fornecida.
        /// </summary>
        /// <param name="chaveParaRemover">Chave do jogo a ser removido.</param>
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

        /// <summary>
        /// Converte uma lista de números em uma representação de string formatada.
        /// </summary>
        /// <param name="jogo">Lista de números do jogo.</param>
        /// <returns>String formatada representando o jogo.</returns>
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

        /// <summary>
        /// Adiciona saldo à conta do jogador.
        /// </summary>
        /// <param name="valor">O valor a ser adicionado ao saldo.</param>
        public void AdicionarSaldo(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"Saldo atualizado: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("O valor a ser adicionado deve ser maior que zero.");
            }
        }
    }
}
