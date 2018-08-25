using System;
using ExampleProject.Models;
using ExampleProject.Enums;
using Xunit;
using System.Collections.Generic;

namespace ExampleProject.xUnit
{
    public class UnitTest1
    {
        ShoppingCart cart = new ShoppingCart();


        Category food = new Category("food");
        // discounts rules can be 20% on a category if bought more than 3 items


        [Fact]
        public void ApplyDiscounts_ShouldTrue_Campaigns()
        {
            CreateCart();


            foreach(var item in cart.Items){
                Assert.Equal(item.Discount,90); 
            }


        }

        [Fact]
        public void AddItem_ShouldTrue_Products()
        {

            Product apple = new Product("Apple", 100.0, food);
            Product almond = new Product("Almonds", 150.0, food);

            cart.AddItem(apple, 3);
            cart.AddItem(almond, 1);

            Assert.Equal(cart.Items.Count, 2);
      
        }


        [Fact]
        public void TotalAmountAfterDiscounts_ShouldTrue()
        {
            CreateCart();
            Assert.Equal(cart.GetTotalAmountAfterDiscounts(), 360);

        }


        [Fact]
        public void CouponDiscount_ShouldTrue()
        {
            CreateCart();
            Assert.Equal(cart.GetCouponDiscount(), 0);

        }

 

        [Fact]
        public void CampaignDiscount_ShouldTrue()
        {
            CreateCart();
            Assert.Equal(cart.GetCampaignDiscount(), 90);

        }

        [Fact]
        public void DeliveryCost_ShouldTrue()
        {
            CreateCart();
            Assert.Equal(cart.GetDeliveryCost(), 52.99);

        }

 
        public void CreateCart(){

            Product apple = new Product("Apple", 100.0, food);
            Product almond = new Product("Almonds", 150.0, food);


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

        }


    }
}
