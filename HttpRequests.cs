using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_HttpRequest
{
    internal class CountryInfo
    {
        String officialName;
        String capital;
        Double area;

        public CountryInfo(String officialName, String capital, Double area)
        {
            this.officialName = officialName;   
            this.capital = capital;
            this.area = area;
        }

        public override string ToString()
        {
            return$"Country: {officialName}\r\nCapital: {capital}\r\nArea: {area}\r\n_______________";
        }
    }

}
