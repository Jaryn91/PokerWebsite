using PokerWebsite.Core.Repositories;
using PokerWebsite.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerWebsite.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IPlayerRepository Players { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Players = new PlayerRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
