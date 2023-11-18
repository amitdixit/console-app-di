using Microsoft.Extensions.Configuration;

namespace console_app_di;
internal class StartupApplication
{
    private readonly IDemoService _demoService;
    private readonly IConfiguration _configuration;

    public StartupApplication(IDemoService demoService, IConfiguration configuration)
    {
        _demoService = demoService;
        _configuration = configuration;
    }

    public async Task RunAsync()
    {
        await _demoService.PerformSomeTask();

        await Console.Out.WriteLineAsync("Running");


        await Console.Out.WriteLineAsync(_configuration.GetConnectionString("SqlConnection"));

        await Task.CompletedTask;
    }
}