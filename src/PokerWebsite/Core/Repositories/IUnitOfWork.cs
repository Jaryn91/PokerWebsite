using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        int Complete();
    }
}
