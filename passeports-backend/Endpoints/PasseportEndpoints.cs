using Microsoft.AspNetCore.Mvc;
using passeports_backend.Services;

namespace passeports_backend.Endpoints;

public static class PasseportEndpoints
{
    public static RouteGroupBuilder MapPasseportEndpoints(this RouteGroupBuilder endpoints)
    {
        endpoints.MapGet("/{id}", async ([FromServices] IPasseportService service, [FromRoute] int id) =>
        {
            var result = await service.GetPasseport(id);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        });
        return endpoints;
    }
    
}