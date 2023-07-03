using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Performance.Analise.Constantes;

namespace Performance.Analise
{
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class YieldOuReturn
    {
        [Params(DEZ_MIL, CEM_MIL, UM_MILHAO, DEZ_MILHOES)]
        public int NumeroIteracoes { get; set; }

        [Benchmark]
        public void YieldReturn()
        {
            ObjWithNumber a;
            foreach (var obj in GetYield())
            {
                a = obj;
            }
        }

        [Benchmark(Baseline = true)]
        public void Return()
        {
            ObjWithNumber a;
            foreach (var obj in GetList())
            {
                a = obj;
            }
        }

        public IEnumerable<ObjWithNumber> GetYield()
        {
            for (int i = 0; i < NumeroIteracoes; i++)
            {
                yield return new ObjWithNumber(i);
            }
        }


        public List<ObjWithNumber> GetList()
        {
            List<ObjWithNumber> list = new(NumeroIteracoes);
            for (int i = 0; i < NumeroIteracoes; i++)
            {
                list.Add(new ObjWithNumber(i));
            }

            return list;
        }
    }

    public class ObjWithNumber
    {
        public ObjWithNumber(int i) => Number = i;
        public int Number { get; }
    }
}
