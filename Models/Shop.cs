using System.Collections.Generic;

namespace Homework_4.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Phone> Phones { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nDescription: { Description}";
        }
    }
}


