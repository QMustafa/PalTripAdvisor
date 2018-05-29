﻿using DataLayer.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PalTripAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetClosestHotels" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetClosestHotels.svc or GetClosestHotels.svc.cs at the Solution Explorer and start debugging.
    public class GetClosestHotels : IGetClosestHotels
    {
        public string addRating(string id, string rating)
        {
            using (HotelsRepository repository = new HotelsRepository())
            {
                return repository.addRating(id, rating);
            }
        }



        /// <summary>
        /// Get a filtered list of Airplane assets.
        /// </summary>
        /// <remarks>Get a filtered list of airplane assets.</remarks>
        /// <param name="customerSlug">Customer slug.</param>
        /// <param name="filter">Request filter.</param>
        /// <response code="400">The filter is not valid.</response>
        /// <response code="500">Server error.</response>
        /// <returns></returns>
        public List<HotelsDomain> getHotelsByCity(string city)
        {
            using (HotelsRepository repository = new HotelsRepository())
            {
                var data = repository.GetHotelsByCity(city);
                var temp = new List<HotelsDomain>();
                foreach (var row in data)
                {
                    temp.Add(new HotelsDomain()
                    {
                        CityName = row.CityName,
                        CountyName = row.CountyName,
                        CreatedBy = row.CreatedBy,
                        CreatedDate = row.CreatedDate.ToShortDateString(),
                        AveragePrice = row.AveragePrice,
                        Id = row.Id,
                        Image = @"http://ec2-54-71-170-54.us-west-2.compute.amazonaws.com/POIImages/" + row.Image,
                        ModifiedBy = row.ModifiedBy,
                        ModifiedDate = row.ModifiedDate?.ToShortDateString(),
                        Name = row.Name,
                        Rating = row.Rating
                    });
                }

                return temp;
            }
        }

        public List<HotelsDomain> getHotelsByCityAndCountry(string country, string city)
        {
            using (HotelsRepository repository = new HotelsRepository())
            {
                var data = repository.GetHotelsByCityAndCountry(country, city);
                var temp = new List<HotelsDomain>();
                foreach (var row in data)
                {
                    temp.Add(new HotelsDomain()
                    {
                        CityName = row.CityName,
                        CountyName = row.CountyName,
                        CreatedBy = row.CreatedBy,
                        CreatedDate = row.CreatedDate.ToShortDateString(),
                        AveragePrice = row.AveragePrice,
                        Id = row.Id,
                        Image = @"http://ec2-54-71-170-54.us-west-2.compute.amazonaws.com/POIImages/" + row.Image,
                        ModifiedBy = row.ModifiedBy,
                        ModifiedDate = row.ModifiedDate?.ToShortDateString(),
                        Name = row.Name,
                        Rating = row.Rating
                    });
                }

                return temp;
            }
        }

        public List<HotelsDomain> getHotelsByCountry(string country)
        {
            using (HotelsRepository repository = new HotelsRepository())
            {
                var data = repository.GetHotelsByCountry(country);
                var temp = new List<HotelsDomain>();
                foreach (var row in data)
                {
                    temp.Add(new HotelsDomain()
                    {
                        CityName = row.CityName,
                        CountyName = row.CountyName,
                        CreatedBy = row.CreatedBy,
                        CreatedDate = row.CreatedDate.ToShortDateString(),
                        AveragePrice = row.AveragePrice,
                        Id = row.Id,
                        Image = @"http://ec2-54-71-170-54.us-west-2.compute.amazonaws.com/POIImages/" + row.Image,
                        ModifiedBy = row.ModifiedBy,
                        ModifiedDate = row.ModifiedDate?.ToShortDateString(),
                        Name = row.Name,
                        Rating = row.Rating
                    });
                }

                return temp;
            }
        }
    }
}
