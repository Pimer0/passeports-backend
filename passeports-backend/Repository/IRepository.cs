using System.Linq.Expressions;
using passeports_backend.entities;
using passeports_backend.Models;

namespace passeports_backend.Repository;

public interface IRepository
{
    Task<IResponseDataModel<Passeport>> GetAsync(Expression<Func<Passeport, bool>>? filter);

}