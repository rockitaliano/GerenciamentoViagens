using Domain.Core;
using Domain.Interfaces;
using Domain.ViewModels;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagensController : ControllerBase
    {        
        private readonly IViagemService _service;
        private readonly IConfiguration _configuration;
        private readonly IMotoristaService _serviceMotorista;

        public ViagensController(IViagemService context, IMotoristaService serviceMotorista, IConfiguration configuration)
        {
            _service = context;
            _configuration = configuration;
            _serviceMotorista = serviceMotorista;
        }

        // GET: api/Viagens
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ViagemResponse>>> GetViagens()
        {
            try
            {
                var viagem = await _service.GetViagens();

                if (viagem == null)
                    return NotFound("Nenhuma viagem encontrada.");

                return Ok(new Response(true, "Viagens Cadastradas.",
                    new { Viagem = viagem }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: api/Viagens/5
        [HttpGet]
        [Route("GetId")]
        public async Task<ActionResult<Viagem>> GetViagem(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Id do usuário não informado.");

                var viagem = await _service.GetById(id);

                return Ok(new Response(true, "Viagens Por Id",
                    new { Viagem = viagem }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Viagem>> PostViagem([FromBody] CreateViagemViewModel model)
        {
            try
            {
                var notificatons = model.Validate();
                if (notificatons.SendMessage.Count > 0)
                    return BadRequest(new Response(false, "Dados inválidos",
                        new { Messages = notificatons.SendMessage }));

                var motorista = await _serviceMotorista.GetById(model.MotoristaId);
                if (motorista == null)
                {
                    return NotFound($"Motorista não encontrado. Id: {model.MotoristaId}");
                }
                var viagem = await _service.CreateViagem(model);

                return Ok(new Response(true, $"Viagem cadastradas com sucesso.",
                    new { Viagem = viagem }));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}