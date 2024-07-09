using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pets.Application.Pets.Commands;
using Pets.Application.Pets.Queries;
using Pets.WebApi.Models;
using System.Net;
using System.Text;

namespace Pets.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PetController : BaseController
    {
        private readonly IMapper _mapper;

        private static string auth_token;


        public PetController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PetListVm>> GetAll()
        {
            var query = new GetPetListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("by-price")]
        public async Task<ActionResult<PetListVm>> GetAllByPrice([FromQuery] GetAllByPriceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var query = new GetPetListByPriceQuery
            {
                MaxPrice = request.MaxPrice,
                MinPrice = request.MinPrice,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDetailVm>> Get(int id)
        {
            var query = new GetPetDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePetDto createPetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = _mapper.Map<CreatePetCommand>(createPetDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePetDto updatePetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = _mapper.Map<UpdatePetCommand>(updatePetDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePetCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpGet("by-type")]
        public async Task<ActionResult<PetListVm>> GetAllByType([FromQuery] string type)
        {

            var query = new GetPetListByTypeQuery
            {
                Type = type,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("by-owner")]
        public async Task<ActionResult<PetListVm>> GetAllByOwner([FromQuery] string owner)
        {

            var query = new GetPetListByOwnerQuery
            {
                Owner = owner,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}

