using passeports_backend.entities;
using passeports_backend.Models;
using passeports_backend.Repository;

namespace passeports_backend.Services;

public class PasseportService : IPasseportService
{
    private readonly IRepository _repository;
    
    public PasseportService(IRepository repository)
    {
        _repository = repository;
    }
    
    public Task<IResponseModel> CreatePasseport(Passeport passeport)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponseDataModel<Passeport>> GetPasseport(int id)
    {
        try
        {
            return await _repository.GetAsync(p => p.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ResponseDataModel<Passeport> 
            { 
                Success = false, 
                Message = "Une erreur est survenue lors de la récupération du passeport" 
            };
        }
    }

    public Task<IResponseDataModel<IEnumerable<Passeport>>> GetAllPasseports()
    {
        throw new NotImplementedException();
    }

    public Task<IResponseModel> UpdatePasseport(Passeport passeport)
    {
        throw new NotImplementedException();
    }

    public Task<IResponseModel> DeletePasseport(int id)
    {
        throw new NotImplementedException();
    }
}