using Homework_4.Exceptions;
using Homework_4.JSON;
using Homework_4.Menu;
using Homework_4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var stores = JsonConvert.DeserializeObject<Stores>(ExtendedJsonReader.ReadFile());

            //3 task with exception handling
            Console.WriteLine("Какой телефон вы желаете приобрести");
            string model = Console.ReadLine();
            List<Phone> listOfPhones;
            try
            {
                listOfPhones = ShopHelper.GetPhoneByModel(model, stores);
            }
            catch (PhoneNotAvailableException)
            {
                Console.WriteLine("Данный товар отсутствует на складе");
            }
            catch (PhoneNotFoundException)
            {
                Console.WriteLine("Введенный Вами товар не найден");
            }

       
            //bool isShopNotFound = true;
            //Console.WriteLine($"В каком магазине вы хотите приобрести {listOfPhones[0].Model} ?");
            //string shopName = null;

            //while (isShopNotFound)
            //{
            //    shopName = Console.ReadLine();
            //    if (ShopHelper.GetShop(stores, shopName) != null)
            //    {                  
            //        if (ShopHelper.CheckIsModelAvailableAtShop(model, ShopHelper.GetShop(stores, shopName))){
            //            Console.WriteLine($"Заказ {phoneForOrdering.Model} на сумму {phoneForOrdering.Price} успешно оформлен!");
            //            isShopNotFound = false;
            //        }
            //        else
            //        {
            //            isShopNotFound = true;
            //            Console.WriteLine("Данная модель недоступна в выбранном вами магазине. Повторите выбор магазина");
            //        }                    
            //    }
            //    else
            //    {
            //        isShopNotFound = true;
            //        Console.WriteLine("Магазин, который вы ввели не найден. Повторите попыткук ввода: ");                   
            //    }
            //}            
        }
    }
}