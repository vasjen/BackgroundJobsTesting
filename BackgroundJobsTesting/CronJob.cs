using Cronos;
using Pilgaard.BackgroundJobs;

namespace BackgroundJobsTesting;

public class CronJob : ICronJob
{
    private readonly ILogger<CronJob> _logger;

    public CronJob(ILogger<CronJob> logger)
    {
        _logger = logger;
    }

    protected async Task DoWork(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Some job from CronJob");
        await Task.Delay(1000, cancellationToken);
    }

    public async Task RunJobAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Utc time now: {0}. Start ICronJob process. Run from thread: {1}", DateTime.UtcNow, Thread.CurrentThread.ManagedThreadId);
        await this.DoWork(cancellationToken);
        _logger.LogInformation("Utc time now: {0}. End ICronJob process\n", DateTime.UtcNow);
    }
    public CronExpression CronExpression => CronExpression.Parse("*/5 * * * * *", CronFormat.IncludeSeconds);
}