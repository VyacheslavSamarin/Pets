using AutoMapper;
using Pets.Application.Common.Mappings;
using Pets.Application.Pets.Commands;
using Pets.Application.Pets.Queries;
using Pets.Domain;
using System.ComponentModel.DataAnnotations;

namespace Pets.WebApi.Models
{
    public class UpdatePetDto : IMapWith<UpdatePetCommand>
    {
        public int? Age { get; set; }

        public string? Description { get; set; }
        public double? Price { get; set; }
        public DateTime Birthday { get; set; }
        [StringLength(20)]
        public string? Type { get; set; }
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "The phone number is not valid.")]
        public string? Phone { get; set; }
        [StringLength(20)]
        public string? Owner { get; set; }
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
                .ForMember(petCommand => petCommand.Type,
                opt => opt.MapFrom(petDto => petDto.Type))
                .ForMember(petCommand => petCommand.Phone,
                opt => opt.MapFrom(petDto => petDto.Phone))
                .ForMember(petCommand => petCommand.Owner,
                opt => opt.MapFrom(petDto => petDto.Owner));
        }
    }
}
