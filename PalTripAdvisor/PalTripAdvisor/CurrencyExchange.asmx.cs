using DataLayer.Respositories;
using PalTripAdvisor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PalTripAdvisor
{
    /// <summary>
    /// Summary description for CurrencyExchange1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CurrencyExchange1 : System.Web.Services.WebService
    {

        [WebMethod]
        public CurrencyExchangeResponseDomainModel ExchangeCurrency(string from, string to)
        {
            CurrencyExchangeRepository repository = new CurrencyExchangeRepository();
            var temp = repository.ExvhangeCurrency(from, to);
            return new CurrencyExchangeResponseDomainModel { Factor = temp.Factor, MessageResponse = temp.MessageResponse };
        }
    }
}
