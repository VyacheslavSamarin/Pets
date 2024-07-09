using AutoMapper;
using Pets.Application.Common.Mappings;
using Pets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Queries
{
    public class PetDetailVm : IMapWith<Pet>
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public double Price { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Phone { get; set; }
        public string Owner { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pet, PetDetailVm>()
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
                .ForMember(petCommand => petCommand.DateAdded,
                opt => opt.MapFrom(petDto => petDto.DateAdded))
                .ForMember(petCommand => petCommand.DateUpdated,
                opt => opt.MapFrom(petDto => petDto.DateUpdated))
                .ForMember(petCommand => petCommand.Phone,
                opt => opt.MapFrom(petDto => petDto.Phone))
                .ForMember(petCommand => petCommand.Owner,
                opt => opt.MapFrom(petDto => petDto.Owner))
                .ForMember(petCommand => petCommand.Id,
                opt => opt.MapFrom(petDto => petDto.Id));


        }
    }
}
