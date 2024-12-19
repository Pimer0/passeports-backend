using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using passeports_backend.Context;
using passeports_backend.DTOs;
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

    public async Task<IResponseDataModel<PassportWithDetailsDto>> GetAsync(Expression<Func<Passeport, bool>>? filter)
    {
        try
        {
            if (filter == null)
            {
                return new ResponseDataModel<PassportWithDetailsDto>
                {
                    Success = false,
                    Message = "Filtre non spécifié"
                };
            }


            var data = await _context.Passeports
                .Include(p => p.Avantages)
                .Where(filter)
                .FirstOrDefaultAsync();

            if (data == null)
            {
                return new ResponseDataModel<PassportWithDetailsDto>
                {
                    Success = false,
                    Message = "Passeport not found"
                };
            }


            var passportWithDetailsDto = new PassportWithDetailsDto
            {
                Id = data.Id,
                Pays = data.Pays,
                Description = data.Description,
                Avantages = data.Avantages.Select(a => new AvantageDetailsDto
                {
                    Id = a.Id,
                    Contenu = a.Contenu,
                    PaysVisitables = a.PaysVisitables
                }).ToList()
            };

            return new ResponseDataModel<PassportWithDetailsDto>
            {
                Success = true,
                Data = passportWithDetailsDto
            };
        }
        catch (Exception ex)
        {

            
            return new ResponseDataModel<PassportWithDetailsDto>
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