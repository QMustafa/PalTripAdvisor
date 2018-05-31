using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace DataLayer.Respositories
{
    public class WeatherRepository : IDisposable
    {
        private readonly PalTripAdvisorServicesEntities db;

        public WeatherRepository()
        {
            db = new PalTripAdvisorServicesEntities();
        }

        public void Dispose()
        {
        }

        public List<WeatherResponseModel> GetWeatherByCity(DateTime from, DateTime to, string city)
        {
            var data = db.Weathers.Where(_ => _.Date >= from && _.Date <= to && _.City.Contains(city)).Select(_ => new WeatherResponseModel{ City = _.City, Country = _.Country, Day = _.Date, Degree = _.Degree, zipCode = _.ZipCode }).ToList<WeatherResponseModel>();
            return data;
        }

        public List<WeatherResponseModel> GetWeatherByCountry(DateTime from, DateTime to, string country)
        {
            var data = db.Weathers.Where(_ => _.Date >= from && _.Date <= to && _.Country.Contains(country)).Select(_ => new WeatherResponseModel { City = _.City, Country = _.Country, Day = _.Date, Degree = _.Degree, zipCode = _.ZipCode }).ToList<WeatherResponseModel>();
            return data;
        }

        public List<WeatherResponseModel> GetWeatherByZipCode(DateTime from, DateTime to, string zipCode)
        {
            var data = db.Weathers.Where(_ => _.Date >= from && _.Date <= to && _.ZipCode.Contains(zipCode)).Select(_ => new WeatherResponseModel { City = _.City, Country = _.Country, Day = _.Date, Degree = _.Degree, zipCode = _.ZipCode }).ToList<WeatherResponseModel>();
            return data;
        }
    }
}
