using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;

namespace TabletopStore.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}
