using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaruosadApi.Data.Repositories;

namespace VaruosadApi.Data
{
    public interface IUnitOfWork
    {
        public ICarPartRepository CarParts { get; }

        Task CompleteAsync();
    }
}
