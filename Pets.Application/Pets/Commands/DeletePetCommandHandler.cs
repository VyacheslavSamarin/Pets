using MediatR;
using Pets.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pets.Application.Common.Exceptions;

namespace Pets.Application.Pets.Commands
{
    public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand>
    {
        private readonly IPetsDbContext _dbContext;

        public DeletePetCommandHandler(IPetsDbContext dbContext) { _dbContext = dbContext; }
         
        public async Task<Unit> Handle(DeletePetCommand command, CancellationToken cancellation)
        {
            var entity = await _dbContext.Pets.FindAsync(new object[] { command.Id}, cancellation);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Pets), command.Id);
            }
            _dbContext.Pets.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellation);
            return Unit.Value;
        }

    }
}
