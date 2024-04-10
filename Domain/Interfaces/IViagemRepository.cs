using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IViagemRepository
    {
        Task<IEnumerable<Viagem>> GetViagens();

        Task<Viagem> GetById(int id);

        Task<Viagem> Create(Viagem model);
    }
}