using VaruosadApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaruosadApi.Data;

namespace VaruosadApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICarPartRepository CarParts { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ICarPartRepository carPartRepository)
        {
            _context = context;
            CarParts = carPartRepository;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
