using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PalTripAdvisor.Models
{

    [DataContract]
    public class WeatherResponseDomainObjectWrapper
    {
        [DataMember]
        public List<WeatherResponseDomainObject> WeatherStatus { get; set; }
        [DataMember]
        public string MessageResponse { get; set; }
    }

    [DataContract]
    public class WeatherResponseDomainObject
    {
        [DataMember]
        public  string Day { get; set; }
        [DataMember]
        public decimal Degree { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        
        
    }
}