using CPM.Data.Entities;
using CPM.Data.Offer;
using CPM.Data.Wallet;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Data
{
    public class EnsureSeedData
    {        

        public EnsureSeedData()
        {
           
        }
              
        
        public void EnsureSeedWalletData(string filePath)
        {
            WalletContext walletContext = new WalletContext();
            if (!walletContext.Wallets.Any())
            {
                dynamic jsonData = ReadJsonFile(filePath);
                if (jsonData != null)
                {
                    foreach (dynamic d in jsonData)
                    {
                        walletContext.Wallets.Add(new WalletEntity()
                        {
                            ClientId = d.ClientId,
                            Name = d.Name,
                            Balance = d.Balance,
                            IsLocked = d.IsLocked,
                            Currency = d.Currency,
                            DateCreated = d.DateCreated,
                            DateModified = d.DateModified,
                            WalletTypeId = 1
                        });
                    }
                    walletContext.SaveChanges();
                }
            }
        }

        public void EnsureWalletTypeSeedData(string filePath)
        {
            WalletContext walletContext = new WalletContext();
            if (!walletContext.WalletTypes.Any())
            {
                dynamic jsonData = ReadJsonFile(filePath);
                if (jsonData != null)
                {
                    foreach (dynamic d in jsonData)
                    {
                        walletContext.WalletTypes.Add(new WalletTypeEntity()
                        {
                            Name = d.Name,
                            Category = d.Category,
                            Description = d.Description
                        });
                    }
                    walletContext.SaveChanges();
                }
            }
        }

        public void EnsureSeedOfferData(string filePath)
        {
            OfferContext offerContext = new OfferContext();
            if (!offerContext.Offers.Any())
            {
                dynamic jsonData = ReadJsonFile(filePath);
                if (jsonData != null)
                {
                    foreach (dynamic d in jsonData)
                    {
                        offerContext.Offers.Add(new OfferEntity()
                        {
                           
                            ClientId =d.ClientId,
                            WalletId  = d.WalletId,
                            DefaultCurrencyId = d.DefaultCurrencyId,
                            DateCreated = d.DateCreated,
                            ExpiryDate = d.ExpiryDate,
                            Name = d.Name,
                           Detail = d.Detail
                        });
                    }
                    offerContext.SaveChanges();
                }
            }
        }

        private static dynamic ReadJsonFile(string filePath)
        {
            //Read seed json file
            JArray jarray = JArray.Parse(File.ReadAllText(filePath)) as JArray;
            if (jarray != null)
            {
                dynamic jsonData = jarray;
                return jsonData;
            }
            return new JArray();
        }   
    }
}
