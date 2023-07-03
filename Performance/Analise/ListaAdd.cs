using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Performance.Analise.Constantes;

namespace Performance.Analise
{
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class ListaAdd
    {
        [Params(DEZ_MIL, CEM_MIL, UM_MILHAO, DEZ_MILHOES)]
        public int NumeroIteracoes { get; set; }

        private List<int> listaInicial = new();

        [GlobalSetup]
        public void Setup()
        {
            listaInicial = Enumerable.Range(1, NumeroIteracoes).ToList();
        }

        [Benchmark(Baseline = true)]
        public void SemInfo()
        {
            List<int> lista = new();
            for(int i = 0; i < NumeroIteracoes; i++)
            {
                lista.Add(i);
            }
        }

        public void ComInfo()
        {
            List<int> lista = new();
            for (int i = 0; i < NumeroIteracoes; i++)
            {
                lista.Add(i);
            }
        }

        public void AddRangeSemInfo()
        {
            List<int> lista = new();
            lista.AddRange(listaInicial);
        }

        public void AddRangeComInfo()
        {
            List<int> lista = new(NumeroIteracoes);
            lista.AddRange(listaInicial);
        }
    }
}