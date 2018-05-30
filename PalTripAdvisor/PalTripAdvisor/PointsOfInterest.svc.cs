﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using DataLayer;
using DataLayer.Respositories;
using SwaggerWcf.Attributes;

namespace PalTripAdvisor
{
    [SwaggerWcf("/v2/rest")]
    [SwaggerWcfServiceInfo(
        title: "SampleService",
        version: "0.0.1",
        Description = "Sample Service to test SwaggerWCF",
        TermsOfService = "Terms of Service"
    )]
    [SwaggerWcfContactInfo(
        Name = "Abel Silva",
        Url = "http://github.com/abelsilva",
        Email = "no@e.mail"
    )]
    [SwaggerWcfLicenseInfo(
        name: "Apache License 2.0",
        Url = "https://github.com/abelsilva/SwaggerWCF/blob/master/LICENSE"
    )]
    public class PointsOfInterest : IPointsOfInterest
    {
        public string addRating(string id, string rating)
        {
            using (PointOfInterestRepository repository = new PointOfInterestRepository())
            {
                return repository.addRating(id, rating);
            }
               
        }

        [SwaggerWcfTag("Books")]
        [SwaggerWcfResponse(HttpStatusCode.Created, "Book created, value in the response body with id updated")]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Bad request", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError,
        "Internal error (can be forced using ERROR_500 as book title)", true)]
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
                        ZipCode = row.ZipCode.ToString(),
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
                            ZipCode = row.ZipCode.ToString(),
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

        public string getCountry(GetPOIByCountryResult model)
        {
            return model.data.CountryName;
        }

        public string getCity(GetPOIByCityResult model)
        {
            return model.data.CityName;
        }

        public string getCurrency(GetPOIByCurrencyResult model)
        {
            using (PointOfInterestRepository repository = new PointOfInterestRepository())
            {
                var data = repository.getCurrencySlug(model.data.CurrencyId);
                return data;
            }
        }

        public string getImage(GetPOIByImageResult model)
        {
            return model.data.Image;
        }

        public string getZipCode(GetPOIByZipCodeResult model)
        {
            return model.data.ZipCode;
        }
    }
}
