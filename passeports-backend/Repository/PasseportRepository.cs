using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using passeports_backend.entities;
using passeports_backend.Models;
namespace passeports_backend.Repository;

public class PasseportRepository : IRepository
{
    private readonly PostgresContext _context;

    public async Task<IResponseDataModel<Passeport>> GetAsync(Expression<Func<Passeport, bool>>? filter)
    {
        try
        {
            var data = await _context.Passeports.SingleOrDefaultAsync(filter);
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
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