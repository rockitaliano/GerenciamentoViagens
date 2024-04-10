using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly DataContext _context;

        public ViagemRepository(DataContext context)
        {
            _context = context;
        }

        public Task DataHoraViagem(DateTime date)
        {
            return null;
        }

        public async Task<IEnumerable<Viagem>> GetViagens()
        {
            try
            {
                var viagens = _context.Viagens.Where(v => v.ViagemId > 0).ToList();
                return await Task.FromResult(viagens);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Viagem> GetById(int id)
        {
            try
            {
                var viagem = _context.Viagens.Where(v => v.ViagemId == id).FirstOrDefault();
                return await Task.FromResult(viagem);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Viagem> Create(Viagem model)
        {
            try
            {
                var viagem = await _context.Viagens.AddAsync(model);
                await _context.SaveChangesAsync();

                return await Task.FromResult(viagem.Entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}