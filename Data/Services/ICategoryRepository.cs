using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;

namespace TabletopStore.Services
{
    /// <summary>
    /// We need this interface to set up custom service, that will help us with mock database before we get to EntityFramework.
    /// After we create our repositories we can simply switch our classes in Startup.cs from Mock to Repository ones.
    /// Mock categories can be found in /data/mocks
    /// </summary>
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
