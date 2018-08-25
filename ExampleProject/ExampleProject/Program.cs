using System;
using System.Data;
using ExampleProject.Enums;
using ExampleProject.Models;

namespace ExampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample creating a new category
            Category food = new Category("food");

            // Products
            Product apple = new Product("Apple", 100.0, food);
            Product almond = new Product("Almonds", 150.0, food);


            // Products can be added to shopping cart with quantity
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);


            // discounts rules can be 20% on a category if bought more than 3 items
            Campaign campaign1 = new Campaign(food, 20.0, DiscountType.Rate, 3);
            // another campaign rule 50% on category if bought more than 5 items
            Campaign campaign2 = new Campaign(food, 50.0, DiscountType.Rate, 5);
            // another campaign rule 5 TL amount discount on a category if bought more than 7 items
            Campaign campaign3 = new Campaign(food, 5.0, DiscountType.Amount, 7);

            // Cart should apply the maximum amount of discount to the cart.
            cart.ApplyDiscounts(campaign1, campaign2, campaign3);


            Coupon coupon = new Coupon(100, 10, DiscountType.Rate);

            cart.ApplyCoupon(coupon);

            double fixedCost = 2.99;

            //i didn't understand costPerDelivery and costPerProduct value in documention that's why assign static value 
            int costPerDelivery = 10;
            int costPerProduct = 20;

            DeliveryCostCalculator deliveryCostCalculator = new DeliveryCostCalculator(costPerDelivery, costPerProduct, fixedCost);

            deliveryCostCalculator.CalculateFor(cart);

            Console.WriteLine("Total Amount After Discount => " + cart.GetTotalAmountAfterDiscounts());
            Console.WriteLine("Coupon Discount => "+ cart.GetCouponDiscount());
            Console.WriteLine("Campaign Discount =>" +cart.GetCampaignDiscount());
            Console.WriteLine("Delivery Cost =>" + cart.GetDeliveryCost());

            cart.Print();
 
        }
    }
}
