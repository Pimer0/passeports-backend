using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using passeports_backend.Context;
using passeports_backend.entities;
using passeports_backend.Models;
namespace passeports_backend.Repository;

public class PasseportRepository : IRepository
{
    private readonly PostgresContext _context;
    public PasseportRepository(PostgresContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IResponseDataModel<Passeport>> GetAsync(Expression<Func<Passeport, bool>>? filter)
    {
        try
        {
            // Vérification des paramètres
            if (filter == null)
            {
                return new ResponseDataModel<Passeport>
                {
                    Success = false,
                    Message = "Filtre non spécifié"
                };
            }

            // Utilisation de FirstOrDefaultAsync pour plus de sécurité
            var data = await _context.Passeports
                .Include(p => p.Avantages)
                .Where(filter)
                .FirstOrDefaultAsync();

            return data != null
                ? new ResponseDataModel<Passeport>
                {
                    Success = true,
                    Data = data
                }
                : new ResponseDataModel<Passeport>
                {
                    Success = false,
                    Message = "Passeport not found"
                };
        }
        catch (Exception ex)
        {
            // Logging de l'exception
            Console.WriteLine($"Erreur dans GetAsync : {ex.Message}");
            
            return new ResponseDataModel<Passeport>
            {
                Success = false,
                Message = $"Erreur lors de la récupération : {ex.Message}"
            };
        }
    
    }

public IEnumerable<Passeport> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Add(Passeport entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Passeport entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Passeport entity)
    {
        throw new NotImplementedException();
    }
}