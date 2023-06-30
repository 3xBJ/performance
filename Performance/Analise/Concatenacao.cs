using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text;

namespace Performance.Analise
{
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class Concatenacao
    {
        [Params(2, 5, 10, 100, 1000, 100000)]
        public int NumeroElementos { get; set; }

        public void ConcatenaFormat()
        {

        }

        public void ConcatenaCifrao()
        {

        }

        [Benchmark]
        public void ConcatenaMais()
        {
            string s = string.Empty;
            for (int i = 0; i < NumeroElementos; i++)
            {
                s += i;
            }
        }

        [Benchmark]
        public void ConcatenaStringBuilder()
        {
            StringBuilder sb = new();

            for (int i = 0; i < NumeroElementos; i++)
            {
                sb.Append(i);
            }

            sb.ToString();
        }
    }
}
