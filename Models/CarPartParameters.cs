using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaruosadApi.Models
{
    public class CarPartParameters
    {
        public string SortBy { get; set; }
        public string OrderBy { get; set; }
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; }

        public bool ValidPriceRange => MaxPrice > MinPrice;

        public bool ValidProperty => CheckFilter.CheckPropertyName(SortBy);

        public CarPartParameters()
        {
            OrderBy = "ascending";
            SortBy = "name";
        }

    }

    public class CheckFilter
    {
        public static string GetOrderName(string stringToCheck)
        {
            string[] validOrder = { "ascending", "asc", "descending", "desc" };
            string[] desc = { "descending", "desc" };

            if (validOrder.Contains(stringToCheck))
            {
                return desc.Contains(stringToCheck) ? "descending" : "ascending";
            }
            return null;
        }
        public static bool CheckPropertyName(string stringToCheck)
        {
            CarPartDto carPart = new CarPartDto();
            var propertyNames = carPart.GetType().GetProperties().Select(p => p.Name.ToLower()).ToList();
            return propertyNames.Contains(stringToCheck.ToLower());
        }
    }
}
