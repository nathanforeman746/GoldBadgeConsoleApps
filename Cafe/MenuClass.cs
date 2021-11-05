using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuClass() { }
        public MenuClass(int id, string name, string description, string ingredients, decimal price)
        {
            ID = id;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
