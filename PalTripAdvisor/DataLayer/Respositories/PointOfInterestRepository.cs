using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Respositories
{
    public class PointOfInterestRepository :IDisposable
    {
        private  static  PalTripAdvisorServicesEntities db = new PalTripAdvisorServicesEntities();
        public string addRating(string id, string rating)
        {

            int tempRating;
            if (!int.TryParse(rating.Trim(), out tempRating))
            {
                return "500, bad rating, please only use numbers.";
            }

            short tempId;
            if (!short.TryParse(id.Trim(), out tempId))
            {
                return "500, bad id, please only use numbers.";
            }

            var point = db.PointOfInterests.FirstOrDefault(_ => _.Id.Equals(tempId));
            if (tempRating > 1 && tempRating < 5)
            {
                if (point != null)
                {
                    point.Starts += tempRating;
                    db.SaveChanges();
                    return "200, your rating has been submitted successfully, Thank you!";
                }
                else
                {
                    return "404, this point of interest does not exist, please add correct id.";
                }
            }
            else
            {
                return "Wrong rating, please choose a number between 1 to 5";

            }

        }


        public List<PointOfInterest> GetPOIByCountry(string country)
        {

                return db.PointOfInterests.Where(_ => _.CountryName.ToLower().Contains(country.ToLower().Trim())).ToList<PointOfInterest>();
            
            
        }

        public List<PointOfInterest> GetPOIByCity(string country, string city)
        {
                var data = db.PointOfInterests.Where(_ => _.CountryName.ToLower().Contains(country.ToLower().Trim()) && _.CityName.ToLower().Contains(city.ToLower().Trim())).ToList<PointOfInterest>();
                return data;
            
                
        }

        public void Dispose()
        {
        }
    }
}
