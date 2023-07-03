/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;


namespace gestao_campeonato.Controllers
{
public class TokenMiddleware
{
    private readonly RequestDelegate _next;

    public TokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Obtém o token do cookie
        string? token = context.Request.Cookies["Token"];

        // Verifica se o token existe
        if (!string.IsNullOrEmpty(token))
        {
            // Configura o valor do token no cabeçalho Authorization
            context.Request.Headers["Authorize"] = $"Bearer {token}";
        }

        await _next(context);
    }
}

public static class TokenMiddlewareExtensions
{
    public static IApplicationBuilder UseTokenMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenMiddleware>();
    }
}
}*/
