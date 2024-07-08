using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pets.Application.Pets.Commands;
using Pets.Application.Pets.Queries;
using Pets.WebApi.Models;

namespace Pets.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PetController : BaseController
    {
        private readonly IMapper _mapper;

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
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePetDto createPetDto)
        {
            var command = _mapper.Map<CreatePetCommand>(createPetDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePetDto updatePetDto)
        {
            var command = _mapper.Map<UpdatePetCommand>(updatePetDto);
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
    }
}
