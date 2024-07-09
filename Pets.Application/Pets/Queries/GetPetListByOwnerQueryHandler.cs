using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pets.Application.Interfaces;

namespace Pets.Application.Pets.Queries
{
    public class GetPetListByOwnerQueryHandler : IRequestHandler<GetPetListByOwnerQuery, PetListVm>
    {
        private readonly IPetsDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetPetListByOwnerQueryHandler(IPetsDbContext dbContext, IMapper mapper) { _dbContext = dbContext; _mapper = mapper; }
        public async Task<PetListVm> Handle(GetPetListByOwnerQuery query, CancellationToken token)
        {
            var petsQuery = _dbContext.Pets.AsQueryable();

            if (query.Owner != null)
            {
                petsQuery = petsQuery.Where(pet => pet.Owner == query.Owner);
            }
            var petDtos = await petsQuery.ProjectTo<PetDto>(_mapper.ConfigurationProvider).ToListAsync(token);

            return new PetListVm { Pets = petDtos };
        }
    }
}
