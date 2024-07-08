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
    public class GetListQueryHandler : IRequestHandler<GetPetListQuery, PetListVm>
    {
        private readonly IPetsDbContext _dBcontext;
        private readonly IMapper _mapper;

        public GetListQueryHandler(IPetsDbContext context, IMapper mapper) { _dBcontext = context; _mapper = mapper; }

        public async Task<PetListVm> Handle(GetPetListQuery query, CancellationToken token)
        {
            var petsQuery = await _dBcontext.Pets
                                            .ProjectTo<PetDto>(_mapper.ConfigurationProvider)
                                            .ToListAsync(token);
            return new PetListVm { Pets = petsQuery };
        }



    }
}
