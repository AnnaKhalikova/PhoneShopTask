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
            List<Phone> listOfPhones = ShopHelper.ChoosePhoneModel(stores);

            //4 task
            ShopHelper.OrderPhone(listOfPhones[0], stores);
        }
    }
}