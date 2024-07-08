using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pets.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pets.Application.Common.Exceptions;
using System.Threading.Tasks;
using Pets.Domain;

namespace Pets.Application.Pets.Queries
{
    public class GetDetailsQueryHandler : IRequestHandler<GetPetDetailsQuery, PetDetailVm>
    {
        private readonly IPetsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDetailsQueryHandler(IPetsDbContext context, IMapper mapper) { _dbContext = context; _mapper = mapper; }
        public async Task<PetDetailVm> Handle(GetPetDetailsQuery request,  CancellationToken cancellation)
        {
            var entity = await _dbContext.Pets.FirstOrDefaultAsync(pet => pet.Id == request.Id, cancellation);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Pet), request.Id);
            }
            return _mapper.Map<PetDetailVm>(entity); 
        }
    }
}
