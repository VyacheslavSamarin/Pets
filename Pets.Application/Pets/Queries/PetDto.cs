using AutoMapper;
using Pets.Application.Common.Mappings;
using Pets.Application.Pets.Commands;
using Pets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Queries
{
    public class PetDto : IMapWith<Pet>
    {
        public int Age { get; set; }
        public double Price { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pet, PetDto>()
                .ForMember(petCommand => petCommand.Age,
                opt => opt.MapFrom(petDto => petDto.Age))
                .ForMember(petCommand => petCommand.Price,
                opt => opt.MapFrom(petDto => petDto.Price))
                .ForMember(petCommand => petCommand.Birthday,
                opt => opt.MapFrom(petDto => petDto.Birthday))
                .ForMember(petCommand => petCommand.Description,
                opt => opt.MapFrom(petDto => petDto.Description));
        }
    }
}
