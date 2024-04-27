using CaronaUFF.Infrastructure;

namespace CaronaUFF.Api.Middleware;

public class TransactionMiddleware(RequestDelegate next)
{

    public async Task Invoke(HttpContext httpContext)
    {
        FluentNhibernateHelper.BeginTransaction();

        await next(httpContext);

        if (httpContext.Response.StatusCode >= 200 && httpContext.Response.StatusCode < 300)
        {
            await FluentNhibernateHelper.CommitAsync();
            return;
        }
        await FluentNhibernateHelper.RollbackAsync();
    }
}