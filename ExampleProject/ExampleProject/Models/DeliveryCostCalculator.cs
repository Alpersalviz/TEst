using System;
using System.Linq;
namespace ExampleProject.Models
{
    public class DeliveryCostCalculator
    {

        public double CostPerDelivery { get; set; }
        public double CostPerProduct { get; set; }
        public double FixedCost { get; set; }


        public DeliveryCostCalculator(double costPerDelivery,double costPerProduct,double fixedCost)
        {
            this.CostPerDelivery = costPerDelivery;
            this.CostPerProduct = costPerProduct;
            this.FixedCost = fixedCost;
        }

        public double CalculateFor(ShoppingCart cart){

            if (cart.Items.Count() == 0)
                return 0;
            
            var numberofDeliveries = cart.Items.GroupBy(g => g.Product.Category).Count();
            var numberofProducts = cart.Items.GroupBy(g => g.Product).Count();  


            cart.DeliveryCost = (this.CostPerDelivery * numberofDeliveries) + (this.CostPerProduct * numberofProducts) + this.FixedCost;

            return  cart.DeliveryCost;
        }
    }
}
