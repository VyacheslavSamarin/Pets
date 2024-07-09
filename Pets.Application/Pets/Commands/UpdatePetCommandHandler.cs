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
            if (command.Age != 0)
            {
                entity.Age = command.Age;
            }

            if (command.Price != 0)
            {
                entity.Price = command.Price;
            }

            if (command.Birthday != default(DateTime))
            {
                entity.Birthday = command.Birthday;
            }

            if (command.Description != null)
            {
                entity.Description = command.Description;
            }
            if (command.Type != null)
            {
                entity.Type = command.Type;
            }
            if (command.Phone != null)
            {
                entity.Phone = command.Phone;
            }
            if (command.Owner != null)
            {
                entity.Owner = command.Owner;
            }

            entity.DateUpdated = DateTime.UtcNow;
            _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
