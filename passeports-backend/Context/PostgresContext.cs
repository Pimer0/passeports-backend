using Microsoft.EntityFrameworkCore;

namespace passeports_backend.Context;

public class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }
}