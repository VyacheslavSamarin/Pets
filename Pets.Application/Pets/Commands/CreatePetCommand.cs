using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Pets.Application.Pets.Commands
{
    public class CreatePetCommand : IRequest<int>
    {
        public int Age { get; set; }
        public double Price { get; set; }
        public DateTime Birthday{ get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Owner { get; set; }


    }
}
