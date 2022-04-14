using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaruosadApi.Queries
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 100;
        }
        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageSize = pageSize > 100 ? 100 : pageSize;
            PageNumber = pageNumber;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
