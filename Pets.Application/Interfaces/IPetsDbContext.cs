using Microsoft.EntityFrameworkCore;
using Pets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Application.Interfaces
{
    public interface IPetsDbContext
    {
        DbSet<Pet> Pets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
