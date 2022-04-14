using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaruosadApi.Data;
using VaruosadApi.Models;

namespace VaruosadApi.MappingProfiles
{
    public class CarPartsProfile : Profile
    {
        public CarPartsProfile()
        {
            CreateMap<CarPart, CarPartDto>();
            CreateMap< PagedResult<CarPart>, PagedResult<CarPartDto>>();
        }
    }
}
