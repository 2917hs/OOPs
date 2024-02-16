using System;
namespace InterviewQA.ECommerceDiscount
{
    public class Canada : Country
    {
        public Canada()
        {
        }

        public override bool IsOfferApplicable { get; set; }

        public override void ApplyDiscount(decimal price, ref decimal discountedPrice)
        {
            discountedPrice = price * 0.20m;
            discountedPrice = base.CalculateFinalPrice(price, discountedPrice);
        }

        public override Country Clone()
        {
            return (Country)MemberwiseClone();
        }
    }
}

