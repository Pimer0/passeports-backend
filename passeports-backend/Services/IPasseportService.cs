using passeports_backend.entities;
using passeports_backend.Models;

namespace passeports_backend.Services;

public interface IPasseportService
{
    Task<IResponseModel> CreatePasseport(Passeport passeport);
    Task<IResponseDataModel<Passeport>> GetPasseport(int id);
    Task<IResponseDataModel<IEnumerable<Passeport>>> GetAllPasseports();
    Task<IResponseModel> UpdatePasseport(Passeport passeport);
    Task<IResponseModel> DeletePasseport(int id);
}