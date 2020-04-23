using SFFApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Responses
{
    public class EtikettData
    {
        public string FilmNamn { get; set; }
        public string Ort { get; set; }
        public DateTime Datum { get; set; }

    }    
}
