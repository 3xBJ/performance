using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Frozen;
using static Performance.Analise.Constantes;

namespace Performance.Analise.Frozen;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
public class FrozenSetPerf
{
    public HashSet<int> _set;
    public FrozenSet<int> _frozenSet;

    [Params(DEZ_MIL, CEM_MIL, UM_MILHAO)]
    public int ElementsNumber { get; set; }

    [IterationSetup]
    public void Setup()
    {
        _set = [];
        for (int i = 0; i < ElementsNumber; i++)
        {
            _set.Add(i);
        }

        _frozenSet = _set.ToFrozenSet();
    }

    [Benchmark(Baseline = true)]
    public void Set()
    {
        for (int i = 0; i < ElementsNumber; i++)
        {
            _set.Contains(i);
        }
    }

    [Benchmark]
    public void FrozenSet()
    {
        for (int i = 0; i < ElementsNumber; i++)
        {
            _frozenSet.Contains(i);
        }
    }
}
