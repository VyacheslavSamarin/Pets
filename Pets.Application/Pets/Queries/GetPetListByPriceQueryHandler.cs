using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pets.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Queries
{
    public class GetPetListByPriceQueryHandler : IRequestHandler<GetPetListByPriceQuery, PetListVm>
    {
        private readonly IPetsDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetPetListByPriceQueryHandler(IPetsDbContext dbContext, IMapper mapper) { _dbContext = dbContext; _mapper = mapper; }
        public async Task<PetListVm> Handle(GetPetListByPriceQuery query, CancellationToken token)
        {
            var petsQuery = _dbContext.Pets.AsQueryable();

            if (query.MinPrice != null)
            {
                petsQuery = petsQuery.Where(pet => pet.Price >= query.MinPrice);
            }

            if (query.MaxPrice != null)
            {
                petsQuery = petsQuery.Where(pet => pet.Price <= query.MaxPrice);
            }
            var petDtos = await petsQuery.ProjectTo<PetDto>(_mapper.ConfigurationProvider).ToListAsync(token);

            return new PetListVm { Pets = petDtos };
        }
    }
}
