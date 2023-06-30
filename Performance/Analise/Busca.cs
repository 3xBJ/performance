using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Performance.Analise.Constantes;

namespace Performance.Analise
{
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    [MemoryDiagnoser]
    [RPlotExporter]
    public class Busca
    {
        private readonly Random random = new();

        private readonly List<int> lista = new();
        private readonly List<int> listaOrdenada = new();

        [Params(DEZ_MIL, CEM_MIL, UM_MILHAO, DEZ_MILHOES, CEM_MILHOES)]
        public int NumeroElementos { get; set; }

        [IterationSetup]
        public void Setup()
        {
            lista.Clear();
            for (int i = 0; i < NumeroElementos; i++)
            {
                lista.Add(random.Next());
            }

            listaOrdenada.Sort();
        }

        [Benchmark(Baseline = true)]
        public void LINQFirstOrDefault() => _ = lista.FirstOrDefault(i => i == int.MinValue);

        [Benchmark]
        public void FindSemOrdenar() => lista.Find(i => i == int.MinValue);

        [Benchmark]
        public void FindOrdenando()
        {
            lista.Sort();
            lista.Find(i => i == int.MinValue);
        }

        [Benchmark]
        public void FindJaOrdenado() => listaOrdenada.Find(i => i == int.MinValue);

        [Benchmark]
        public void BinarySearchOrdenando()
        {
            lista.Sort();
            lista.Find(i => i == int.MinValue);
        }

        [Benchmark]
        public void ListBinarySearchJaOrenada() => listaOrdenada.Find(i => i == int.MinValue);
    }
}
