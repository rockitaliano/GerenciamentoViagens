using Domain.Core;
using Domain.Interfaces;
using Domain.ViewModels;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly IMotoristaService _service;
        private readonly IConfiguration _configuration;

        public MotoristaController(IMotoristaService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Create([FromBody] CreateMotoristaViewModel model)
        {
            try
            {
                var notitifations = model.Validade();
                if (notitifations.SendMessage.Count > 0)
                    return BadRequest(new Response(false, "Dados Inválidos",
                        new { Messages = notitifations.SendMessage }));

                var motorista = await _service.CreateMotorista(model);

                return Ok(new Response(true, "Motorista Cadastrado com sucesso.",
                    new { Motorista = motorista }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("GetId")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                if (Id == 0)
                    return BadRequest("Id do motorista não informado.");

                var motorista = await _service.GetById(Id);

                if (motorista == null)
                    return NotFound("Nenhum motorista encontrado.");

                return Ok(new Response(true, "Dados do motorista.",
                    new { Motorista = motorista }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var motorista = await _service.GetAll();

                if (motorista == null)
                    return NotFound("Nenhum motorista cadastrado.");

                return Ok(new Response(true, "Motoristas Cadastrados.",
                    new { Motorista = motorista }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _service.GetById(id);

                if (user == null)
                    return NotFound("Motorista não encontrado.");

                var motorista = _service.Delete(user.Id);

                return Ok(new Response(true, "Morista removido com sucesso.",
                    new { Motorista = motorista }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Motorista model)
        {
            try
            {
                if (model.Id == 0)
                    return NotFound("Motorista não encontrado.");

                var motorista = await _service.Update(model);

                return Ok(new Response(true, "Atualização de Motorista.",
                    new { Motorista = motorista }));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}