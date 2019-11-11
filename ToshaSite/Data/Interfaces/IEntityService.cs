using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToshaSite.Data
{
    public interface IEntityService
    {
        IEnumerable<Entity> GetEntities();
    }
}
