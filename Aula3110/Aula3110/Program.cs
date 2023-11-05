string nome = "Jonas da Silva Rabelo";

bool resultado = nome.Contains("Jonas");
Console.WriteLine(resultado);

resultado = nome[0].Equals('J');

if (resultado) Console.WriteLine($"O nome {nome} começa com a letra 'J'");
else Console.WriteLine($"O nome {nome} não começa com a letra 'J'");

int ind = nome.IndexOf(" ") + 1;
string sobrenome = nome.Substring(ind, nome.Length - ind);

Console.WriteLine(sobrenome);

nome.