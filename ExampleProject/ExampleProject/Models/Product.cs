using System;
namespace ExampleProject.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set;}

        public Product(string name, double price , Category category)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;

        }

    }
}
