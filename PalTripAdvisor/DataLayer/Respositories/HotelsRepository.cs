using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Respositories
{
    public class HotelsRepository : IDisposable
    {
        private static PalTripAdvisorServicesEntities db = new PalTripAdvisorServicesEntities();
        public List<Hotel> GetHotelsByCountry(string country)
        {

            return db.Hotels.Where(_ => _.CountyName.ToLower().Contains(country.ToLower().Trim())).ToList<Hotel>();


        }

        public List<Hotel> GetHotelsByCity(string city)
        {
            var data = db.Hotels.Where(_ => _.CityName.ToLower().Contains(city.ToLower().Trim())).ToList<Hotel>();
            return data;


        }
        public List<Hotel> GetHotelsByCityAndCountry(string country, string city)
        {
            var data = db.Hotels.Where(_ => _.CountyName.ToLower().Contains(country.ToLower().Trim()) && _.CityName.ToLower().Contains(city.ToLower().Trim())).ToList<Hotel>();
            return data;


        }

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

            var hotel = db.Hotels.FirstOrDefault(_ => _.Id.Equals(tempId));
            if (tempRating > 1 && tempRating < 5)
            {
                if (hotel != null)
                {
                    hotel.Rating += tempRating;
                    db.SaveChanges();
                    return "200, your rating has been submitted successfully, Thank you!";
                }
                else
                {
                    return "404, this hotel does not exist, please add correct id.";
                }
            }
            else
            {
                return "Wrong rating, please choose a number between 1 to 5";

            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
