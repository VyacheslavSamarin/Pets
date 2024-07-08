using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Queries
{
    public class GetPetDetailsQuery : IRequest<PetDetailVm>
    {
        public int Id { get; set; }
    }
}
