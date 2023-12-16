using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Performance.Analise.Constantes;

namespace Performance.Analise
{
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class YieldOuReturnMaterializado
    {
        [Params(DEZ_MIL, CEM_MIL, UM_MILHAO, DEZ_MILHOES)]
        public int NumeroIteracoes { get; set; }

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
}
