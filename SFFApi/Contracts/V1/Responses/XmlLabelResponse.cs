using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Responses
{
    public class XmlLabelResponse : ILabel
    {
        public string Recipient { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Content { get; set; }
        public DateTime DispatchDate { get; set; }

        public XmlLabelResponse(Movie movie, Studio studio)
        {
            Recipient = studio.Name;
            AddressLine1 = studio.Address.AddressLine1;
            AddressLine2 = studio.Address.AddressLine2;
            ZipCode = studio.Address.ZipCode;
            City = studio.Address.City;
            Content = "Title: " + movie.Title + ", Id: " + movie.MovieId;
            DispatchDate = DateTime.Now;
        }
    }
}
