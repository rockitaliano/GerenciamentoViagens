using Domain.Core;
using Domain.ViewModels;
using Entities.Entities;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public class MotoristaService : IMotoristaService
    {
        private readonly IMotoristaRepository _motorista;

        public MotoristaService(IMotoristaRepository service)
        {
            _motorista = service;
        }

        //Fiz desta forma para mostrar
        public async Task<MotoristaResponse> CreateMotorista(CreateMotoristaViewModel model)
        {
            try
            {
                var entity = new Motorista()
                {
                    Id = model.MotoristaId,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    Endereco = model.Endereco,
                    Modelo = model.Modelo,
                    Placa = model.Placa,
                    Marca = model.Marca,
                    Eixos = model.Eixos
                };

                var condCreate = await _motorista.CreateMotorista(entity);

                MotoristaResponse response = new MotoristaResponse()
                {
                    Id = condCreate.Id,
                    Nome = condCreate.Nome,
                    Sobrenome = condCreate.Sobrenome,
                    Endereco = condCreate.Endereco,
                    Modelo = condCreate.Modelo,
                    Placa = condCreate.Placa,
                    Marca = condCreate.Marca,
                    Eixos = condCreate.Eixos
                };
                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Motorista> Delete(int id)
        {
            return await _motorista.Delete(id);
        }

        public async Task<IEnumerable<Motorista>> GetAll()
        {
            return await _motorista.GetAll();
        }

        public async Task<Motorista> GetById(int id)
        {
            return await _motorista.GetById(id);
        }

        public async Task<Motorista> Update(Motorista model)
        {
            return await _motorista.Update(model);
        }
    }
}