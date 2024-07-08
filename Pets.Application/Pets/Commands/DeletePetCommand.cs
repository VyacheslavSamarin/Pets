using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Pets.Commands
{
    public class DeletePetCommand: IRequest
    {
        public int Id { get; set; }
    }
}
