using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PalTripAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPointsOfInterest" in both code and config file together.
    [ServiceContract]
    public interface IPointsOfInterest
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetPOIByCountry/{country}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        PointOfInterest GetPOIByCountry(string country);
        [OperationContract]
        [WebGet(UriTemplate = "/GetPOIByCity/{country}/{city}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        PointOfInterest GetPOIByCity(string country, string city);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddRating/{id}/{rating}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string addRating(string id, string rating);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getCountry", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getCountry(GetPOIByCityResult model);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getCity", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getCity(GetPOIByCityResult model);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getCurrency", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getCurrency(GetPOIByCityResult model);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getImage", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getImage(GetPOIByCityResult model);



    }

    [DataContract]
    public class GetPOIByCityResult
    {
        [DataMember(Name = "GetPOIByCityResult")]
        public PointOfInterest data { set; get; }
    }

    [DataContract]
    public class PointOfInterest
    {
        [DataMember(Name = "Id")]
        public short Id { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Image")]
        public string Image { get; set; }
        [DataMember(Name = "CityName")]
        public string CityName { get; set; }
        [DataMember(Name = "CountryName")]
        public string CountryName { get; set; }
        [DataMember(Name = "Starts")]
        public int? Starts { get; set; }
        [DataMember(Name = "CurrencyId")]
        public short CurrencyId { get; set; }
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
