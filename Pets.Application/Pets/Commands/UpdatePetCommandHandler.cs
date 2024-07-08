using MediatR;
using Microsoft.EntityFrameworkCore;
using Pets.Application.Common.Exceptions;
using Pets.Application.Interfaces;
using Pets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pets.Application.Pets.Commands
{
    public class  UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand>
    {
        private readonly IPetsDbContext _dbContext;

        public UpdatePetCommandHandler(IPetsDbContext context) { _dbContext = context; }

        public async Task<Unit> Handle(UpdatePetCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pets.FirstOrDefaultAsync(pet => pet.Id == command.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Pet), command.Id);
            }
            entity.Birthday = command.Birthday;
            entity.Price = command.Price;
            entity.Description = command.Description;
            entity.Age = command.Age;
            _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
