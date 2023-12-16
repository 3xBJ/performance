using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Frozen;
using static Performance.Analise.Constantes;

namespace Performance.Analise.Frozen;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
public class FrozenDictionaryPerf
{
    public Dictionary<int, bool> _dictionary;
    public FrozenDictionary<int, bool> _frozenDictionary;

    [Params(DEZ_MIL, CEM_MIL, UM_MILHAO)]
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
