using Domain.Core;
using Domain.ViewModels;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMotoristaService
    {
        Task<MotoristaResponse> CreateMotorista(CreateMotoristaViewModel model);

        Task<IEnumerable<Motorista>> GetAll();

        Task<Motorista> GetById(int id);

        Task<Motorista> Delete(int id);

        Task<Motorista> Update(Motorista id);
    }
}