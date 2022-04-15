using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VaruosadApi.Controllers.Repositories;
using VaruosadApi.Models;
using VaruosadApi.Queries;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;

namespace VaruosadApi.Data.Repositories
{
    public class CarPartRepository : BaseRepository<CarPart>, ICarPartRepository
    {
        private readonly ApplicationDbContext _context;

        public CarPartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResult<CarPart>> GetCarParts(PaginationQuery paginationQuery, CarPartParameters parameters)
        {
            if (!parameters.ValidProperty)
            {
                return null;
            }
            var carParts = new PagedResult<CarPart>();
            var queryable = _context.CarParts.AsQueryable();
            var page = paginationQuery.PageNumber;
            var pagesize = paginationQuery.PageSize;

            queryable = AddFiltersOnQuery(parameters, queryable);

            if(queryable == null)
            {
                return null;
            }

            carParts = await queryable.GetPagedAsync(page, pagesize);

            return carParts;
        }

        private static IQueryable<CarPart> AddFiltersOnQuery(CarPartParameters parameters, IQueryable<CarPart> queryable)
        {
            var sortingOrder = CheckFilter.GetOrderName(parameters.OrderBy);
            if (sortingOrder == null)
            {
                return null;
            }

            if (parameters.MaxPrice > 0)
            {
                if (!parameters.ValidPriceRange) { return null; }

                queryable = queryable.Where(carpart => carpart.Price > parameters.MinPrice && carpart.Price < parameters.MaxPrice);
            }

            queryable = queryable.OrderBy($"{parameters.SortBy} {sortingOrder}");


            return queryable;
        }
    }
}
