using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Iniciando coleta de dados...");

        var dadosMeteorologicos = await ColetarDadosMeteorologicos();

        Console.WriteLine("\nRelatório Consolidado:");
        Console.WriteLine($"Média geral da temperatura: {dadosMeteorologicos.TemperaturaMedia:F2}°C");

        // Exibindo as temperaturas mínimas, máximas, moda, mediana e média de cada cidade
        foreach (var resultado in dadosMeteorologicos.Resultados)
        {
            Console.WriteLine($"{resultado.Localizacao}:");
            Console.WriteLine($"  Temperatura Mínima: {resultado.TemperaturaMinima:F2}°C");
            Console.WriteLine($"  Temperatura Máxima: {resultado.TemperaturaMaxima:F2}°C");
            Console.WriteLine($"  Temperatura Média: {resultado.Temperatura:F2}°C");
            Console.WriteLine($"  Temperatura Moda: {CalcularModa(resultado.Temperaturas):F2}°C");
            Console.WriteLine($"  Temperatura Mediana: {CalcularMediana(resultado.Temperaturas):F2}°C");
        }

        // Salvando os dados em arquivos para cada cidade
        await SalvarTemperaturasEmArquivos(dadosMeteorologicos.Resultados);
    }

    static async Task<DadosMeteorologicos> ColetarDadosMeteorologicos()
    {
        var cidades = new List<string> { "São Paulo", "Rio de Janeiro", "Belo Horizonte", "Salvador", "Fortaleza", "Curitiba", "Manaus", "Recife", "Porto Alegre", "Brasília" };
        var fontes = new List<Func<Task<DadoMeteorologico>>>(); 
        var random = new Random();

        // Usando Parallel.ForEach para execução concorrente sobre as cidades
        Parallel.ForEach(cidades, cidade =>
        {
            var temperaturas = Enumerable.Range(0, 10000).Select(_ => random.Next(0, 500) / 10.0).ToList(); // 10.000 registros de temperaturas aleatórias
            int delay = random.Next(500, 2000); // Tempo de resposta variável
            fontes.Add(() => ObterDadosMeteorologicos(cidade, temperaturas, delay)); // Adicionando as fontes de dados
        });

        // Executando as tarefas simultaneamente com Task.WhenAll
        var tarefas = fontes.Select(fonte => Task.Run(() => fonte())); // Computação concorrente
        var resultados = await Task.WhenAll(tarefas);

        return new DadosMeteorologicos
        {
            TemperaturaMedia = resultados.Any() ? resultados.AsParallel().Average(r => r.Temperatura) : 0.0,
            Locais = resultados.Select(r => r.Localizacao).ToList(),
            Resultados = resultados.ToList()  // Armazenando os resultados completos, não só os locais
        };
    }

    static async Task<DadoMeteorologico> ObterDadosMeteorologicos(string nomeBase, List<double> temperaturas, int delay)
    {
        await Task.Delay(delay); // Simulando tempo de resposta da base
        double mediaTemperatura = temperaturas.Any() ? temperaturas.AsParallel().Average() : 0.0; // Computação paralela no cálculo
        double temperaturaMinima = temperaturas.Any() ? temperaturas.Min() : 0.0;
        double temperaturaMaxima = temperaturas.Any() ? temperaturas.Max() : 0.0;

        Console.WriteLine($"{nomeBase} respondeu com média: {mediaTemperatura:F2}°C");

        return new DadoMeteorologico
        {
            Temperatura = mediaTemperatura,
            TemperaturaMinima = temperaturaMinima,
            TemperaturaMaxima = temperaturaMaxima,
            Localizacao = nomeBase,
            Temperaturas = temperaturas
        };
    }

    // Método para salvar as temperaturas em arquivos
    static async Task SalvarTemperaturasEmArquivos(List<DadoMeteorologico> resultados)
    {
        foreach (var resultado in resultados)
        {
            // Gerando o nome do arquivo com base na cidade
            string nomeArquivo = $"{resultado.Localizacao}.txt"; 

            // Salvando as temperaturas no arquivo
            string dados = $"{resultado.Localizacao} - Temperaturas:\n" + string.Join("\n", resultado.Temperaturas.Select(t => t.ToString("F2")));
            await File.WriteAllTextAsync(nomeArquivo, dados);

            Console.WriteLine($"Temperaturas de {resultado.Localizacao} salvas em {nomeArquivo}");
        }
    }

    // Método para calcular a Moda
    static double CalcularModa(List<double> temperaturas)
    {
        var grupos = temperaturas.GroupBy(t => t)
                                 .OrderByDescending(g => g.Count()) // Ordena pelo número de ocorrências
                                 .ThenBy(g => g.Key) // Em caso de empate, pega o valor mais baixo
                                 .FirstOrDefault();

        return grupos?.Key ?? 0.0;
    }

    // Método para calcular a Mediana
    static double CalcularMediana(List<double> temperaturas)
    {
        var listaOrdenada = temperaturas.OrderBy(t => t).ToList();
        int count = listaOrdenada.Count;

        if (count % 2 == 1)
        {
            // Se o número de elementos for ímpar, a mediana é o valor do meio
            return listaOrdenada[count / 2];
        }
        else
        {
            // Se for par, a mediana é a média dos dois valores centrais
            return (listaOrdenada[(count / 2) - 1] + listaOrdenada[count / 2]) / 2.0;
        }
    }
}

class DadoMeteorologico
{
    public double Temperatura { get; set; } = 0.0;
    public double TemperaturaMinima { get; set; } = 0.0;  // Temperatura mínima
    public double TemperaturaMaxima { get; set; } = 0.0;  // Temperatura máxima
    public string Localizacao { get; set; } = string.Empty;
    public List<double> Temperaturas { get; set; } = new List<double>();  // Lista das temperaturas
}

class DadosMeteorologicos
{
    public double TemperaturaMedia { get; set; } = 0.0;
    public List<string> Locais { get; set; } = new List<string>();
    public List<DadoMeteorologico> Resultados { get; set; } = new List<DadoMeteorologico>(); // Agora armazenando todos os dados
}
