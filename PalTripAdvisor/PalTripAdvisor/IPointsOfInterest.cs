using DataLayer;
using SwaggerWcf.Attributes;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPointsOfInterest" in both code and config file together.
    [ServiceContract]
    public interface IPointsOfInterest
    {
        [SwaggerWcfPath("Create book", "Create a book on the store")]
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
        string getCountry(GetPOIByCountryResult model);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getCity", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getCity(GetPOIByCityResult model);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getCurrency", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getCurrency(GetPOIByCityResult model);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getCurrency2", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getCurrency2(GetPOIByCountryResult model);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getImage", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getImage(GetPOIByImageResult model);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/getZipCode", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string getZipCode(GetPOIByCityResult model);



    }


    [DataContract(Name = "book")]
    [Description("Book with title, first publish date, author and language")]
    [SwaggerWcfDefinition(ExternalDocsUrl = "http://en.wikipedia.org/wiki/Book", ExternalDocsDescription = "Description of a book")]
    public class GetPOIByImageResult
    {
        [DataMember(Name = "GetPOIByCurrencyResult")]
        [Description("Book ID")]
        public PointOfInterest data { set; get; }
    }


    [DataContract(Name = "book")]
    [Description("Book with title, first publish date, author and language")]
    [SwaggerWcfDefinition(ExternalDocsUrl = "http://en.wikipedia.org/wiki/Book", ExternalDocsDescription = "Description of a book")]
    public class GetPOIByCurrencyResult
    {
        [DataMember(Name = "GetPOIByCurrencyResult")]
        [Description("Book ID")]
        public PointOfInterest data { set; get; }
    }

    [DataContract(Name = "book")]
    [Description("Book with title, first publish date, author and language")]
    [SwaggerWcfDefinition(ExternalDocsUrl = "http://en.wikipedia.org/wiki/Book", ExternalDocsDescription = "Description of a book")]
    public class GetPOIByZipCodeResult
    {
        [DataMember(Name = "GetPOIByZipCodeResult")]
        [Description("Book ID")]
        public PointOfInterest data { set; get; }
    }


    [DataContract(Name = "book")]
    [Description("Book with title, first publish date, author and language")]
    [SwaggerWcfDefinition(ExternalDocsUrl = "http://en.wikipedia.org/wiki/Book", ExternalDocsDescription = "Description of a book")]
    public class GetPOIByCountryResult
    {
        [DataMember(Name = "GetPOIByCountryResult")]
        [Description("Book ID")]
        public PointOfInterest data { set; get; }
    }

    [DataContract(Name = "book")]
    [Description("Book with title, first publish date, author and language")]
    [SwaggerWcfDefinition(ExternalDocsUrl = "http://en.wikipedia.org/wiki/Book", ExternalDocsDescription = "Description of a book")]
    public class GetPOIByCityResult
    {
        [DataMember(Name = "GetPOIByCityResult")]
        [Description("Book ID")]
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
        [DataMember(Name = "ZipCode")]
        public string ZipCode { set; get; }
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
