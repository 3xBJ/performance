using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Frozen;

namespace Performance.Analise.Frozen;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
public class FrozenDictionaryPerf
{
    private Dictionary<int, bool> _dictionary;
    private FrozenDictionary<int, bool> _frozenDictionary;

    [Params(TEN_THOUSAND, HUNDRED_THOUSAND, ONE_MILLION)]
    public int ElementsNumber { get; set; }

    [IterationSetup]
    public void Setup()
    {
        _dictionary = [];
        for (int i = 0; i < ElementsNumber; i++)
        {
            _dictionary.Add(i, true);
        }

        _frozenDictionary = _dictionary.ToFrozenDictionary();
    }

    [Benchmark(Baseline = true)]
    public void Dictionary()
    {
        for (int i = 0; i < ElementsNumber; i++)
        {
            _dictionary.TryGetValue(i, out bool _);
        }
    }

    [Benchmark]
    public void FrozenDictionary()
    {
        for (int i = 0; i < ElementsNumber; i++)
        {
            _frozenDictionary.TryGetValue(i, out bool _);
        }
    }
}
