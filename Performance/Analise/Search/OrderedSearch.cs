using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Performance.Analise.Search;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
public class OrderedSearch
{
    private readonly Random random = new();
    private readonly List<int> orderedList = [];

    [Params(TEN_THOUSAND, HUNDRED_THOUSAND, ONE_MILLION, TEN_MILLION, HUNDRED_MILLION)]
    public int NumberOfElements { get; set; }

    [IterationSetup]
    public void Setup()
    {
        orderedList.Clear();
        for (int i = 0; i < NumberOfElements; i++)
        {
            orderedList.Add(random.Next());
        }

        orderedList.Sort();
    }

    [Benchmark(Baseline = true)]
    public void OrderedFind() => orderedList.Find(i => i == int.MinValue);

    [Benchmark]
    public void OrderedBinarySearch() => orderedList.Find(i => i == int.MinValue);
}
