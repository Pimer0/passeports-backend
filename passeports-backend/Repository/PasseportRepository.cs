using passeports_backend.entities;

namespace passeports_backend.Repository;

public class PasseportRepository : IRepository<Passeport>
{
    private readonly PostgresContext _context;
    
    public Passeport? GetById(int id)
    {
        var passeport = from p in _context.Passeports
            where p.Id == id
            select p;
        return passeport.FirstOrDefault();
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