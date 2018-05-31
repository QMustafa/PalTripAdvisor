using System;
using System.Collections.Generic;

namespace DataLayer.Respositories
{
    public class WeatherResponseModelWrapper
    {
        public List<WeatherResponseModel> WeatherStatus { get; set; }
        public string MessageResponse { get; set; }
    }

    public class WeatherResponseModel
    {
        public DateTime Day { get; set; }
        public decimal Degree { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


    }
}