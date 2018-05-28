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
        List<PointOfInterest> GetPOIByCountry(string country);
        [OperationContract]
        [WebGet(UriTemplate = "/GetPOIByCity/{country}/{city}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<PointOfInterest> GetPOIByCity(string country, string city);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddRating/{id}/{rating}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string addRating(string id, string rating);

    }

    [DataContract]
    public class PointOfInterest
    {
        [DataMember]
        public short Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public int? Starts { get; set; }
        [DataMember]
        public short CurrencyId { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string CreatedDate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public string ModifiedDate { get; set; }
    }
}
