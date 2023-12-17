using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text;

namespace Performance.Analise.Strings;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[MemoryDiagnoser]
[RPlotExporter]
public class Concatenation
{
    [Params(TWO, FIVE, ONE_HUNDRED, ONE_THOUSAND, ONE_HUNDRED)]
    public int NumberOfElements { get; set; }

    public void ConcatenaFormat()
    {

    }

    public void ConcatenaCifrao()
    {

    }

    [Benchmark]
    public void ConcatenationWithPlus()
    {
        string s = string.Empty;
        for (int i = 0; i < NumberOfElements; i++)
        {
            s += i;
        }
    }

    [Benchmark]
    public void ConcatenationWithStringBuilder()
    {
        StringBuilder sb = new();

        for (int i = 0; i < NumberOfElements; i++)
        {
            sb.Append(i);
        }

        sb.ToString();
    }
}
