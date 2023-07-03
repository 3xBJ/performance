using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Performance.Analise.Constantes;

namespace Performance.Analise
{
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class BuscaOrdenada
    {
        private readonly Random random = new();
        private readonly List<int> listaOrdenada = new();

        [Params(DEZ_MIL, CEM_MIL, UM_MILHAO, DEZ_MILHOES, CEM_MILHOES)]
        public int NumeroElementos { get; set; }

        [IterationSetup]
        public void Setup()
        {
            listaOrdenada.Clear();
            for (int i = 0; i < NumeroElementos; i++)
            {
                listaOrdenada.Add(random.Next());
            }

            listaOrdenada.Sort();
        }

        [Benchmark(Baseline = true)]
        public void FindJaOrdenado() => listaOrdenada.Find(i => i == int.MinValue);

        [Benchmark]
        public void ListBinarySearchJaOrenada() => listaOrdenada.Find(i => i == int.MinValue);
    }
}
