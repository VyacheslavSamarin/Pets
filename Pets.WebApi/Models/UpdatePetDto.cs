using AutoMapper;
using Pets.Application.Common.Mappings;
using Pets.Application.Pets.Commands;

namespace Pets.WebApi.Models
{
    public class UpdatePetDto : IMapWith<UpdatePetCommand>
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public double Price { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePetDto, UpdatePetCommand>()
                .ForMember(petCommand => petCommand.Age,
                opt => opt.MapFrom(petDto => petDto.Age))
                .ForMember(petCommand => petCommand.Price,
                opt => opt.MapFrom(petDto => petDto.Price))
                .ForMember(petCommand => petCommand.Birthday,
                opt => opt.MapFrom(petDto => petDto.Birthday))
                .ForMember(petCommand => petCommand.Description,
                opt => opt.MapFrom(petDto => petDto.Description))
                .ForMember(petCommand => petCommand.Id,
                opt => opt.MapFrom(petDto => petDto.Id));

        }
    }
}
