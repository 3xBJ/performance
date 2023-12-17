using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Performance.Analise.Lists;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
public class AddOrAddRange
{
    private List<int> initialList = [];

    [Params(TEN_THOUSAND, HUNDRED_THOUSAND, ONE_MILLION, TEN_MILLION)]
    public int NumberOfIterations { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        initialList = Enumerable.Range(1, NumberOfIterations).ToList();
    }

    [Benchmark(Baseline = true)]
    public void SemInfo()
    {
        List<int> list = [];
        for (int i = 0; i < NumberOfIterations; i++)
        {
            list.Add(i);
        }
    }

    public void ComInfo()
    {
        List<int> list = new(NumberOfIterations);
        for (int i = 0; i < NumberOfIterations; i++)
        {
            list.Add(i);
        }
    }

    public void AddRangeSemInfo()
    {
        List<int> list = [];
        list.AddRange(initialList);
    }

    public void CreateList()
    {
        List<int> list = [.. initialList];
    }

    public void AddRangeComInfo()
    {
        List<int> list = new(NumberOfIterations);
        list.AddRange(initialList);
    }
}