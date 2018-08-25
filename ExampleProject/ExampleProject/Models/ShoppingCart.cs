using System;
using System.Collections.Generic;
using ExampleProject.Enums;
using System.Linq;
namespace ExampleProject.Models
{
    public class ShoppingCart
    {

        public List<ShoppingCartItem> Items { get; set; } 
       
        //without discounts
        public double TotalCost { get; set; }

        //
        public double DiscountCost { get; set; }

        //
        public double CouponDiscountCost { get; set; }

        public double CampaignDiscountCost { get; set; }

        public double DeliveryCost { get; set; }

        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }


        public void AddItem(Product product, int quantity){

            var item = new ShoppingCartItem(product:product,quantity:quantity); 
            this.Items.Add(item);

            this.TotalCost += item.GetTotalPrice(); 
        }


        public void ApplyDiscounts(params Campaign[] campaigns){

     
            foreach(var campaign in campaigns) {
                var sameCategory = this.Items.Where(w => w.Product.Category == campaign.Category);
                var productCount = sameCategory.Sum(s => s.Quantity);
 
                if(productCount >= campaign.MinimumProductCount){
                    
                    //defalt type is DiscountType.Amount for clean code 
                    var discount = campaign.Discount; 

                    var categoryCost = sameCategory.Sum(s => s.Product.Price * s.Quantity);
 
                    if(campaign.DiscountType == DiscountType.Rate){ 
                        discount = categoryCost * campaign.Discount / 100; 

                    }
                    CampaignDiscountCost += discount;
                    DiscountCost += discount; 


                    foreach (var cat in sameCategory)
                    {
                        cat.Discount = discount;
                    }

                }

            }

            
        }

        public void ApplyCoupon(Coupon coupon){ 

            if(DiscountCost >= coupon.MinCost){
                if(coupon.DiscountType == DiscountType.Rate){
                    
                    CouponDiscountCost = DiscountCost * (coupon.Discount / 100);

                }else{
                    CouponDiscountCost = coupon.Discount;
                }
                DiscountCost += CouponDiscountCost; 
            }
        }


        public double GetTotalAmountAfterDiscounts(){
           return TotalCost - DiscountCost;
            
        }

        public double GetCouponDiscount(){
            return CouponDiscountCost;
        }


        public double GetCampaignDiscount(){
            return CampaignDiscountCost;
        }

        public double GetDeliveryCost(){

            return this.DeliveryCost;
        }


        public void Print(){
            Console.WriteLine("Category Title - Product Name - Quantity - Unit Price - Total Prie - Discount ");

            foreach (var category in Items.GroupBy(g => g.Product.Category)){
                Console.WriteLine(category.Key.Title);
                foreach (var item in category){
                    Console.WriteLine(item.Product.Category.Title + "-" + item.Product.Name + "-"  + item.Quantity + "-" + item.Product.Price + "-" + item.GetTotalPrice() + "-" + item.Discount);
                }
            }
        }
    }
}
