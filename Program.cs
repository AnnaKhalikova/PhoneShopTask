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


            //4 task
            Shop shop = new Shop();
            while (true)
            {             
                Console.WriteLine($"В каком магазине вы хотите приобрести {listOfPhones[0].Model}?");
                string shopName = Console.ReadLine();
                try
                {
                    shop = ShopHelper.GetShop(stores, shopName);
                    if (ShopHelper.CheckIsModelAvailableAtShop(listOfPhones[0].Model, shop))
                        Console.WriteLine($"Заказ {listOfPhones[0].Model} на сумму {listOfPhones[0].Price} успешно оформлен!");
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
    }
}