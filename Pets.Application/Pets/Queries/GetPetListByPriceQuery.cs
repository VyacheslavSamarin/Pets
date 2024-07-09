using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Queries
{
    public class GetPetListByPriceQuery : IRequest<PetListVm>
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
