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
