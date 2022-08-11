// See https://aka.ms/new-console-template for more information
using FeatureHub.Console.Injection;
using FeatureHub.Console.UseCases.Sum;
using FeatureHubSDK;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.ConfigHub();
        services.RegisterCases();
    })
    .Build();

var usecase = host.Services.GetService<ISumUseCase>();
var config = host.Services.GetService<IFeatureHubConfig>();

var soma = usecase.Sum(10, 10);

Console.WriteLine($"Valor da soma: {soma}");
//Main(config);

await host.RunAsync();

static void Main(IFeatureHubConfig config)
{
    
    Console.WriteLine($"Server evaluated {config.ServerEvaluation}");

    var fh = config.Repository;

    fh.ReadynessHandler += (sender, readyness) =>
    {
        Console.WriteLine($"Readyness is {readyness}");
    };

    Console.WriteLine("Context initialized, waiting for readyness - Press a key when readyness appears");

    if (config.ServerEvaluation)
    {
        fh.GetFeature("soma").FeatureUpdateHandler += (object sender, IFeature holder) =>
        {
            if (holder.BooleanValue.Value)
            {
                Console.WriteLine($"Valor da soma: {Soma(1, 1)}");
            }
        };

        fh.GetFeature("SOMA_COM_MULTIPLICACAO").FeatureUpdateHandler += (object sender, IFeature holder) =>
        {
            if (holder.BooleanValue.Value)
            {
                Console.WriteLine($"Valor da soma: {SomaMulti(1, 1)}");
            }
        };
    }

    fh.ReadynessHandler += (sender, readyness) =>
    {
        Console.WriteLine($"Readyness is {readyness}");

        if (fh.GetFeature("abcdef").Exists)
        {

        }
    };

    Console.WriteLine("Context initialized, waiting for readyness - Press a key when readyness appears");
    Console.Read();
}

static int Soma(int a, int b)
{
    return (a + b);
}

static int SomaMulti(int a, int b)
{
    return (a + b) * 10;
}