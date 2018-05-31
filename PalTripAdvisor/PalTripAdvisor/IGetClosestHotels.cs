using System;
using System.Collections.Generic;
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
        [WebGet(UriTemplate = "/getHotelsByCity/{city}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string getHotelsByCity(string city);
        [OperationContract]
        [WebGet(UriTemplate = "/getHotelsByCountry/{country}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<HotelsDomain> getHotelsByCountry(string country);
        [OperationContract]
        [WebGet(UriTemplate = "/getHotelsByCityAndCountry/{country}/{city}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<HotelsDomain> getHotelsByCityAndCountry(string country, string city);
        [OperationContract]
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
