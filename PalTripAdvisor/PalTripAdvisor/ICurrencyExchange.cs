using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PalTripAdvisor.Models;

namespace PalTripAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICurrencyExchange" in both code and config file together.
    [ServiceContract]
    public interface ICurrencyExchange
    {
        [OperationContract]
        CurrencyExchangeResponseModel ExchangeCurrency(string from, string to);
    }
}
