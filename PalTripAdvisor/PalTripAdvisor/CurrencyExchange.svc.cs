using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer;
using DataLayer.Respositories;
using PalTripAdvisor.Models;

namespace PalTripAdvisor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CurrencyExchange" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CurrencyExchange.svc or CurrencyExchange.svc.cs at the Solution Explorer and start debugging.
    public class CurrencyExchange : ICurrencyExchange
    {
        private readonly CurrencyExchangeRepository repository;
        public CurrencyExchange()
        {
            this.repository = new CurrencyExchangeRepository();
        }

        public CurrencyExchangeResponseModel ExvhangeCurrency(string from, string to)
        {
            var temp = repository.ExvhangeCurrency(from, to);
            return new CurrencyExchangeResponseModel { Factor = temp.Factor, MessageResponse = temp.MessageResponse};
        }
    }
}
