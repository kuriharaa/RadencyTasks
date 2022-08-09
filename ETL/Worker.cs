using ETL.Service;

namespace ETL;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IETLService _etlService;

    public Worker(ILogger<Worker> logger, IETLService etlService)
    {
        _logger = logger;
        _etlService = etlService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _etlService.StartETLAsync(new CancellationTokenSource());
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
