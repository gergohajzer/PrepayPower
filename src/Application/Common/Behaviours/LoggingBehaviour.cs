using MediatR.Pipeline;

namespace PrepayPower.Application.Common.Behaviours;

/// <summary>
/// Responsible for logging every Mediatr request in the application.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{

    public LoggingBehaviour()
    {
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        Console.WriteLine("Request: {0} {1}",
            requestName, request);
        
        return Task.CompletedTask;
    }
}
