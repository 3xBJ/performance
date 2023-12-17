using BenchmarkDotNet.Running;
using Performance.Analise.Frozen;
using Performance.Analise.Lists;
using Performance.Analise.Loops;
using Performance.Analise.Search;
using Performance.Analise.Strings;

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
    1 => BenchmarkRunner.Run<OrderedSearch>(),
    2 => BenchmarkRunner.Run<NonOrderedSearch>(),
    3 => BenchmarkRunner.Run<Concatenation>(),
    4 => BenchmarkRunner.Run<ForForeachPerf>(),
    5 => BenchmarkRunner.Run<YieldOuReturn>(),
    6 => BenchmarkRunner.Run<YieldOrReturnMaterialized>(),
    7 => BenchmarkRunner.Run<FrozenDictionaryPerf>(),
    8 => BenchmarkRunner.Run<FrozenSetPerf>(),
    _ => null
};
