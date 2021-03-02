﻿using System;
using System.Collections.Generic;
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
                    if (phone.Model == model)
                    {
                        phones.Add(phone);
                    }
                }
            }
           
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
        public static List<Shop> GetShop(Stores stores)
        {
            var shops = new List<Shop>();
            foreach (var shop in stores.Shops)
            {
                shops.Add(shop);
            }

            return shops;
        }
    }
}