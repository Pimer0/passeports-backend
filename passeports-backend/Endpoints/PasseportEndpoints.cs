namespace passeports_backend.Endpoints;

public static class PasseportEndpoints
{
    public static RouteGroupBuilder MapPasseportEndpoints(this RouteGroupBuilder endpoints)
    {
        endpoints.MapGet("/", () => "Application is running!");
        return endpoints;
    }
    
}