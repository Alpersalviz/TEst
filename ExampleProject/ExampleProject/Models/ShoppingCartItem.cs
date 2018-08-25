using System;
namespace ExampleProject.Models
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }


        public double Discount{ get; set;}

        public ShoppingCartItem(Product product , int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;

        }

        public double GetTotalPrice(){
            return Product.Price * Quantity;
        }

    }

}
