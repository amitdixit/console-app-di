using Microsoft.Extensions.Logging;

namespace console_app_di;


public interface IDemoService
{
    Task PerformSomeTask();
}

internal class DemoService : IDemoService
{
    private readonly ILogger<DemoService> _logger;

    public DemoService(ILogger<DemoService> logger)
    {
        _logger = logger;
    }

    public async Task PerformSomeTask()
    {
        await Task.Delay(1000);

        _logger.LogInformation("Performimg Some Task");

    }
}