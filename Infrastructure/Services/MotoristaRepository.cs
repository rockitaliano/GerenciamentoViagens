using Entities.Entities;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly DataContext _context;
        public MotoristaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Motorista> CreateMotorista(Motorista model)
        {
            try
            {
                var motorista = await _context.Motoristas.AddAsync(model);
                await _context.SaveChangesAsync();

                return await Task.FromResult(motorista.Entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Motorista> Delete(int id)
        {
            try
            {
                var motorista = await _context.Motoristas.FindAsync(id);

                if (motorista != null)
                {
                    _context.Motoristas.Remove(motorista);
                    await _context.SaveChangesAsync();

                    return await Task.FromResult(motorista);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Motorista>> GetAll()
        {
            try
            {
                var motorista = _context.Motoristas.ToList();

                return await Task.FromResult(motorista);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Motorista> GetById(int id)
        {
            try
            {
                var motorista = _context.Motoristas.Where(m => m.Id == id).FirstOrDefault();

                return await Task.FromResult(motorista);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Motorista> Update(Motorista model)
        {
            try
            {
                var motorista = _context.Set<Motorista>().Update(model);
                await _context.SaveChangesAsync();

                return await Task.FromResult(motorista.Entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}