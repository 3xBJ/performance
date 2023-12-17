using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Performance.Analise.Lists;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
public class YieldOrReturnMaterialized
{
    [Params(TEN_THOUSAND, HUNDRED_THOUSAND, ONE_MILLION, TEN_MILLION)]
    public int NumberOfIterations { get; set; }

    [Benchmark]
    public void YieldReturn()
    {
        _ = GetYield().ToList();
    }

    [Benchmark(Baseline = true)]
    public void Return()
    {
        _ = GetList();
    }

    public IEnumerable<ObjWithNumber> GetYield()
    {
        for (int i = 0; i < NumberOfIterations; i++)
        {
            yield return new ObjWithNumber(i);
        }
    }


    public List<ObjWithNumber> GetList()
    {
        List<ObjWithNumber> list = new(NumberOfIterations);
        for (int i = 0; i < NumberOfIterations; i++)
        {
            list.Add(new ObjWithNumber(i));
        }

        return list;
    }
}
