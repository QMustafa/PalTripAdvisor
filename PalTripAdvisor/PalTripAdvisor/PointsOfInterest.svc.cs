using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer;
using DataLayer.Respositories;

namespace PalTripAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PointsOfInterest" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PointsOfInterest.svc or PointsOfInterest.svc.cs at the Solution Explorer and start debugging.
    public class PointsOfInterest : IPointsOfInterest
    {
        public string addRating(string id, string rating)
        {
            using (PointOfInterestRepository repository = new PointOfInterestRepository())
            {
                return repository.addRating(id, rating);
            }
               
        }


        public List<PointOfInterest> GetPOIByCountry(string country)
        {
            using (PointOfInterestRepository repository = new PointOfInterestRepository())
            {
                var data =  repository.GetPOIByCountry(country);
                var temp = new List<PointOfInterest>();
                foreach (var row in data)
                {
                    temp.Add(new PointOfInterest()
                    {
                        CityName = row.CityName,
                        CountryName = row.CountryName,
                        CreatedBy = row.CreatedBy,
                        Currency = row.Currency,
                        CreatedDate = row.CreatedDate,
                        CurrencyId = row.CurrencyId,
                        Id = row.Id,
                        Image = row.Image,
                        ModifiedBy = row.ModifiedBy,
                        ModifiedDate = row.ModifiedDate,
                        Name = row.Name,
                        Starts = row.Starts
                    });
                }
                return temp;
            }
        }

        public List<PointOfInterest> GetPOIByCity(string country, string city)
        {
            using (PointOfInterestRepository repository = new PointOfInterestRepository())
            {
                var data = repository.GetPOIByCity(country, city);
                var temp = new List<PointOfInterest>();
                foreach (var row in data)
                {
                    temp.Add(new PointOfInterest()
                    {
                        CityName = row.CityName,
                        CountryName = row.CountryName,
                        CreatedBy = row.CreatedBy,
                        Currency = row.Currency,
                        CreatedDate = row.CreatedDate,
                        CurrencyId = row.CurrencyId,
                        Id = row.Id,
                        Image = row.Image,
                        ModifiedBy = row.ModifiedBy,
                        ModifiedDate = row.ModifiedDate,
                        Name = row.Name,
                        Starts = row.Starts
                    });
                }
                return temp;
            }
        }
    }
}
