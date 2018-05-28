using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalTripAdvisor.Models
{
    public class CurrencyExchangeResponseModel
    {
        public decimal? Factor { get; set; }
        public  string MessageResponse { get; set; }
    }
}