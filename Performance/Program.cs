// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Performance.Analise;
using Performance.Analise.Frozen;

Console.WriteLine("Escolha qual teste rodar");
Console.WriteLine("1 - Busca Ordenada");
Console.WriteLine("2 - Busca Não Ordenada");
Console.WriteLine("3 - Concatenacao");
Console.WriteLine("4 - Loops");
Console.WriteLine("5 - Yield vs Return");
Console.WriteLine("6 - Yield Materializado vs Return");
Console.WriteLine("7 - Frozen Dictionary");
Console.WriteLine("8 - Frozen Set");

int numeroTeste = 0;

var a = Console.ReadLine();
_ = int.TryParse(a, out numeroTeste);

_ = numeroTeste switch
{
    1 => BenchmarkRunner.Run<BuscaOrdenada>(),
    2 => BenchmarkRunner.Run<BuscaNaoOrdenada>(),
    3 => BenchmarkRunner.Run<Concatenacao>(),
    4 => BenchmarkRunner.Run<Loops>(),
    5 => BenchmarkRunner.Run<YieldOuReturn>(),
    6 => BenchmarkRunner.Run<YieldOuReturnMaterializado>(),
    7 => BenchmarkRunner.Run<FrozenDictionaryPerf>(),
    8 => BenchmarkRunner.Run<FrozenSetPerf>(),
    _ => null
};
