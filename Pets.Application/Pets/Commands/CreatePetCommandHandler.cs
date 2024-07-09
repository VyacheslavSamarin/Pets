using MediatR;
using Pets.Application.Interfaces;
using Pets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Commands
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, int>
    {
        private readonly IPetsDbContext _dbContext;

        public CreatePetCommandHandler(IPetsDbContext dbContext) => _dbContext = dbContext;
        public async Task<int> Handle(CreatePetCommand command, CancellationToken cancellation)
        {
            var pet = new Pet
            {
                Age = command.Age,
                Price = command.Price,
                Birthday = command.Birthday,
                Description = command.Description,  
                Type = command.Type,
                DateAdded = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                Phone = command.Phone,
                Owner = command.Owner,
            };
            
            await _dbContext.Pets.AddAsync(pet, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);

            return pet.Id;
        }
    }
}
