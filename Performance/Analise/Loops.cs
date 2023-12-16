using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Performance.Analise.Constantes;

namespace Performance.Analise
{
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class Loops
    {
        private readonly List<int> lista = new();

        [Params(DEZ_MIL, CEM_MIL, UM_MILHAO, DEZ_MILHOES, CEM_MILHOES)]
        public int NumeroIteracoes { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            lista.AddRange(Enumerable.Range(0, NumeroIteracoes));
        }

        [Benchmark]
        public void ForEach()
        {
            foreach(int i in lista)
            {

            }
        }

        [Benchmark]
        public void For()
        {
            for(int i =0; i < lista.Count; i++)
            {
               
            }
        }
    }
}
