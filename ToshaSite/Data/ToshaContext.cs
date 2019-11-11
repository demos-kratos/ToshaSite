using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ToshaSite.Data
{
    public class ToshaContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
    }
}
