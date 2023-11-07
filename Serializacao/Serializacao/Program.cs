using System.Text.Json;


var pessoa = new Pessoa { Nome = "Jonas", Idade = 26 };

string jsonPessoa = JsonSerializer.Serialize(pessoa);
File.WriteAllText("pessoa.json", jsonPessoa);

string jsonPessoaInput = File.ReadAllText("pessoa.json");
Pessoa pessoaDesserializada = JsonSerializer.Deserialize<Pessoa>(jsonPessoaInput);

Console.WriteLine($"Nome: {pessoaDesserializada.Nome}");
Console.WriteLine($"Idade: {pessoaDesserializada.Idade}");

//======================================================================
Carro meuCarro = new Carro("Kwid", 2020);

string jsonCarro = JsonSerializer.Serialize(meuCarro);

File.WriteAllText("carro.json", jsonCarro);

string jsonCarroInput = File.ReadAllText("carro.json");
Carro carroDesserializado = JsonSerializer.Deserialize<Carro>(jsonCarroInput);

Console.WriteLine($"Modelo: {carroDesserializado.Modelo}");
Console.WriteLine($"Ano: {carroDesserializado.Ano}");


public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

}

public record Carro (string Modelo, int Ano);