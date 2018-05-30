using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PalTripAdvisor.Models
{
    [DataContract]
    public class CurrencyExchangeResponseDomainModel
    {
        [DataMember]
        public decimal? Factor { get; set; }
        
        [DataMember]
        public  string MessageResponse { get; set; }
    }
}