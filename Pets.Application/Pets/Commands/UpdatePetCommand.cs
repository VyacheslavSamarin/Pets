using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Commands
{
    public class UpdatePetCommand : IRequest
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public double Price { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
    }
}
