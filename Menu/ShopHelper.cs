using System;
using System.Collections.Generic;
using Homework_4.Exceptions;
using Homework_4.Models;

namespace Homework_4.Menu
{
    public static class ShopHelper
    {
        public static int GetPhonesByOperationSystem(Shop shop, OperationSystemType op)
        {
            int amount = 0;
            foreach (var phone in shop.Phones)
            {
                if (phone.IsAvailable && phone.OperationSystemType == op)
                {
                    amount++;
                }
            }

            return amount;
        }
        public static List<Phone> GetPhoneByModel(string model, Stores stores)
        {
            var phones = new List<Phone>();
            foreach (var shop in stores.Shops)
            {
                foreach (var phone in shop.Phones)
                {
                    if (phone.Model == model && phone.IsAvailable)
                    {
                        phones.Add(phone);
                    }
                    else if(phone.Model == model && !phone.IsAvailable)
                    {
                        throw new PhoneNotAvailableException();
                    }
                }
            }
            if(phones.Count == 0)
                throw new PhoneNotFoundException();
          
            return phones;
        }
        public static void PrintInfoAboutShops(Stores stores)
        {
            foreach (var store in stores.Shops)
            {
                foreach (var phone in store.Phones)
                {
                    Console.WriteLine("Model: " + phone.Model + "Market Launch Date" + phone.MarketLaunchDate + "Shop" + phone.Price + "Shop ID" + phone.ShopId);
                }
                Console.WriteLine("IOS Phones amount: " + GetPhonesByOperationSystem(store, OperationSystemType.IOS));
                Console.WriteLine("Android Phones amount: " + GetPhonesByOperationSystem(store, OperationSystemType.ANDROID));
            }
        }
        public static Shop GetShop(Stores stores, string shopName)
        {
            var shop = new Shop();
            shop = null;
            foreach (var item in stores.Shops)
            {
                if (item.Name == shopName)
                {
                    shop = item;
                }
            }
            if(shop == null)
            {
                throw new ShopNotFoundException();
            }
           
            return shop;
        }
        public static bool CheckIsModelAvailableAtShop(string model, Shop shop)
        {
            foreach(var phone in shop.Phones)
            {
                if (phone.Model == model && phone.IsAvailable == true)
                {
                    return true;
                }                    
            }
            return false;
        }
        public static void PrintAllAvailablePhones(List<Phone> listOfPhones)
        {
            foreach (var item in listOfPhones)
            {
                Console.WriteLine("Model: " + item.Model + "ShopID" + item.ShopId);
            }
        }
    }
}