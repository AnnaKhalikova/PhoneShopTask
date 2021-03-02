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
        public static List<Phone> ChoosePhoneModel(Stores stores)
        {
            List<Phone> listOfPhones = new List<Phone>();
            while (true)
            {
                Console.WriteLine("Какой телефон вы желаете приобрести");
                string model = Console.ReadLine();
                try
                {
                    listOfPhones = ShopHelper.GetPhoneByModel(model, stores);
                    break;
                }
                catch (PhoneNotAvailableException)
                {
                    Console.WriteLine("Данный товар отсутствует на складе. Выберите, пожалуйста, другую модель: ");
                }
                catch (PhoneNotFoundException)
                {
                    Console.WriteLine("Введенный Вами товар не найден. Выберите, пожалуйста, другую модель: ");
                }
            }
            return listOfPhones;
        }
        public static void OrderPhone(Phone phone, Stores stores)
        {
            Shop shop = new Shop();
            while (true)
            {
                Console.WriteLine($"В каком магазине вы хотите приобрести {phone.Model}?");
                string shopName = Console.ReadLine();
                try
                {
                    shop = ShopHelper.GetShop(stores, shopName);
                    if (ShopHelper.CheckIsModelAvailableAtShop(phone.Model, shop))
                        Console.WriteLine($"Заказ {phone.Model} на сумму {phone.Price} успешно оформлен!");
                    else
                        throw new PhoneNotAvailableException();
                    break;
                }
                catch (ShopNotFoundException)
                {
                    Console.WriteLine("Магазин не найден! Повторите ввод названия магазина:");
                }
                catch (PhoneNotAvailableException)
                {
                    Console.WriteLine("Данная модель недоступна в магазине " + shop.Name + " . Пожалуйста, выберите другой магазин:");
                }
            }
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