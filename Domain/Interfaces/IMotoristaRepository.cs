using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IMotoristaRepository
    {
        Task<Motorista> CreateMotorista(Motorista model);

        Task<IEnumerable<Motorista>> GetAll();

        Task<Motorista> GetById(int id);

        Task<Motorista> Delete(int id);

        Task<Motorista> Update(Motorista id);
    }
}