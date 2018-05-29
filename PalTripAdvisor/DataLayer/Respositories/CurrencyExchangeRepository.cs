using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalTripAdvisor.Models;

namespace DataLayer.Respositories
{
    public class CurrencyExchangeRepository : IDisposable
    {
        private readonly PalTripAdvisorServicesEntities db;
        public CurrencyExchangeRepository()
        {
            db = new PalTripAdvisorServicesEntities();
        }

        public void Dispose()
        {
            
        }

        public CurrencyExchangeResponseModel ExvhangeCurrency(string from, string to)
        {
            var original = this.db.Currencies.FirstOrDefault(_ => _.Slug.Contains(from.Trim()));
            var targeted = this.db.Currencies.FirstOrDefault(_ => _.Slug.Contains(to.Trim()));
            if (original == null)
            {
                return new CurrencyExchangeResponseModel { Factor = null, MessageResponse = "404, original currency does not exist, please make sure you entered the correct slug" };
            }
            if (targeted == null)
            {
                return new CurrencyExchangeResponseModel { Factor = null, MessageResponse = "404, targeted currency does not exist, please make sure you entered the correct slug" };
            }

            var tuple = db.CurrenciesExchanges
                .Where(_ => _.OriginalCurrencyId.Equals(original.Id) && _.TargetCurrencyId.Equals(targeted.Id))
                .OrderByDescending(_ => _.ModifiedDate).FirstOrDefault();

            if (tuple == null)
            {
                return new CurrencyExchangeResponseModel { Factor = null, MessageResponse = "404, this factor does not exist" };
            }

            return new CurrencyExchangeResponseModel { Factor = tuple.Factor, MessageResponse = "200, factor exist." };
        }

        public async Task SaveCurrencyExchange(List<CurrenciesExchanx> currenciesFactor)
        {
            foreach(var item in currenciesFactor)
            {
                db.CurrenciesExchanges.Add(item);
                await db.SaveChangesAsync();
            }
        }

        public List<Currency> getAllCurrencies()
        {
            
            var data = db.Currencies.ToList<Currency>();
            return data;
        }
    }
}
