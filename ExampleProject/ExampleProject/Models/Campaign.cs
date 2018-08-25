using System;
using ExampleProject.Enums;
namespace ExampleProject.Models
{
    public class Campaign
    {

        public Category Category { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }

        //I added this item because has't minimum of products
        public int MinimumProductCount { get; set; }


        public Campaign(Category category, double discount, DiscountType discountType, int minimumProductCount)
        {
            this.Category = category;
            this.Discount = discount;
            this.DiscountType = discountType;
            this.MinimumProductCount = minimumProductCount;
        }



    }
}
