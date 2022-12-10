using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Country
    {
       
        public Country(int countryId, string countryCode, string countryName, bool euCountry)
        {
            Id = countryId;
            Code = countryCode;
            Name = countryName;
            EUCountry = euCountry;
        }

        public int Id { get; private set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool EUCountry { get; set; }

    }
}
