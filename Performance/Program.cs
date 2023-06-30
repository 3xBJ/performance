// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Performance.Analise;

Console.WriteLine("Escolha qual teste rodar");
Console.WriteLine("1 - Busca");
Console.WriteLine("2 - Concatenacao");
Console.WriteLine("3 - Loops");

var a = Console.ReadLine();

if (!int.TryParse(a, out int numeroTeste))
{
    Console.WriteLine($"{a} não é um número de teste válido.");
    return;
}

_ = numeroTeste switch
{
    1 => BenchmarkRunner.Run<Busca>(),
    2 => BenchmarkRunner.Run<Concatenacao>(),
    3 => BenchmarkRunner.Run<Loops>(),
    _ => null
};
