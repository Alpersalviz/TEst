using System;
using ExampleProject.Enums;
namespace ExampleProject.Models
{
    public class Coupon
    {

        public double MinCost { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }


        public Coupon(double minCost, double discount, DiscountType discountType)
        {
            this.MinCost = minCost;
            this.Discount = discount;
            this.DiscountType = discountType;
        }

    }
}
