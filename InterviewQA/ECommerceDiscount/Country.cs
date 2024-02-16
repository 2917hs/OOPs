using System;
namespace InterviewQA.ECommerceDiscount
{
    public abstract class Country
    {
        public delegate void FlatDiscountDelegate(decimal price, ref decimal discountedPrice);

        public Country()
        {

        }

        public abstract bool IsOfferApplicable { get; set; }

        public abstract Country Clone();

        public abstract void ApplyDiscount(decimal price, ref decimal discountedPrice);

        protected virtual decimal CalculateFinalPrice(decimal price, decimal discountedPrice)
        {
            return price - discountedPrice;
        }
    }
}

