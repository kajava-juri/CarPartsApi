using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaruosadApi.Controllers.Repositories;
using VaruosadApi.Models;
using VaruosadApi.Queries;

namespace VaruosadApi.Data.Repositories
{
    public interface ICarPartRepository : IBaseRepository<CarPart>
    {
        Task<PagedResult<CarPart>> GetCarParts(PaginationQuery paginationQuery, CarPartParameters parameters);
    }
}
