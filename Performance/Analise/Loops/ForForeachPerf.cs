using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Performance.Analise.Loops;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
public class ForForeachPerf
{
    private readonly List<int> list = [];

    [Params(TEN_THOUSAND, HUNDRED_THOUSAND, ONE_MILLION, TEN_MILLION, HUNDRED_MILLION)]
    public int InteractionNumber { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        list.AddRange(Enumerable.Range(0, InteractionNumber));
    }

    [Benchmark]
    public void ForEach()
    {
        foreach (int i in list)
        {

        }
    }

    [Benchmark]
    public void For()
    {
        for (int i = 0; i < list.Count; i++)
        {

        }
    }
}
