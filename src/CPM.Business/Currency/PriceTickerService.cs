using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Currency
{
    public interface IPriceTickerService
    {
        PriceTickerInfoBM GetPriceTickerInfoSync(string cryptoCode, string fiatCode, string defaultFiatCode);
        Task<PriceTickerInfoBM> GetPriceTickerInfoAsync(string cryptoCode, string fiatCode, string defaultFiatCode);
        PriceTickerBM GetPriceTickerSync(string cryptoCode, string fiatCode, string defaultFiatCode, bool? includeMarkets = false);
        Task<PriceTickerBM> GetPriceTickerAsync(string cryptoCode, string fiatCode, string defaultFiatCode, bool? includeMarkets = false);
    }

    public class PriceTickerService : IPriceTickerService
    {
        #region _Async Methods_

        public async Task<PriceTickerBM> GetPriceTickerAsync(string cryptoCode, string fiatCode, string defaultFiatCode, bool? includeMarkets = false)
        {
            /* Set APi parameters*/
            string url = SetApi(cryptoCode, fiatCode, defaultFiatCode, includeMarkets ?? false);

            /* Call Api*/
            var results = await GetJsonAsync(url);

            /* Process json result*/
            return ProcessPriceTickerResult(results, includeMarkets ?? false);
        }
        
        public async Task<PriceTickerInfoBM> GetPriceTickerInfoAsync(string cryptoCode, string fiatCode, string defaultFiatCode)
        {
            /* Set APi parameters*/
            string url = SetApi(cryptoCode, fiatCode, defaultFiatCode,false);

            /* Call Api*/
            var results = await GetJsonAsync(url);

            /* Process json result*/
            return Mapper.Map<PriceTickerInfoBM>(ProcessPriceTickerResult(results,  false));
        }
        
        #endregion

        #region _Sync Methods_

        public PriceTickerInfoBM GetPriceTickerInfoSync(string cryptoCode, string fiatCode, string defaultFiatCode)
        {
            /* Set APi parameters*/
            string url = SetApi(cryptoCode, fiatCode, defaultFiatCode, false);

            /* Call Api*/
            var results = GetJsonSync(url);

            /* Process json result*/
            return Mapper.Map<PriceTickerInfoBM>(ProcessPriceTickerResult(results, false));
        }

        public PriceTickerBM GetPriceTickerSync(string cryptoCode, string fiatCode, string defaultFiatCode, bool? includeMarkets = false)
        {
            /* Set APi parameters*/
            string url = SetApi(cryptoCode, fiatCode, defaultFiatCode, includeMarkets ?? false);

            /* Call Api*/
            var results = GetJsonSync(url);

            /* Process json result*/
            return ProcessPriceTickerResult(results, includeMarkets ?? false);
        }
        
        #endregion

        #region _Private Methods_
        
        private string SetApi(string cryptoCode, string fiatCode, string defaultFiatCode, bool includeMarkets)
        {
            if (string.IsNullOrWhiteSpace(fiatCode))
            {
                fiatCode = defaultFiatCode;
            }

            /*Lookup prices from Cyptonator.com*/
            string callString = "";
            if (includeMarkets)
            {
                callString = "full";
            }
            else
            {
                callString = "ticker";
            }
            var encodedCryptoCode = WebUtility.UrlEncode(cryptoCode);
            var encodedFiatCode = WebUtility.UrlEncode(fiatCode);
            return  $"https://www.cryptonator.com/api/{callString}/{encodedCryptoCode}-{encodedFiatCode}";
        }

        private PriceTickerBM ProcessPriceTickerResult(JObject results, bool includeMarkets)
        {
            var priceTicker = new PriceTickerBM();
            if (results == null)
            {
                priceTicker.Success = (bool)results["success"];
                priceTicker.Error = "Unknown Error Calling Price API";
                return priceTicker;
            }
            else if (!(bool)results["success"])
            {
                priceTicker.Success = (bool)results["success"];
                priceTicker.Error = (string)results["error"];
                priceTicker.UnitTimeStamp = 0;
                return priceTicker;
            }
            else
            {
                priceTicker.Success = (bool)results["success"];
                priceTicker.Error = (string)results["error"];
                priceTicker.UnitTimeStamp = (int)results["timestamp"];
                var inner_1 = JsonConvert.SerializeObject(results["ticker"]);
                var innerResult_1 = JObject.Parse(inner_1);

                priceTicker.CryptoCode = (string)innerResult_1["base"];
                priceTicker.FiatCode = (string)innerResult_1["target"];
                priceTicker.Price = (decimal)innerResult_1["price"];
                if (string.IsNullOrWhiteSpace((string)innerResult_1["volume"])) { priceTicker.Volume = 0.0m; }
                else
                { priceTicker.Volume = (decimal)innerResult_1["volume"]; }
                priceTicker.Change = (decimal)innerResult_1["change"];

                if (includeMarkets)
                {
                    var inner_2 = JsonConvert.SerializeObject(innerResult_1["markets"]);

                    foreach (var item in JArray.Parse(inner_2))
                    {
                        var inner_3 = JsonConvert.SerializeObject(item);
                        var innerResult_3 = JObject.Parse(inner_3);

                        priceTicker.Markets.Add(new PriceMarketBM()
                        {
                            Market = (string)innerResult_3["market"],
                            Price = (decimal)innerResult_3["price"],
                            Volume = (decimal)innerResult_3["volume"]
                        });
                    }
                }

                return priceTicker;
            }
        }

        private JObject GetJsonSync(string url)
        {
            var client = new HttpClient();
            var task = client.GetStringAsync(url);
            task.Wait();
            return JObject.Parse(task.Result);
        }

        private async Task<JObject> GetJsonAsync(string url)
        {
            var client = new HttpClient();
            string json = await client.GetStringAsync(url);
            var results = JObject.Parse(json);

            return results;
        }

        #endregion
    }
}
