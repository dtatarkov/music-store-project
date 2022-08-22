using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Context
{
    public interface IApplicationContext
    {
        DbSet<Album> Albums { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
