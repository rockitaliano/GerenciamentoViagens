using Domain.Core;
using Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IViagemService
    {
        Task<IEnumerable<ViagemResponse>> GetViagens();

        Task<ViagemResponse> GetById(int id);

        Task<ViagemResponse> CreateViagem(CreateViagemViewModel model);
    }
}