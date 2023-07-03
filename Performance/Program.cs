// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Performance.Analise;

Console.WriteLine("Escolha qual teste rodar");
Console.WriteLine("1 - Busca Ordenada");
Console.WriteLine("2 - Busca Não Ordenada");
Console.WriteLine("3 - Concatenacao");
Console.WriteLine("4 - Loops");
Console.WriteLine("5 - Yield vs Return");

int numeroTeste = 0;
bool numeroValido = false;

while (!numeroValido)
{
    var a = Console.ReadLine();

    if (!int.TryParse(a, out numeroTeste) || 
        numeroTeste < 0 || 
        numeroTeste > 5)
    {
        Console.WriteLine($"{a} não é um número de teste válido.");
        return;
    }

    numeroValido = true;
}


_ = numeroTeste switch
{
    1 => BenchmarkRunner.Run<BuscaOrdenada>(),
    2 => BenchmarkRunner.Run<BuscaNaoOrdenada>(),
    3 => BenchmarkRunner.Run<Concatenacao>(),
    4 => BenchmarkRunner.Run<Loops>(),
    5 => BenchmarkRunner.Run<YieldOuReturn>(),
    _ => null
};
