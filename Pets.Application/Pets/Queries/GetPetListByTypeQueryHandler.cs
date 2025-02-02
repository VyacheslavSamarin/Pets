﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pets.Application.Interfaces;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Queries
{
    public class GetPetListByTypeQueryHandler : IRequestHandler<GetPetListByTypeQuery, PetListVm>
    {
        private readonly IPetsDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetPetListByTypeQueryHandler(IPetsDbContext dbContext, IMapper mapper) { _dbContext = dbContext; _mapper = mapper; }
        public async Task<PetListVm> Handle(GetPetListByTypeQuery query, CancellationToken token)
        {
            var petsQuery = _dbContext.Pets.AsQueryable();

            if (query.Type != null)
            {
                petsQuery = petsQuery.Where(pet => pet.Type == query.Type);
            }
            var petDtos = await petsQuery.ProjectTo<PetDto>(_mapper.ConfigurationProvider).ToListAsync(token);

            return new PetListVm { Pets = petDtos };
        }
    }
}
