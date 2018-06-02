using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PalTripAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetClosestHotels" in both code and config file together.
    [ServiceContract]
    public interface IGetClosestHotels
    {
        [OperationContract]
        [Description("Get the closest hotels according to the city name.")]
        [WebGet(UriTemplate = "/getHotelsByCity/{city}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
        HotelsDomain getHotelsByCity(string city);
        [OperationContract]
        [Description("Get the closest hotels according to the country name.")]
        [WebGet(UriTemplate = "/getHotelsByCountry/{country}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<HotelsDomain> getHotelsByCountry(string country);
        [OperationContract]
        [Description("Get the closest hotels according to both country & city names.")]
        [WebGet(UriTemplate = "/getHotelsByCityAndCountry/{country}/{city}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<HotelsDomain> getHotelsByCityAndCountry(string country, string city);
        [OperationContract]
        [Description("Rate a specific hotel by doing a post request on this endpoint with the id of the hotel, and the rating between 1 to 5.")]
        [WebInvoke(Method = "POST", UriTemplate = "/AddRating/{id}/{rating}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string addRating(string id, string rating);

    }

    [DataContract]
    public class HotelsDomain
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "CountyName")]
        public string CountyName { get; set; }
        [DataMember(Name = "CityName")]
        public string CityName { get; set; }
        [DataMember(Name = "Rating")]
        public int Rating { get; set; }
        [DataMember(Name = "Image")]
        public string Image { get; set; }
        [DataMember(Name = "AveragePrice")]
        public decimal AveragePrice { get; set; }
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [DataMember(Name = "CreatedDate")]
        public string CreatedDate { get; set; }
        [DataMember(Name = "ModifiedBy")]
        public string ModifiedBy { get; set; }
        [DataMember(Name = "ModifiedDate")]
        public string ModifiedDate { get; set; }
}
    
}
