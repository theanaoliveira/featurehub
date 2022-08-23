// See https://aka.ms/new-console-template for more information
using FeatureHub.Console.Injection;
using FeatureHub.Console.UseCases.Monitor;
using FeatureHubSDK;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder()
    //.ConfigureServices((context, services) =>
    //{
    //    services.ConfigHub();
    //    services.RegisterCases();
    //})
    .Build();

//var usecase = host.Services.GetService<IMonitorFeatureUseCase>();
//var config = host.Services.GetService<IFeatureHubConfig>();

//usecase.Execute();

await host.RunAsync();