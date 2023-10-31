using SegundaSemana;

Console.Write("Insira seu nome: ");
string nome = Console.ReadLine()!;

Console.Write("Informe quantos reais você tem para jogar: R$ ");
double totalDeReais = double.Parse(Console.ReadLine()!);

int valorDoJogo = 5;

int quantidadeDeJogos = (int)totalDeReais / valorDoJogo;

Console.WriteLine($"Olá, {nome}. Com seus R$ {totalDeReais.ToString("C2")} é possível realizar {quantidadeDeJogos} jogos.");
Console.WriteLine();
Console.WriteLine($"Aqui estão {quantidadeDeJogos} sugestões de jogos:");

SorteadorDeJogo s = new SorteadorDeJogo();

for (int i = 0; i < quantidadeDeJogos; i++)
{
    Console.WriteLine($"Jogo {i + 1}: {s.SortearJogo()}");
}