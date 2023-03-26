using MediatR;

namespace PrepayPower.Application.Common.Behaviours;

/// <summary>
/// Responsible for logging exceptions.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public UnhandledExceptionBehaviour()
    {
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            Console.Error.WriteLine("Request: Unhandled Exception for Request {0}, Exception: {1}", requestName, ex.Message);
            throw;
        }
    }
}
