using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFeed.Models
{
    public class CurrencyLayerResponse
    {
        //{"success":true,"terms":"https:\/\/currencylayer.com\/terms","privacy":"https:\/\/currencylayer.com\/privacy","timestamp":1527578648,"source":"USD","quotes":{"USDGBP":0.752831,"USDUSD":1}}
        public bool Success { set; get; }
        public string Source { set; get; }
        public List<CurrenciesFactors> Quotes { set; get; }
    }

    public class CurrenciesFactors
    {
        public string Description { set; get; }
        public decimal Factor { set; get; }
    }
}
