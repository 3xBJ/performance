using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Performance.Analise.Search;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
internal class NonOrderedSearch
{
    private readonly List<int> list = [];
    private readonly Random random = new();

    [Params(TEN_THOUSAND, HUNDRED_THOUSAND, ONE_MILLION, TEN_MILLION, HUNDRED_MILLION)]
    public int NumberOfElements { get; set; }

    [IterationSetup]
    public void Setup()
    {
        list.Clear();
        for (int i = 0; i < NumberOfElements; i++)
        {
            list.Add(random.Next());
        }
    }

    [Benchmark(Baseline = true)]
    public void LINQFirstOrDefault() => _ = list.FirstOrDefault(i => i == int.MinValue);

    [Benchmark]
    public void NonOrderedFind() => list.Find(i => i == int.MinValue);

    [Benchmark]
    public void OrderedFind()
    {
        list.Sort();
        list.Find(i => i == int.MinValue);
    }

    [Benchmark]
    public void OrderedBinarySearch()
    {
        list.Sort();
        list.Find(i => i == int.MinValue);
    }
}
