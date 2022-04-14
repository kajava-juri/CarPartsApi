using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaruosadApi.Models
{
    public class CarPartDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
