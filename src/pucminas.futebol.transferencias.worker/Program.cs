using pucminas.futebol.transferencias.worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<SolicitacaoTransferenciaWorker>();
    })
    .Build();

await host.RunAsync();
