﻿using CurrencyFeed.Models;
using DataLayer;
using DataLayer.Respositories;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyFeed
{
    public class CurrencyJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            using (CurrencyExchangeRepository repository = new CurrencyExchangeRepository())
            {
                try
                {
                    LoggesHelper.addLogs("Job triggered.");
                    List<Currency> currencies = repository.getAllCurrencies();
                    LoggesHelper.addLogs(currencies.Count + " Currencies found in db.");
                    List<CurrenciesExchanx> currenciesFactor = getFactors(currencies);
                    LoggesHelper.addLogs(currenciesFactor.Count + " Factors have been fetched from the api correctly.");
                    await repository.SaveCurrencyExchange(currenciesFactor);
                    LoggesHelper.addLogs(currenciesFactor.Count + " Factors have been successfully added to the CurrencyExchange table in the DB.");
                }
                catch(Exception ex)
                {
                    LoggesHelper.addLogs(ex.Message);
                }
            }
                
        }

        private List<CurrenciesExchanx> getFactors(List<Currency> currencies)
        {
            try
            {
                string url = "http://apilayer.net/api/live";
                string currenciesDestination = currencies.Select(_ => _.Slug).Aggregate((current, next) => current + "," + next);
                string quertStrings = string.Format("?{0}={1}&&{2}={3}&&{4}={5}&&{6}={1}", "access_key", "a089fbe5157c6c73295a3f29e9687d69", "currencies", currenciesDestination, "source", "USD", "format", "1");
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create((url + quertStrings));
                webrequest.Method = "GET";
                webrequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                string result = string.Empty;
                result = responseStream.ReadToEnd();
                webresponse.Close();
                CurrencyLayerResponse responseModel = bindJsonToModel(result);
                List<CurrenciesExchanx> dataToSave = mapResponseToEntity(responseModel);

                return dataToSave;
            }
            catch(Exception ex)
            {
                LoggesHelper.addLogs(ex.Message);
                return new List<CurrenciesExchanx>();
            }
            
        }

        private List<CurrenciesExchanx> mapResponseToEntity(CurrencyLayerResponse responseModel)
        {
            using (CurrencyExchangeRepository repository = new CurrencyExchangeRepository())
            {
                List<CurrenciesExchanx> models = new List<CurrenciesExchanx>();
                if (responseModel.Success)
                {
                    
                    foreach (var item in responseModel.Quotes)
                    {
                        string currensySlug = item.Description.Replace(responseModel.Source, "");
                        models.Add(new CurrenciesExchanx { CreatedBy = "CurrencyFeedJob", CreatedDate = DateTime.Now, ModifiedBy = "CurrencyFeedJob", ModifiedDate = DateTime.Now, OriginalCurrencyId = repository.getIdBySlug(responseModel.Source), TargetCurrencyId = repository.getIdBySlug(currensySlug), Factor = item.Factor });
                    }
                }
                return models;
            }

        }

        private CurrencyLayerResponse bindJsonToModel(string result)
        {

            dynamic temp = JsonConvert.DeserializeObject(result);

            var model = new CurrencyLayerResponse();
            model.Success = Convert.ToBoolean(temp.success.ToString().ToLower());
            model.Source = temp.source;
            var stringFactors = temp.quotes.ToString().Split(',');
            var factors = new List<CurrenciesFactors>();
            foreach(var item in stringFactors)
            {
                var splitted = item.Split(':');
                string desc = splitted[0].ToString();
                string num = splitted[1].ToString();
                var doubleArray = (Regex.Split(num, @"[^0-9\.]+").Where(c => c != "." && c.Trim() != "")).ToList<string>();
                decimal fact = Convert.ToDecimal(doubleArray[0]);
                var letters = new String(desc.Where(c => Char.IsLetter(c)).ToArray());
                var factor = new CurrenciesFactors { Description = letters, Factor = fact};
                factors.Add(factor);
            }
            model.Quotes = factors;

            return model;
        }
    }
}
