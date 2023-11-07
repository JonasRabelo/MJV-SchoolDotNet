using System.Collections.Generic;

namespace LotericaSorteador
{
    public interface IJogador
    {
        string Nome { get; set; }
        double Saldo { get; set; }

        void AdicionarJogo(string nomeJogo, List<int> jogo);
        void ListarJogos();
        void RemoverJogo(string chaveParaRemover);
        string ImprimirJogo(List<int> jogo);
    }
}