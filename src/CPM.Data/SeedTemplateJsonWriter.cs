using CPM.Data.Entities;
using CPM.Data.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace CPM.Data
{
    public class SeedTemplateJsonWriter
    {
        public SeedTemplateJsonWriter()
        {

        }

        public void CreateClient (string filePath)
        {
            //ApplicationuUser  / CLient here
        }

        public void CreateWalletType(string filePath)
        {
            List<WalletTypeEntity> walletTypes = new List<WalletTypeEntity>();
            walletTypes.Add(new WalletTypeEntity()
            {
                Name = "Shopping",
                Category = 1,
                Description = "Used for Buying, Selling"
            });
        }

        public void CreateWallet(string filePath)
        {
            List<WalletEntity> wallets = new List<WalletEntity>();
            wallets.Add(new WalletEntity()
            {
                ClientId = 1,
                Name = "MyPurse",
                ImageId =1,
                Balance = 523.5m,
                IsLocked = false,
                Currency = "ETH",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            });
            Writer(filePath, wallets);
        }


        public void CreateOffer(string filePath)
        {
            List<OfferEntity> offers = new List<OfferEntity>();
            offers.Add( new OfferEntity()
            {
                Id = 1,
                ClientId = 1,
                Name = "Half_Price_Extras",
                WalletId = 2,
                DateCreated = DateTime.UtcNow,
                DefaultCurrencyId = 1,
                ExpiryDate = new DateTime(2017, 01, 01),
                Detail = "Very short time Limited offer on stuff, Great stuff, huuge stuff,I tell you...great stuff!"
            });

            offers.Add(new OfferEntity()
            {
                Id = 2,
                ClientId = 1,
                Name = "Summer Crypto Discount",
                WalletId = 2,
                DateCreated = DateTime.UtcNow,
                DefaultCurrencyId = 1,
                ExpiryDate = new DateTime(2016, 08, 13),
                Detail = "Great summmer deals on the big names in crypto."
            });

            offers.Add(new OfferEntity()
            {
                Id = 3,
                ClientId = 2,
                Name = "Home Decor Discount",
                WalletId = 4,
                DateCreated = DateTime.UtcNow,
                DefaultCurrencyId = 1,
                ExpiryDate = new DateTime(2016, 11, 25),
                Detail = "Up to one third off on DIY tools!"
            });

            Writer(filePath, offers);
        }


        private  void Writer<T>(string filePath, T list)
        {
            string json = JsonConvert.SerializeObject(list);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(json);
            }
        }
        
    }
}
