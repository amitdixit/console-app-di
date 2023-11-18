using console_app_di;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddEnvironmentVariables();
        builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var config = builder.Build();
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        services.AddSingleton<StartupApplication>();
        services.AddSingleton<IDemoService, DemoService>();
    })
    .Build();


await host.Services.GetRequiredService<StartupApplication>().RunAsync();

//Task completes when the host shuts down
await host.RunAsync();

//Task completes once the host is started
//await host.StartAsync();


//To Stop via cancellation Token
//await host.WaitForShutdownAsync();


//Console.ReadLine();