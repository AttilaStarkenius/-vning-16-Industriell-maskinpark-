using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Övning_16___Industriell_maskinpark__.Shared.Entities;

namespace Övning_16___Industriell_maskinpark__.Server.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<Övning_16___Industriell_maskinpark__.Shared.Entities.IndustrialMachine> Item { get; set; } = default!;
    }
}
