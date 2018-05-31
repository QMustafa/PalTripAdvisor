using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataLayer.Respositories;
using PalTripAdvisor.Models;

namespace PalTripAdvisor
{
    /// <summary>
    /// Summary description for GetWeather
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetWeather : System.Web.Services.WebService
    {
        [WebMethod]
        public WeatherResponseDomainObjectWrapper GetWeatherByCity(string from, string to, string city)
        {
            WeatherRepository repository = new WeatherRepository();
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            var temp = repository.GetWeatherByCity(fromDate, toDate, city);
            List<WeatherResponseDomainObject> data = new List<WeatherResponseDomainObject>();
            foreach (var item in temp)
            {
                data.Add(new WeatherResponseDomainObject()
                {
                    City = item.City,
                    Degree = item.Degree,
                    Country = item.Country,
                    Day = item.Day.ToShortDateString(),
                    zipCode = item.zipCode
                });
            }
            return new WeatherResponseDomainObjectWrapper { MessageResponse = "200, result fetched successfully", WeatherStatus = data };
        }

        [WebMethod]
        public WeatherResponseDomainObjectWrapper GetWeatherByCountry(string from, string to, string country)
        {
            WeatherRepository repository = new WeatherRepository();
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            var temp = repository.GetWeatherByCountry(fromDate, toDate, country);
            List<WeatherResponseDomainObject> data = new List<WeatherResponseDomainObject>();
            foreach (var item in temp)
            {
                data.Add(new WeatherResponseDomainObject()
                {
                    City = item.City,
                    Degree = item.Degree,
                    Country = item.Country,
                    Day = item.Day.ToShortDateString(),
                    zipCode = item.zipCode
                });
            }
            return new WeatherResponseDomainObjectWrapper { MessageResponse = "200, result fetched successfully", WeatherStatus = data};
        }

        [WebMethod]
        public WeatherResponseDomainObjectWrapper GetWeatherByZipCode(string from, string to, string zipCode)
        {
            WeatherRepository repository = new WeatherRepository();
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            var temp = repository.GetWeatherByZipCode(fromDate, toDate, zipCode);
            List<WeatherResponseDomainObject> data = new List<WeatherResponseDomainObject>();
            foreach (var item in temp)
            {
                data.Add(new WeatherResponseDomainObject()
                {
                    City = item.City,
                    Degree = item.Degree,
                    Country = item.Country,
                    Day = item.Day.ToShortDateString(),
                    zipCode = item.zipCode

                });
            }
            return new WeatherResponseDomainObjectWrapper { MessageResponse = "200, result fetched successfully", WeatherStatus = data };
        }

    }
}
