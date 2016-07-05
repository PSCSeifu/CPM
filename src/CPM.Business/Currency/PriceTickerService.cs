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
         Task<PriceTickerBM> GetPriceTicker(string cryptoCode, string fiatCode, bool? includeMarkets = false);
    }

    public class PriceTickerService : IPriceTickerService
    {
        IConfiguration Configuration { get; set; }

        public PriceTickerService()
        {

        }

        
        private async Task<JObject> APICall(string url)
        {
            var client = new HttpClient();
            string json = await client.GetStringAsync(url);
            return JObject.Parse(json);
        }

        public  async Task<PriceTickerBM> GetPriceTicker(string cryptoCode, string fiatCode , bool? includeMarkets = false)
        {
            if (string.IsNullOrWhiteSpace(fiatCode))
            {
                fiatCode = Configuration["PriceService:DefaultFiatCurrency"];
            }

            /*Lookup prices from Cyptonator.com*/
            var priceTicker = new PriceTickerBM();
            string callString = "";
            if (includeMarkets ?? false)
            {
                callString = "full";
            }
            else
            {
                callString = "ticker";
            }
            var encodedCryptoCode = WebUtility.UrlEncode(cryptoCode);
            var encodedFiatCode = WebUtility.UrlEncode(fiatCode);
            var url = $"https://www.cryptonator.com/api/{callString}/{encodedCryptoCode}-{encodedFiatCode}";

            /* Call Api*/
            var client = new HttpClient();
            string json = await client.GetStringAsync(url);
            var results = JObject.Parse(json);
            

            /* Process json result*/
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
                priceTicker.UnitTimeStamp = (int)results["timestamp"];
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
                priceTicker.Volume = (decimal)innerResult_1["volume"];
                priceTicker.Change = (decimal)innerResult_1["change"];              

                if (includeMarkets ?? false)
                {                             
                    var inner_2 = JsonConvert.SerializeObject(innerResult_1["markets"]);

                    foreach (var item in JArray.Parse(inner_2))
                    {
                        var inner_3 = JsonConvert.SerializeObject(item);
                        var innerResult_3 = JObject.Parse(inner_3);

                        PriceMarketBM priceMarket = new Currency.PriceMarketBM();
                        priceMarket.Market = (string)innerResult_3["market"];
                        priceMarket.Price = (decimal)innerResult_3["price"];
                        priceMarket.Volume = (decimal)innerResult_3["volume"];
                        priceTicker.Markets.Add(priceMarket);
                        //priceTicker.Markets.Add(new PriceMarketBM()
                        //{
                        //    Market = (string)innerResult_3["market"],
                        //    Price = (decimal)innerResult_3["price"],
                        //    Volume = (decimal)innerResult_3["volume"]
                        //});
                    }
                }

                return priceTicker;
            }

        }
        

        private async Task<JObject> GetJsonAsync(string url)
        {
            var client = new HttpClient();
            string json = await client.GetStringAsync(url);
            var results = JObject.Parse(json);

            return results;
        }

        private JObject GetJsonSync(string url)
        {
            var client = new HttpClient();
            var task = client.GetStringAsync(url);
            task.Wait();
            return JObject.Parse(task.Result);
        }
    }
}
