using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaruosadApi.Data;
using VaruosadApi.Data.Repositories;
using VaruosadApi.Models;
using VaruosadApi.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaruosadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPartsController : ControllerBase
    {

        private readonly IUnitOfWork _uow;
        private readonly ICarPartRepository _carPartRepository;
        private readonly IMapper _mapper;

        public CarPartsController(IUnitOfWork context, IMapper mapper)
        {
            _uow = context;
            _mapper = mapper;
            _carPartRepository = context.CarParts;
        }

        [HttpGet]
        public async Task<string> GetCarParts([FromQuery] CarPartParameters parameters, [FromQuery] PaginationQuery paginationQuery)
        {
            var carParts = new PagedResult<CarPart>();

            carParts = await _carPartRepository.GetCarParts(paginationQuery, parameters);

            if(carParts == null)
            {
                return JsonConvert.SerializeObject(new Errors { Error = "bad request" }, Formatting.Indented);
            }

            var dto = _mapper.Map<PagedResult<CarPartDto>>(carParts);

            string json = JsonConvert.SerializeObject(dto, Formatting.Indented);

            return json;
        }

        // GET api/<CarPartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var carpart = _carPartRepository.Get(id).Result;

            string json = JsonConvert.SerializeObject(carpart, Formatting.Indented);

            return json;
        }

        // POST api/<CarPartsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarPartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarPartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
