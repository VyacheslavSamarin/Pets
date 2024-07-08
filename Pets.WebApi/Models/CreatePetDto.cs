using AutoMapper;
using Pets.Application.Common.Mappings;
using Pets.Application.Pets.Commands;

namespace Pets.WebApi.Models
{
    public class CreatePetDto : IMapWith<CreatePetCommand>
    {
        public int Age { get; set; }
        public double Price { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePetDto, CreatePetCommand>()
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
