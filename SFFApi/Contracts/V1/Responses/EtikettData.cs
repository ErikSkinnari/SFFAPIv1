using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Responses
{
    public class EtikettData : ILabel
    {
        public string FilmNamn { get; set; }
        public string Ort { get; set; }
        public DateTime Datum { get; set; }

        public EtikettData(Movie movie, Studio studio)
        {
            FilmNamn = movie.Title;
            Ort = studio.Address.City;
            Datum = DateTime.Now;
        }
    }    
}
