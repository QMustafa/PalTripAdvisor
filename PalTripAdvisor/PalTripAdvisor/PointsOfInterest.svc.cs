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


        public PointOfInterest GetPOIByCountry(string country)
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
                        CreatedDate = row.CreatedDate.ToShortDateString(),
                        CurrencyId = row.CurrencyId,
                        Id = row.Id,
                        Image = @"http://ec2-54-71-170-54.us-west-2.compute.amazonaws.com/POIImages/" + row.Image,
                        ModifiedBy = row.ModifiedBy,
                        ModifiedDate = row.ModifiedDate?.ToShortDateString(),
                        Name = row.Name,
                        Starts = row.Starts
                    });
                }
                Random rnd = new Random();
                int r = rnd.Next(temp.Count);
                return temp[r];
            }
        }

        public PointOfInterest GetPOIByCity(string country, string city)
        {
            try
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
                            CurrencyId = row.CurrencyId,
                            CreatedDate = row.CreatedDate.ToShortDateString(),
                            Id = row.Id,
                            Image = @"http://ec2-54-71-170-54.us-west-2.compute.amazonaws.com/POIImages/" + row.Image,
                            ModifiedBy = row.ModifiedBy,
                            ModifiedDate = row.ModifiedDate?.ToShortDateString(),
                            Name = row.Name,
                            Starts = row.Starts
                        });
                    }
                    Random rnd = new Random();
                    int r = rnd.Next(temp.Count);
                    return temp[r];
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public string getCountry(GetPOIByCityResult model)
        {
            return model.data.CountryName;
        }

        public string getCity(GetPOIByCityResult model)
        {
            return model.data.CityName;
        }

        public string getCurrency(GetPOIByCityResult model)
        {
            using (PointOfInterestRepository repository = new PointOfInterestRepository())
            {
                var data = repository.getCurrencySlug(model.data.CurrencyId);
                return data;
            }
        }

        public string getImage(GetPOIByCityResult model)
        {
            return model.data.Image;
        }
    }
}
